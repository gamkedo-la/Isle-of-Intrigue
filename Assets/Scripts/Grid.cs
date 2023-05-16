using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public partial class Grid : MonoBehaviour
{
    public int width;
    public int height;
    public float cellSize = 1f;

    public GameObject nodePrefab;
    public TextMeshProUGUI textPrefab;

    private Node[,] nodes;

    private void Awake()
    {
        InitializeGrid();
    }

    private void InitializeGrid()
    {
        nodes = new Node[width, height];

        // Initialize nodes
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 position = new Vector3(x * cellSize, 0f, y * cellSize);
                GameObject nodeObject = Instantiate(nodePrefab, position, Quaternion.identity);
                Node node = nodeObject.GetComponent<Node>();
                node.SetCoordinates(x, y);
                nodes[x, y] = node;

                // Add text display
                GameObject textObject = Instantiate(textPrefab.gameObject, position + Vector3.up * 0.5f, Quaternion.identity);
                TextMeshProUGUI text = textObject.GetComponent<TextMeshProUGUI>();
                text.text = node.GetCoordinatesText();
            }
        }
    }

    public Node GetNode(int x, int y)
    {
        if (x >= 0 && x < width && y >= 0 && y < height)
        {
            return nodes[x, y];
        }
        return null;
    }
}

public partial class Node : MonoBehaviour
{
    private int x;
    private int y;

    public void SetCoordinates(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public string GetCoordinatesText()
    {
        return "(" + x + ", " + y + ")";
    }
}

