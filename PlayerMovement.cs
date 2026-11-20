using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int movementPoints = 4;

    private MovementSpace currentSpace;

    void Start()
    {
        currentSpace = FindClosestSpace();
    }

    void Update()
    {
        if (movementPoints <= 0)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                MovementSpace clickedSpace = hit.collider.GetComponent<MovementSpace>();

                if (clickedSpace != null)
                {
                    TryMove(clickedSpace);
                }
            }
        }
    }

    void TryMove(MovementSpace targetSpace)
    {
        if (targetSpace == currentSpace)
        {
            return;
        }

        if (currentSpace.CanMoveTo(targetSpace))
        {
            MoveToSpace(targetSpace);
        }
    }

    void MoveToSpace(MovementSpace targetSpace)
    {
        currentSpace = targetSpace;

        transform.position = targetSpace.transform.position;

        movementPoints--;

        Debug.Log("Moved to: " + targetSpace.name);
        Debug.Log("Movement remaining: " + movementPoints);
    }

    MovementSpace FindClosestSpace()
    {
        MovementSpace[] spaces = FindObjectsOfType<MovementSpace>();

        MovementSpace closestSpace = null;
        float closestDistance = Mathf.Infinity;

        foreach (MovementSpace space in spaces)
        {
            float distance = Vector2.Distance(transform.position, space.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestSpace = space;
            }
        }

        return closestSpace;
    }

    public void ResetMovement()
    {
        movementPoints = 4;
    }
}