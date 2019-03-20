using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static Vector3 upPlayVector;
    Vector3 localVestorPlayer;
    Vector3 localVetorX = new Vector3(11, 0, 0);
    Vector3 localVetorZ = new Vector3(0, 0, 11);
    Vector3 moveVectorZ = new Vector3(0, 0, 1);
    Vector3 moveVectorX = new Vector3(1, 0, 0);
    bool statusCorution = false;
    const int cellSize = 11;
    Bomb bomb = new Bomb();


    int[,] test = new int[2, 2];


    IEnumerator MovePlaeyr(Vector3 vector, Operation operation)
    {
        statusCorution = true;
        if (operation == Operation.Add)
        {
            for (int i = 0; i < cellSize; i++)
            {
                yield return new WaitForSeconds(0.04f);
                transform.position += vector;
            }
        }
        else if (operation == Operation.Compute)
        {
            for (int i = 0; i < cellSize; i++)
            {
                yield return new WaitForSeconds(0.04f);
                transform.position -= vector;
            }
        }
        statusCorution = false;
    }

    private void Start()
    {
        localVestorPlayer = transform.localPosition;
        for (int i = 0; i < 2; i++)
        {
            for(int x = 0; x < 2; x++)
            {
                test[i, x] = i;
            }
        }
    }

    void Update()
    {
        upPlayVector = transform.localPosition;
        if (Input.GetKey(KeyCode.W))
        {
            if (Field.emptySpace.IndexOf(localVestorPlayer + localVetorZ) != -1 & statusCorution == false)
            {
                StartCoroutine(MovePlaeyr(moveVectorZ, Operation.Add));
                localVestorPlayer += localVetorZ;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (Field.emptySpace.IndexOf(localVestorPlayer - localVetorZ) != -1 & statusCorution == false)
            {
                StartCoroutine(MovePlaeyr(moveVectorZ, Operation.Compute));
                localVestorPlayer -= localVetorZ;
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (Field.emptySpace.IndexOf(localVestorPlayer + localVetorX) != -1 & statusCorution == false)
            {
                StartCoroutine(MovePlaeyr(moveVectorX, Operation.Add));
                localVestorPlayer += localVetorX;
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (Field.emptySpace.IndexOf(localVestorPlayer - localVetorX) != -1 & statusCorution == false)
            {
                StartCoroutine(MovePlaeyr(moveVectorX, Operation.Compute));
                localVestorPlayer -= localVetorX;
                transform.rotation = Quaternion.Euler(0, 270, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            bomb.LoadBomb(transform.localPosition);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            string str = null;
            for (int i = 0; i < 2; i++)
            {
                str = null;
                for (int x = 0; x < 2; x++)
                {
                    str += test[i, x] + " ";
                }
                print(str);
            }

        }
    }
}
