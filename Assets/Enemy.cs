using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform player;
    private GameManager gm;
    Vector3[] moves = new Vector3[100000];

    Vector3 move;
    bool isMoving;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        Random.Range(-17, 17);
        Vector3 position = player.position;
        while (position == player.position)
        {
            position = new Vector3(Random.Range(-17, 17)+0.5f, 0.5f, Random.Range(-10, 10) + 0.5f);
        }
        transform.position = position;

        gm.roundChanged.AddListener(DoStuff);

        //// Calculate Random Movements
        //for (int rounds = 0; rounds<100000; rounds++)
        //{
        //    if(moves[rounds] != moves[0])
        //    {

        //    }
        //    pos = transform.position;+
        //    switch (Random.Range(0,4))
        //    {
        //        // Hoch
        //        case 0:
        //            moves[rounds] = new Vector3(transform.position);
        //            break;
        //        // Runter
        //        case 1:
        //            break;
        //        // Links
        //        case 2:
        //            break;
        //        // Rechts
        //        case 3:
        //            break;
        //    }
        //}
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, move, 3.0f*Time.deltaTime);
            if (transform.position == move)
            {
                isMoving = false;
            }
        }
    }

    public void DoStuff()
    {
        switch (Random.Range(0, 2))
        {
            // Move
            case 0:
                switch (Random.Range(0, 4))
                {
                    // Hoch
                    case 0:
                        if (transform.position.z + 1 > 9)
                        {
                            move = transform.position + new Vector3(0, 0, -1);
                            isMoving = true;
                            break;
                        }
                        else
                        {
                            move = transform.position + new Vector3(0, 0, 1);
                            isMoving = true;
                            break;
                        }
                    // Runter
                    case 1:
                        if (transform.position.z - 1 < -9 )
                        {
                            move = transform.position + new Vector3(0, 0, +1);
                            isMoving = true;
                            break;
                        } else
                        {
                            move = transform.position + new Vector3(0, 0, -1);
                            isMoving = true;
                            break;
                        }
                    // Links
                    case 2:
                        if (transform.position.x - 1 < -16)
                        {
                            move = transform.position + new Vector3(1, 0, 0);
                            isMoving = true;
                            break;
                        }
                        else
                        {
                            move = transform.position + new Vector3(-1, 0, 0);
                            isMoving = true;
                            break;
                        }
                    // Rechts
                    case 3:
                        if (transform.position.x + 1 > 16)
                        {
                            move = transform.position + new Vector3(-1, 0, 0);
                            isMoving = true;
                            break;
                        }
                        else
                        {
                            move = transform.position + new Vector3(1, 0, 0);
                            isMoving = true;
                            break;
                        }
                }
                break;

            // Shoot
            case 1:
                break;
        }
    }
}
