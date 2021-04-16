using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNewObject : MonoBehaviour
{
    public GameObject prefab;
    Vector3 myPosition;
    bool hasMoved;
    
    void Start()
    {
        hasMoved = false;
        myPosition = prefab.transform.position;
    }

    void Update()
    {
        if(prefab.transform.position != myPosition)
        {
            GameObject clone;
            hasMoved = true;

            clone = Instantiate(prefab, myPosition, prefab.transform.rotation);

            prefab = clone;
        }
    }
}
