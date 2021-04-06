using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  A manager component which finds the voltage and current values in the circuit.
/// </summary>
public class CircuitManager : MonoBehaviour
{
    public List<Node> Nodes { get; private set; }
    public List<Node> NodesToSearch { get; private set; } = new List<Node>();
    private int maxX = 0, maxY = 0;
    public List<Mesh> Meshes {  get; private set; } = new List<Mesh>();


    private void Awake()
    {
        Nodes = Node.TotalNodes;
        
        //find maxX & maxY
        foreach (Node n in Nodes)
        {
            if (n.x > maxX)
                maxX = n.x;
            if (n.y > maxY)
                maxY = n.y;
        }

        foreach (Node n in Nodes)
        {
            if (n.x < maxX && n.y < maxY)
                NodesToSearch.Add(n);
        }
    }

    private void Update()
    {
        Meshes = FindMeshes();
        if (Meshes.Count > 0)
            Debug.Log("# of Meshes: " + Meshes.Count);
    }

   

    public List<Mesh> FindMeshes()
    {
        List<Mesh> meshes = new List<Mesh>();

        //start at (0,0)

        foreach (Node n in NodesToSearch)
        {
            Mesh currentMesh = new Mesh();
            Node startNode = n;
            Node currentNode = startNode;
            Direction lastDir = Direction.DEFAULT;
            Direction nextDir = Direction.UP;
            //a while loop to fill the current mesh with components and nodes.
            //continues onto next mesh if current mesh found to not be a closed loop of electrical components.
            do
            {
                currentNode = NextNode(currentNode, nextDir);             
                if (currentNode == null && lastDir == Direction.DEFAULT)
                    goto OUTER; //not a valid mesh
                else if (currentNode == null && lastDir != Direction.DEFAULT)
                {
                    currentNode = NextNode(currentNode, lastDir);
                    Console.WriteLine(currentNode.x + "," + currentNode.y);
                    if (currentNode == null)
                        goto OUTER; //not a valid mesh
                }
                else
                {
                    lastDir = nextDir;
                    nextDir++;
                }
            } while (startNode != currentNode);
            
            meshes.Add(currentMesh);
            
            OUTER: { }
        }

        return meshes;
    }

    /// <summary>
    /// Returns the node which is next to Node n in the direction given. Returns null if there is no component between the
    /// two nodes. For example, the next node UP from a node at (0,0) would be at (0,1) (increment the y coordinate), but
    /// only if there is a component between them.
    /// </summary>
    public Node NextNode(Node n, Direction dir)
    {
        foreach (Component c in n.Components)
        {

            //if the current segment is in the correct direction AND it is full, return the segment.
            if (GetNodeDir(n, c.OtherNode(n)) == dir)
                return c.OtherNode(n);
        }

        return null;
    }

    public Direction GetNodeDir(Node a, Node b)
    {
        if (b.y == a.y + 1 && a.x == b.x)
            return Direction.UP;
        if (b.y == a.y - 1 && a.x == b.x)
            return Direction.DOWN;
        if (b.x == a.x + 1 && a.y == b.y)
            return Direction.RIGHT;
        if (b.x == a.x - 1 && a.y == b.y)
            return Direction.LEFT;
        else
            return Direction.DEFAULT;
    }


}

public enum Direction
{
    DEFAULT,
    UP,     //+y
    RIGHT,  //+x
    DOWN,   //-y
    LEFT    //-x
  }
