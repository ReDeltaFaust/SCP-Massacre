using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [Header("Menu Panels")]
    public GameObject homePanel;
    public GameObject pickSidePanel;

    void Start()
    {
        homePanel.SetActive(true);
        pickSidePanel.SetActive(false);
    }

    public void OpenPickSide()
    {
        homePanel.SetActive(false);
        pickSidePanel.SetActive(true);
    }

    public void BackToHome()
    {
        pickSidePanel.SetActive(false);
        homePanel.SetActive(true);
    }

    public void OpenControls()
    {
        // WIP
    }

    public void OpenOptions()
    {
        // WIP
    }

    public void ExitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
