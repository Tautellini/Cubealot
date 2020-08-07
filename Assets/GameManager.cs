using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    protected int Round { get; set; }

    public UnityEvent roundChanged;

    public GameObject player;

    public GameObject enemy;

    private void Start()
    {
        roundChanged.AddListener(MakeMoves);
    }

    public void NextRound()
    {
        Round = Round + 1;
        roundChanged.Invoke();
    }

    public void MakeMoves()
    {
        Debug.Log("Round is:" + Round);
    }
}
