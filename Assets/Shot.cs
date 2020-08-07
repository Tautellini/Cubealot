using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    GameManager gm;

    public bool IsFriendly { get; set; }
    public Vector3 Direction { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gm.roundChanged.AddListener(DoStuff);
    }

    public void DoStuff()
    {

    }
}
