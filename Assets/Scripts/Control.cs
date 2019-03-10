using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    private bool statusCoroutine;
    private bool clickButton = false;
    private bool clickButtonW = false;
    private bool clickButtonS = false;
    private bool clickButtonA = false;
    private bool clickButtonD = false;
    
    Vector3 localVestor = new Vector3();
    Vector3 vectorZ = new Vector3(0, 0, 1);
    Vector3 vectorX = new Vector3(1, 0, 0);
    private int numberIEnumerator = 0;
    private int numberButton = 0;

    private void Start()
    {
    }

    IEnumerator movePlay (Vector3 vector, Operation operation)
    {
        if (operation == Operation.Add)
        {
            numberIEnumerator++;
            statusCoroutine = false;
            for (int i = 0; i < 11; i++)
            {
                yield return new WaitForSeconds(0.06f);
                transform.position += vector;
            }
            statusCoroutine = true;
        }
        else if (operation == Operation.Compute)
        {
            numberIEnumerator++;
            statusCoroutine = false;
            for (int i = 0; i < 11; i++)
            {
                yield return new WaitForSeconds(0.06f);
                transform.position -= vector;
            }
            statusCoroutine = true;
        }
    }
   
    private void Update()
    {
        //print("Корутины: "+numberIEnumerator + " " + "Кнопки: " + numberButton);
        //print("Корутин: "+ statusCoroutine +  " / "+ numberIEnumerator + " || " + "Кнопка: " + clickButtonW + " / " + numberButton);
        if (Input.GetKeyDown(KeyCode.Space))
            print(statusCoroutine);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.position = new Vector3(11,5,11);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            numberButton++;
            clickButtonW = true;
            StartCoroutine(movePlay(vectorZ,Operation.Add));
        }
        Movement(ref clickButtonW,ref statusCoroutine,vectorZ,Operation.Add);
        if (Input.GetKeyUp(KeyCode.W))
        {
            clickButtonW = false;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            numberButton++;
            clickButtonA = true;
            StartCoroutine(movePlay(vectorX, Operation.Compute));
        }
        Movement(ref clickButtonA, ref statusCoroutine, vectorX, Operation.Compute);
        if (Input.GetKeyUp(KeyCode.A))
        {
            clickButtonA = false;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            numberButton++;
            clickButtonD = true;
            StartCoroutine(movePlay(vectorX, Operation.Add));
        }
        Movement(ref clickButtonD, ref statusCoroutine, vectorX, Operation.Add);
        if (Input.GetKeyUp(KeyCode.D))
        {
            clickButtonD = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            numberButton++;
            clickButtonS = true;
            StartCoroutine(movePlay(vectorZ, Operation.Compute));
        }
        Movement(ref clickButtonS, ref statusCoroutine, vectorZ, Operation.Compute);
        if (Input.GetKeyUp(KeyCode.S))
        {
            clickButtonS = false;
        }
    }

    private void Movement (ref bool clickButton, ref bool statusCoroutine, Vector3 vector, Operation operation)
    {
        if (statusCoroutine == true & clickButton == true)
        {
           StartCoroutine(movePlay(vector, operation));
        }
        else if (statusCoroutine == true & clickButton == false)
        {
            StopCoroutine(movePlay(vector, operation));
        }
    }
}
