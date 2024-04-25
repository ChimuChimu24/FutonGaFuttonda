using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreBoxCollider2D : MonoBehaviour
{
    public BoxCollider2D boxCollider1;
    public BoxCollider2D boxCollider2;

    void Start()
    {
        // Ignore collision between boxCollider1 and boxCollider2
        Physics2D.IgnoreCollision(boxCollider1, boxCollider2);
    }
}
