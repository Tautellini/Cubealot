using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    GameManager gm;

    public bool IsFriendly { get; set; }
    public Vector3 Direction { get; set; }

    float step;
    Vector3 move;
    bool isMoving;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gm.roundChanged.AddListener(DoStuff);
    }

    void FixedUpdate()
    {
        step = 3.0f * Time.deltaTime; 
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, move, step);
            if (transform.position == move)
            {
                isMoving = false;
            }
        }
    }

    public void DoStuff()
    {
        // Runter
        if (Direction == Vector3.back)
        {
            move = transform.position;
            move.z = move.z - 1;
            isMoving = true;
        }
        // Hoch
        if (Direction == Vector3.forward)
        {
            move = transform.position;
            move.z = move.z + 1;
            isMoving = true;
        }
        // Links
        if (Direction == Vector3.left)
        {
            move = transform.position;
            move.x = move.x - 1;
            isMoving = true;
        }
        // Rechts
        if (Direction == Vector3.right)
        {
            move = transform.position;
            move.x = move.x + 1;
            isMoving = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger!");
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit enemy!");
            Destroy(this);
        }
    }
}
