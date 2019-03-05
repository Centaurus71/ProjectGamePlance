using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float moveSpeed = 20f;
    private Vector3 moveVector;
    private CharacterController characterController;
    /*LoadObject bomb = new LoadObject();
    GameObject gameObject;
    
    Rigidbody rigidbody;*/
    private void Start()
    {
        /*gameObject = bomb.LoadBomd();
        rigidbody = GetComponent<Rigidbody>();*/
        characterController = GetComponent<CharacterController>();   
    }

    private void CharacterMove()
    {
        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal") * moveSpeed;
        moveVector.z = Input.GetAxis("Vertical") * moveSpeed;

        if (Vector3.Angle(Vector3.forward, moveVector)>1f || Vector3.Angle(Vector3.forward, moveVector) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, moveVector, moveSpeed, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }

        characterController.Move(moveVector * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Vector3 vector3 = transform.localPosition;
        /*if (Input.GetKeyDown(KeyCode.Q))
        {
                Instantiate(gameObject, vector3, Quaternion.identity);
                Destroy(gameObject,3f);
        }*/
        CharacterMove();
        /*
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-transform.forward * speed * Time.deltaTime);
        }*/
    }
}
