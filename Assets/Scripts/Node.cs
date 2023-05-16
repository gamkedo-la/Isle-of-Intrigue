using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public bool walkabale;
    public Vector2 worldPosition;

    public Node(bool _walkable, Vector2 _worldPos)
    {
        walkabale = _walkable;
        worldPosition = _worldPos;
    }
}
