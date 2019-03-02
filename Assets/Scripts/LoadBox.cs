using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBox : MonoBehaviour
{
    public void loadBox(List<Vector3> emptySpace, int randomNumber, string complexity)
    {
        
        LoadObject loadboxx = new LoadObject();
        GameObject cubebox = loadboxx.loadcubebox();
        SearchWaysPlayer searchWaysPlayer = new SearchWaysPlayer();
        Vector3 vectorPlayZ = new Vector3(0, 0, 11);
        Vector3 vectorPlayX = new Vector3(11, 0, 0);
        Vector3 vectorPlayLocal = emptySpace[randomNumber];
        
        int numberEmpty;
        emptySpace.RemoveAt(randomNumber);
        searchWaysPlayer.EmptyPlayerCell(ref emptySpace, vectorPlayLocal, vectorPlayZ, Operation.Add);
        searchWaysPlayer.EmptyPlayerCell(ref emptySpace, vectorPlayLocal, vectorPlayZ, Operation.Compute);
        searchWaysPlayer.EmptyPlayerCell(ref emptySpace, vectorPlayLocal, vectorPlayX, Operation.Add);
        searchWaysPlayer.EmptyPlayerCell(ref emptySpace, vectorPlayLocal, vectorPlayX, Operation.Compute);
        
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
        if (complexity == "medium")
        {
            int number = numberEmpty * 60 / 100;
            for (int i = 0; i < number; i++)
            {
                int nuumber = emptySpace.Count;
                int rannumber = Random.Range(0, nuumber - 1);
                Instantiate(cubebox, emptySpace[rannumber], Quaternion.identity);
                emptySpace.RemoveAt(rannumber);
            }
        }
        if (complexity == "hard")
        {
            int number = numberEmpty * 80 / 100;
            for (int i = 0; i < number; i++)
            {
                int nuumber = emptySpace.Count;
                int rannumber = Random.Range(0, nuumber - 1);
                Instantiate(cubebox, emptySpace[rannumber], Quaternion.identity);
                emptySpace.RemoveAt(rannumber);
            }
        }
        if (complexity == "t")
        {
            int number = numberEmpty * 100 / 100;
            for (int i = 0; i < number; i++)
            {
                int nuumber = emptySpace.Count;
                int rannumber = Random.Range(0, nuumber - 1);
                Instantiate(cubebox, emptySpace[rannumber], Quaternion.identity);
                emptySpace.RemoveAt(rannumber);
            }
        }
    }
}
