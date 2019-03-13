using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Vector3 localVestorPlayer;
    Vector3 localVetorX = new Vector3(11, 0, 0);
    Vector3 localVetorZ = new Vector3(0, 0, 11);
    Vector3 moveVectorZ = new Vector3(0, 0, 1);
    Vector3 moveVectorX = new Vector3(1, 0, 0);
    bool statusCorution = false;

    IEnumerator MovePlaeyr(Vector3 vector, Operation operation)
    {
        statusCorution = true;
        if (operation == Operation.Add)
        {
            for (int i = 0; i < 11; i++)
            {
                yield return new WaitForSeconds(0.06f);
                transform.position += vector;
            }
        }
        else if (operation == Operation.Compute)
        {
            for (int i = 0; i < 11; i++)
            {
                yield return new WaitForSeconds(0.06f);
                transform.position -= vector;
            }
        }
        statusCorution = false;
    }

    private void Start()
    {
        localVestorPlayer = transform.localPosition;

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (Field.emptySpace.IndexOf(localVestorPlayer + localVetorZ) != -1 & statusCorution == false)
            {
                StartCoroutine(MovePlaeyr(moveVectorZ, Operation.Add));
                localVestorPlayer += localVetorZ;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (Field.emptySpace.IndexOf(localVestorPlayer - localVetorZ) != -1 & statusCorution == false)
            {
                StartCoroutine(MovePlaeyr(moveVectorZ, Operation.Compute));
                localVestorPlayer -= localVetorZ;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (Field.emptySpace.IndexOf(localVestorPlayer + localVetorX) != -1 & statusCorution == false)
            {
                StartCoroutine(MovePlaeyr(moveVectorX, Operation.Add));
                localVestorPlayer += localVetorX;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (Field.emptySpace.IndexOf(localVestorPlayer - localVetorX) != -1 & statusCorution == false)
            {
                StartCoroutine(MovePlaeyr(moveVectorX, Operation.Compute));
                localVestorPlayer -= localVetorX;
            }
        }
    }
}
