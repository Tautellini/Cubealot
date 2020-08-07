using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SetPosition : MonoBehaviour
{
    public Grid grid;

    // Update is called once per frame
    void Update()
    {
        //transform.position = grid.WorldToLocal(new Vector3(1, transform.position.y, 1));
    }
}
