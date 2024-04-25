using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreLayerCollision : MonoBehaviour
{
    public CapsuleCollider2D capsuleCollider1;
    public CapsuleCollider2D capsuleCollider2;

    void Start()
    {
        // Ignore collision between capsuleCollider1 and capsuleCollider2
        Physics2D.IgnoreCollision(capsuleCollider1, capsuleCollider2);
    }
}