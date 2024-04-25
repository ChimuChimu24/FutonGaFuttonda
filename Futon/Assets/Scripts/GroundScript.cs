using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{

    [SerializeField] float deadZone = 45;
    private Transform playerTransform;
    

    void Start()
        {
            playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
        }
    

    // Update is called once per frame
    void Update()
    {   //Destroys tiles that are X distance behindplayer object
        if(transform.position.x < playerTransform.position.x - deadZone)
        {
            Destroy(gameObject);
            Debug.Log("destroyed tile");
        }
    }
}
