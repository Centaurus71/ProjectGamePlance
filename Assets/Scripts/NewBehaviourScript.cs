using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Vector3 localVestorPlayer;
    Vector3 localVetorX = new Vector3(11, 0, 0);
    Vector3 localVetorZ = new Vector3(0, 0, 11);
    Vector3 vectorZ = new Vector3(0, 0, 1);
    Vector3 vectorX = new Vector3(1, 0, 0);
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
        if (Input.GetKey(KeyCode.Q))
        {
            foreach (Vector3 vector in Field.emptySpace)
            {
                print(vector);
            }
        }
        if (Input.GetKey(KeyCode.E))
            print(Field.emptySpace.Count);

        if (Input.GetKey(KeyCode.W))
        {
            if (Field.emptySpace.IndexOf(localVestorPlayer + localVetorZ) != -1 & statusCorution == false)
            {
                StartCoroutine(MovePlaeyr(vectorZ, Operation.Add));
                localVestorPlayer += localVetorZ;
            }
        }   
    }
}
