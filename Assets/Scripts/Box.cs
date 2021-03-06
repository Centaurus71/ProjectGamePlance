﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Level
{
    fieldNull = 0,
    easy = 40,
    normal = 60,
    hard = 80,
    test = 100
}

public class Box : MonoBehaviour
{
    public void LoadBox(List<Vector3> emptySpace, int randomNumber, Level level)
    {

        LoadObject loadboxx = new LoadObject();
        GameObject cubebox = loadboxx.LoadBox();
        WaysPlayer waysPlayer = new WaysPlayer();
        Vector3 vectorPlayZ = new Vector3(0, 0, 11);
        Vector3 vectorPlayX = new Vector3(11, 0, 0);
        Vector3 vectorPlayLocal = emptySpace[randomNumber];

        int numberEmptyCall;
        emptySpace.RemoveAt(randomNumber);
        waysPlayer.SearchWayzPlayer(ref emptySpace, vectorPlayLocal, vectorPlayZ, vectorPlayX, Operation.Add);
        waysPlayer.SearchWayzPlayer(ref emptySpace, vectorPlayLocal, vectorPlayZ, vectorPlayX, Operation.Compute);
        waysPlayer.SearchWayzPlayer(ref emptySpace, vectorPlayLocal, vectorPlayX, vectorPlayZ, Operation.Add);
        waysPlayer.SearchWayzPlayer(ref emptySpace, vectorPlayLocal, vectorPlayX, vectorPlayZ, Operation.Compute);

        numberEmptyCall = emptySpace.Count;
        int numberBox = numberEmptyCall * level.GetHashCode() / 100;
        for (int i = 0; i < numberBox; i++)
        {
            int ii = emptySpace.Count;
            int ranNumber = Random.Range(0, ii - 1);
            Instantiate(cubebox, emptySpace[ranNumber], Quaternion.identity);
            emptySpace.RemoveAt(ranNumber);
        }

        foreach (Vector3 vector in WaysPlayer.Костылек)
        {
            Field.emptySpace.Add(vector);
        }
    }
}
