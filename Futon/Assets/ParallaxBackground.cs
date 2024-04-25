using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private Vector2 parallaxEffectMultipler;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private float textureUnitSizeX;
    
    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite; 
        Texture2D texture = sprite.texture;
        textureUnitSizeX = sprite.bounds.size.x;   
        }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultipler.x, deltaMovement.y * parallaxEffectMultipler.y);
        lastCameraPosition = cameraTransform.position;

        if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX * transform.localScale.x)
        {
            float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX * transform.localScale.x;
            transform.position = new Vector3 (cameraTransform.position.x + offsetPositionX, transform.position.y);
        }
    }
}
