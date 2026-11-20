using UnityEngine;
using System.Collections.Generic;

public class MovementSpace : MonoBehaviour
{
    public enum ConnectionType
    {
        Open,
        Green,
        Gray,
        Wall,
        Door
    }

    [System.Serializable]
    public class Connection
    {
        public MovementSpace connectedSpace;
        public ConnectionType type;
    }

    public List<Connection> connections = new List<Connection>();

    public bool CanMoveTo(MovementSpace target)
    {
        foreach (Connection connection in connections)
        {
            if (connection.connectedSpace == target)
            {
                if (connection.type == ConnectionType.Wall)
                {
                    return false;
                }

                return true;
            }
        }

        return false;
    }
}