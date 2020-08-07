using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxVelocity;
    public float forwardForce;
    public float backwardForce;
    public float sidewayForce;
    public float turningForce;
    public float jumpForce = 5.0f;
    public Rigidbody rb;
    public Transform objects;
    public Animator anim;

    bool isJumping = false;

    int timer = 0;
    private Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.localPosition;
    }

    private void Update()
    {
        Vector3 direction = Quaternion.Inverse(transform.rotation) * rb.velocity;
        Vector3 pos;
        pos = transform.localPosition - lastPosition;
        //Debug.Log(direction);
        if (direction.x < -4)
        {
            Debug.Log("Moving Left");
        }
        if (direction.x > 4)
        {
            Debug.Log("Moving Right");
        }
        // Jumping
        // _________________________________
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (!isJumping)
            {
                isJumping = true;
                rb.AddRelativeForce(new Vector3(0.0f, jumpForce, 0.0f));
            }
        }
        // Check if Player touched the Ground
        if (transform.position.y <= 0.2)
        {
            isJumping = false;
        } else if (transform.position.y > 0.2)
        {
            isJumping = true;
        }

        // KeyDowns
        // _________________________________
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isJumping && direction.x < 4 && rb.velocity.magnitude < 4)
            {
                rb.AddRelativeForce(new Vector3(sidewayForce, 0.0f, 0.0f));
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!isJumping && direction.x > -4 && rb.velocity.magnitude < 4)
            {
                rb.AddRelativeForce(new Vector3(-sidewayForce, 0.0f, 0.0f));
            }
        }
        lastPosition = transform.localPosition;
        if (transform.position.y > 0.1)
        {
            //Vector3 velo = rb.velocity;
            //rb.velocity = velo;
            anim.SetInteger("State", 4);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (!isJumping)
                {
                    anim.SetInteger("State", 2);
                    rb.AddRelativeForce(new Vector3(0.0f, 0.0f, forwardForce));
                }
                //if (objects.rotation.eulerAngles.x < 5f)
                //{
                //    objects.Rotate(new Vector3(0.2f, 0, 0));
                //}
            }
            if (Input.GetKey(KeyCode.S))
            {
                if (!isJumping)
                {
                    anim.SetInteger("State", 2);
                    rb.AddRelativeForce(new Vector3(0.0f, 0.0f, -backwardForce));
                }
                //if (objects.rotation.eulerAngles.x > 355.0f)
                //{
                //    objects.Rotate(new Vector3(-0.5f, 0, 0));
                //}
            }
            if (Input.GetKey(KeyCode.A))
            {
                anim.SetInteger("State", 2);
                transform.Rotate(new Vector3(0.0f, -turningForce, 0.0f));
            }
            if (Input.GetKey(KeyCode.D))
            {
                anim.SetInteger("State", 2);
                transform.Rotate(new Vector3(0.0f, turningForce, 0.0f));
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                anim.SetInteger("State", 1);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                anim.SetInteger("State", 3);
            }
        } else
        {
            anim.SetInteger("State", 0);
        }
        //if (Input.GetKeyUp(KeyCode.W))
        //{
        //    anim.SetInteger("State", 0);
        //    objects.rotation = objects.parent.rotation;
        //}
        //if (Input.GetKeyUp(KeyCode.S))
        //{
        //    anim.SetInteger("State", 0);
        //    objects.rotation = objects.parent.rotation;
        //}
        //if (timer > 1000)
        //{
        //    anim.SetInteger("State", 0);
        //    timer = 0;
        //}
    }
}
