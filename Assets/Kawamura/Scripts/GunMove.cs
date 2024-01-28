using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunMove : MonoBehaviour
{
    string owner;  //Œ‚‚Á‚½ƒLƒƒƒ‰
    Transform target;
    Rigidbody2D rb;

    public string SetOwner
    {
        set { owner = value; }
    }
    public string GetOwner
    {
        get { return owner; }
    }

    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        if (owner == "LeftPlayer")
        {
            target = GameObject.FindGameObjectWithTag("RightPlayer").GetComponent<Transform>();
        }
        else if (owner == "RightPlayer")
        {
            target = GameObject.FindGameObjectWithTag("LeftPlayer").GetComponent<Transform>();
        }

        rb = GetComponent<Rigidbody2D>();
        Vector3 targetPosition = target.position;
        targetPosition.y += 0.5f;
        Vector2 direction = (targetPosition - transform.position).normalized;

        //Vector2 dir = new Vector2(
        //    transform.forward.z,
        //    transform.forward.x);
        rb.velocity = transform.right * speed;
        Debug.Log(transform.forward);
        //rb.velocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 targetPosition = target.transform.position;
        //targetPosition.y += 1.0f;
        //transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        //Vector3 vec3TargetPosition = targetPosition;




        //if(owner == "LeftPlayer")
        //{
        //    if(transform.position.x < targetPosition.x)
        //    {
        //        Destroy(gameObject);
        //    }
        //}
        //else if(owner == "RightPlayer")
        //{
        //    if (transform.position.x > targetPosition.x)
        //    {
        //        Destroy(gameObject);
        //    }
        //}

        //if (transform.position == vec3TargetPosition)
        //{
        //    Destroy(gameObject);
        //}
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(owner == "LeftPlayer")
    //    {
    //        if(collision.gameObject.tag == "RightPlayer")
    //        {
    //            Destroy(gameObject);
    //        }
    //    }
    //    else if(owner == "RightPlayer")
    //    {
    //        if (collision.gameObject.tag == "LeftPlayer")
    //        {
    //            Destroy(gameObject);
    //        }
    //    }
    //}
}
