using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float speed = 20f; // переменная скорости

    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //направление движения
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            transform.Translate(transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            transform.Translate(-transform.forward * speed * Time.deltaTime);
        }
    }
}
