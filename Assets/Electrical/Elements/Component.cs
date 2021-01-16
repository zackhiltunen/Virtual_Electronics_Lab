using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Parent class for electrical components. Establishes element types. Elements occupy Segments.
/// </summary>
public class Component : MonoBehaviour
{
    public ComponentType Type { get; [SerializeField] protected set; } = ComponentType.Default;
    public float Resistance { get; [SerializeField] protected set; } = 0f;

    public List<Node> Nodes { get { return Node.FindNodesForComponent(this); } private set {; } }
    private CircuitManager circuitManager = GameObject.FindObjectOfType<CircuitManager>();

    private void Update()
    {

    }

    public Node OtherNode(Node n)
    {
        if (Nodes.Count == 2)
        {
            if (n == Nodes[0])
                return Nodes[1];
            if (n == Nodes[1])
                return Nodes[0];
            else
                return null;
        }

        return null;
    }

    public double GetCurrent()
    {
        throw new NotImplementedException();
    }

    public double GetVoltage()
    {
        throw new NotImplementedException();
    }

    public static bool IsCurrentCarrier(Component c)
    {
        ComponentType t = c.Type;
        
        return t == ComponentType.Resistor || t == ComponentType.Wire || 
               t == ComponentType.Ammeter || t == ComponentType.Supply;
    }
    public static bool IsCurrentCarrier(ComponentType t)
    {
        return t == ComponentType.Resistor || t == ComponentType.Wire ||
               t == ComponentType.Ammeter || t == ComponentType.Supply;
    }
}

public enum ComponentType
{
    Default,
    Resistor,
    Wire,
    Voltmeter,
    Ammeter,
    Supply
}
