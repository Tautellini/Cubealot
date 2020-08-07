using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameManager gm;
    public float speed = 5.0f;
    float step;
    Vector3 move;
    bool isMoving;
    bool isShooting;
    public float waitTime;
    float wait = 0f;
    public GameObject shot;

    public int shotRate = 5;
    int shotRateTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        gm.roundChanged.AddListener(ReduceShotRateTimer);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        step = speed * Time.deltaTime; // calculate distance to move
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, move, step);
            if (transform.position == move)
            {
                isMoving = false;
            }
        }
    }
    private void Update()
    {
        wait -= Time.deltaTime;
        if (!isMoving && !isShooting && wait <= 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                move = transform.position;
                move.z = move.z + 1;
                isMoving = true;
                gm.NextRound();
                wait = waitTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                move = transform.position;
                move.z = move.z - 1;
                isMoving = true;
                gm.NextRound();
                wait = waitTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                move = transform.position;
                move.x = move.x - 1;
                isMoving = true;
                gm.NextRound();
                wait = waitTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                move = transform.position;
                move.x = move.x + 1;
                isMoving = true;
                gm.NextRound();
                wait = waitTime;
            }
        }
        if (!isMoving && !isShooting)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (shotRateTimer <= 0)
                {
                    GameObject obj = Instantiate(shot, transform.position + Vector3.right, Quaternion.identity, transform.parent);
                    obj.GetComponent<Shot>().Direction = Vector3.right;
                    shotRateTimer = shotRate;
                }
            }
        }
    }
    public void ReduceShotRateTimer()
    {
        shotRateTimer--;
    }
}
