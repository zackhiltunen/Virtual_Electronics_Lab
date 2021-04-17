using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNewObject : MonoBehaviour
{
    public GameObject prefab;
    Vector3 myPosition;
    Quaternion myRotation;
    bool hasMoved;
    
    void Start()
    {
        hasMoved = false;
        myPosition = prefab.transform.position;
        myRotation = prefab.transform.rotation;
    }

    void Update()
    {
        if(prefab.transform.position != myPosition)
        {
            GameObject clone;
            hasMoved = true;

            clone = Instantiate(prefab, myPosition, myRotation);

            prefab = clone;
        }
    }
}
