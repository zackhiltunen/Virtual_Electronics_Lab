using System;
using System.Collections.Generic;
using UnityEngine;


/// Node.cs is the script for the Node Component attached to the node objects.
public class Node : MonoBehaviour
{
    public static List<Node> TotalNodes { get; private set; } = new List<Node>();

    public List<Component> Components { get; private set; } = new List<Component>();
    public List<Node> AdjacentNodes { get; private set; } = new List<Node>();

    public int x, y;

    private void Awake()
    {
        TotalNodes.AddRange(FindObjectsOfType<Node>());
        AdjacentNodes = FindAdjacentNodes(this);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Component>() != null)
            Components.Add(other.gameObject.GetComponent<Component>());
        if (other.gameObject.GetComponentInParent<Component>() != null)
            Components.Add(other.gameObject.GetComponentInParent<Component>());
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Component>() != null)
            Components.Remove(other.gameObject.GetComponent<Component>());
        if (other.gameObject.GetComponentInParent<Component>() != null)
            Components.Add(other.gameObject.GetComponentInParent<Component>());
    }

    /// <summary>
    ///Returns a list of each node a component is in. 
    /// </summary>
    public static List<Node> FindNodesForComponent(Component component)
    {
        List<Node> nodesComponentIn = new List<Node>();

        foreach (Node n in TotalNodes)
        {
            foreach (Component c in n.Components)
            {
                if (c == component)
                    nodesComponentIn.Add(n);
            }
        }

        return nodesComponentIn;
    }

    /// <summary>
    /// Returns a list of adjacent nodes. Returns an empty list if none adjacent.
    /// </summary>
    public List<Node> FindAdjacentNodes(Node n)
    {
        List<Node> adj = new List<Node>();
        foreach(Node t in TotalNodes)
        {
            if ((Math.Abs(t.x - n.x) == 1 && (Math.Abs(t.y - n.y)) == 0) ||
                (Math.Abs(t.x - n.x) == 0 && (Math.Abs(t.y - n.y)) == 1)
                )
            {
                adj.Add(t);
            }
        }

        return adj;
    }
}

