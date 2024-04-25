using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefabOnPosition : MonoBehaviour
{
    public GameObject prefabToInstantiate;
    public Vector3 distanceThreshold;

    public Vector3 instantiationPosition;
    private bool hasInstantiated = false;

    void Start()
    {
        // Set the instantiation position here or through other means in your game

    }

    void Update()
    {
        if (!hasInstantiated && transform.position.x > distanceThreshold.x)
        {
            Instantiate(prefabToInstantiate, instantiationPosition, Quaternion.identity);
            hasInstantiated = true;
        }
    }
}