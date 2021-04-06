using System;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public static List<Node> TotalNodes {get; private set;} = new List<Node>();
    public static GameObject nw;
    public static GameObject ne;
    public static GameObject se;
    public static GameObject sw;
    public const string NW = "NW";
    public const string NE = "NE";
    public const string SE = "SE";
    public const string SW = "SW";
    public int x,y;

    public List<Component> Components { get; private set; } = new List<Component>();

    //leads is a collider array representing the electrical components inside the given node
    public List<GameObject> leads = new List<GameObject>();

    void Start()
    {
        nw = GameObject.Find(NW);
        ne = GameObject.Find(NE);
        se = GameObject.Find(SE);
        sw = GameObject.Find(SW);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "lead")
            leads.Add(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "lead")
            leads.Remove(other.gameObject);
    }

    public static int NodeNumber(GameObject node)
    {
        if (node == nw)
        {
            return 0;
        }

        if (node == ne)
        {
            return 1;
        }

        if (node == se)
        {
            return 2;
        }

        if (node == sw)
        {
            return 3;
        }
        else
        {
            return -1;
        }
    }

    public static List<GameObject> Nodes(GameObject component)
    {
        List<GameObject> obNodes = new List<GameObject>();

        foreach(var l in nw.GetComponent<Node>().leads)
        {
            if (l.name != component.name) continue;
            obNodes.Add(nw);
            break;
        }  

        foreach (var l in ne.GetComponent<Node>().leads)
        {
            if (l.name != component.name) continue;
            obNodes.Add(ne);
            break;
        }
        foreach (var l in se.GetComponent<Node>().leads)
        {
            if (l.name != component.name) continue;
            obNodes.Add(se);
            break;
        }
        foreach (var l in sw.GetComponent<Node>().leads)
        {
            if (l.name != component.name) continue;
            obNodes.Add(sw);
            break;
        }
        return obNodes;
     }

     public static bool IsParallel(GameObject ob1, GameObject ob2)
     {
        var ob1Nodes= Nodes(ob1);
        var ob2Nodes = Nodes(ob2);
        if (ob1Nodes.Count > 1 && ob2Nodes.Count > 1)
        {
         return string.Equals(ob1Nodes[0].name, ob2Nodes[0].name) && string.Equals(ob1Nodes[1].name, ob2Nodes[1].name) || string.Equals(ob1Nodes[0].name, ob2Nodes[1].name) && string.Equals(ob1Nodes[1].name, ob2Nodes[0].name);
        }
        else return false;
     }

    public static bool IsParallel(GameObject ob1, GameObject ob2A, GameObject ob2B)
    {
        var ob1Nodes = Nodes(ob1);
        var ob2ANode = Nodes(ob2A);
        var ob2BNode = Nodes(ob2B);
        if (ob1Nodes.Count > 1 && ob2ANode.Count > 0 && ob2BNode.Count > 0){
            return (ob1Nodes[0].name == ob2ANode[0].name && ob1Nodes[1] == ob2BNode[0] || ob1Nodes[0].name == ob2BNode[0].name && ob1Nodes[1] == ob2ANode[0]);
        }
        else return false;
    }

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
}