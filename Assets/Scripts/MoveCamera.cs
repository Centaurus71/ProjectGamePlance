using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    void Start()
    {
        transform.position = PlayerControl.upPlayVector + new Vector3(0, 90, 0);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position = PlayerControl.upPlayVector + new Vector3(0, 90, 0);
    }
}