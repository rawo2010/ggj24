using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunMove : MonoBehaviour
{
    [SerializeField] float speed;

    private string owner;  //Œ‚‚Á‚½ƒLƒƒƒ‰

    public string SetOwner
    {
        set { owner = value; }
    }

    public string GetOwner
    {
        get { return owner; }
    }

    public void SetVelocty(Vector2 direction)
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed;
    }
}
