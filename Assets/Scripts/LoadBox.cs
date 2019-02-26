using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBox : MonoBehaviour
{
    public void loadBox(List<Vector3> emptySpace, int randomNumber, string complexity)
    {
        LoadObject loadboxx = new LoadObject();
        GameObject cubebox = loadboxx.Cubebox();

        Vector3 vectorPlayZ = new Vector3(0, 0, 11);
        Vector3 vectorPlayX = new Vector3(11, 0, 0);
        Vector3 vectorPlayLocal = emptySpace[randomNumber];
        Vector3 vectorRight = vectorPlayLocal;
        Vector3 vectorDown = vectorPlayLocal;
        Vector3 vectorLeft = vectorPlayLocal;
        Vector3 vectorUp = vectorPlayLocal;
        
        int numberEmpty;
        emptySpace.RemoveAt(randomNumber);
        for (int i = 0; i < 3; i++)
        {
            vectorRight = vectorRight - vectorPlayZ;
            if (emptySpace.IndexOf(vectorRight) == -1)
            {
                break;
            }
            else
            {
                emptySpace.Remove(vectorRight);
            }
        }
        for (int i = 0; i < 3; i++)
        {
            vectorDown = vectorDown - vectorPlayX;
            if (emptySpace.IndexOf(vectorDown) == -1)
            {
                break;
            }
            else
            {
                emptySpace.Remove(vectorDown);
            }
        }
        for (int i = 0; i < 3; i++)
        {
            vectorLeft = vectorLeft + vectorPlayZ;
            if (emptySpace.IndexOf(vectorLeft) == -1)
            {
                break;
            }
            else
            {
                emptySpace.Remove(vectorLeft);
            }
        }
        for (int i = 0; i < 3; i++)
        {
            vectorUp = vectorUp + vectorPlayX;
            if (emptySpace.IndexOf(vectorUp) == -1)
            {
                break;
            }
            else
            {
                emptySpace.Remove(vectorUp);
            }
        }
        numberEmpty = emptySpace.Count;
        if (complexity == "lung")
        {
            int number = numberEmpty * 40 / 100;
            for (int i = 0; i < number; i++)
            {
                int nuumber = emptySpace.Count;
                int rannumber = Random.Range(0, nuumber - 1);
                Instantiate (cubebox, emptySpace[rannumber], Quaternion.identity);
                emptySpace.RemoveAt(rannumber);
            }
        }
    }
}
