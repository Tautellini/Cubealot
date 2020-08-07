using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGrid : MonoBehaviour
{
    public GameObject prefab;
    private void Awake()
    {
        for (int i = -16; i<=16; i++)
        {
            for (int k = -9; k<=9; k++)
            {
                Instantiate(prefab, new Vector3(i+0.5f, 0, k+0.5f), Quaternion.identity, transform);
            }
        }
    }
}
