using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Animator ch_animator;
    public static Vector3 upPlayVector;
    Vector3 localVestorPlayer;
    Vector3 localVetorX = new Vector3(11, 0, 0);
    Vector3 localVetorZ = new Vector3(0, 0, 11);
    Vector3 moveVectorZ = new Vector3(0, 0, 1);
    Vector3 moveVectorX = new Vector3(1, 0, 0);
    List<Vector3> vectorsMove = Field.emptySpace;
    bool statusCorution = false;
    bool statusDownSpace = false;
    const int cellSize = 11;
    Bomb bomb = new Bomb();
    float timeSpeed = 0.04f;

    int[,] test = new int[2, 2];


    IEnumerator MovePlaeyr(Vector3 vector, Operation operation)
    {
        statusCorution = true;
        if (operation == Operation.Add)
        {
            for (int i = 0; i < cellSize; i++)
            {
                yield return new WaitForSeconds(timeSpeed);
                transform.position += vector;
            }
        }
        else if (operation == Operation.Compute)
        {
            for (int i = 0; i < cellSize; i++)
            {
                yield return new WaitForSeconds(timeSpeed);
                transform.position -= vector;
            }
        }
        statusCorution = false;
    }

    private void Start()
    {
        localVestorPlayer = transform.localPosition;
        ch_animator = GetComponent<Animator>();
        for (int i = 0; i < 2; i++)
        {
            for(int x = 0; x < 2; x++)
            {
                test[i, x] = i;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GainsSpeed")
        {
            timeSpeed = 0.01f;
        }
        if (other.gameObject.tag == "GainsWall")
        {
            vectorsMove = Field.testEmptySpace;
        }
    }

    void Update()
    {
        if (statusCorution == true) ch_animator.SetBool("Move", true);
        else ch_animator.SetBool("Move", false);

        upPlayVector = transform.localPosition;
        if (Input.GetKey(KeyCode.W))
        {
            if (vectorsMove.IndexOf(localVestorPlayer + localVetorZ) != -1 & statusCorution == false & statusDownSpace == false)
            {
                StartCoroutine(MovePlaeyr(moveVectorZ, Operation.Add));
                localVestorPlayer += localVetorZ;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (vectorsMove.IndexOf(localVestorPlayer - localVetorZ) != -1 & statusCorution == false & statusDownSpace == false)
            {
                StartCoroutine(MovePlaeyr(moveVectorZ, Operation.Compute));
                localVestorPlayer -= localVetorZ;
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (vectorsMove.IndexOf(localVestorPlayer + localVetorX) != -1 & statusCorution == false & statusDownSpace == false)
            {
                StartCoroutine(MovePlaeyr(moveVectorX, Operation.Add));
                localVestorPlayer += localVetorX;
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (vectorsMove.IndexOf(localVestorPlayer - localVetorX) != -1 & statusCorution == false & statusDownSpace == false)
            {
                StartCoroutine(MovePlaeyr(moveVectorX, Operation.Compute));
                localVestorPlayer -= localVetorX;
                transform.rotation = Quaternion.Euler(0, 270, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) & statusCorution != true)
        {

            statusDownSpace = true;
            if (statusCorution == true) ch_animator.SetBool("Sit", true);
            else ch_animator.SetBool("Sit", false);
            if (statusCorution == true) ch_animator.SetBool("GetUp", true);
            else ch_animator.SetBool("GetUp", false);

            int x = Mathf.FloorToInt((transform.localPosition.x / 11) * 11);
            int z = Mathf.FloorToInt((transform.localPosition.z / 11) * 11);
            Vector3 roundVector = new Vector3(x, 5, z);
            print(" x = " + x + " / " + " z = " + z);
            bomb.LoadBomb(roundVector);
            statusDownSpace = false;
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
