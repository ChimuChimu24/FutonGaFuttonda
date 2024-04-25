using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{

    public float selfDestructTime = 3f; // Time in seconds before self-destruct
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SelfDestructAction", selfDestructTime);
    }

    // Update is called once per frame

        void SelfDestructAction()
    {
        Destroy(gameObject);
    }
}
