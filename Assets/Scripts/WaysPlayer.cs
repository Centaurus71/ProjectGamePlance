using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Operation
{
    Add,
    Compute
}

public class WaysPlayer : MonoBehaviour
{
    public static List<Vector3> Костылек = new List<Vector3>();
    public void SearchWayzPlayer (ref List<Vector3> emptySpace, Vector3 vectorPlay, Vector3 vectorDirection, Vector3 vectorCorrect, Operation op)
    {
        Костылек.Add(vectorPlay);
        if (op == Operation.Add)
        {
            for (int i = 0; i < 2; i++)
            {
                vectorPlay += vectorDirection;
                if (emptySpace.IndexOf(vectorPlay) == -1)
                {
                    vectorPlay += vectorCorrect;
                    Костылек.Add(vectorPlay);
                    emptySpace.Remove(vectorPlay);
                }
                else
                {
                    Костылек.Add(vectorPlay);
                    emptySpace.Remove(vectorPlay);
                }
            }
        }
        else if (op == Operation.Compute)
        {
            for (int i = 0; i < 2; i++)
            {
                vectorPlay -= vectorDirection;
                if (emptySpace.IndexOf(vectorPlay) == -1)
                {
                    vectorPlay -= vectorCorrect;
                    Костылек.Add(vectorPlay);
                    emptySpace.Remove(vectorPlay);
                }
                else
                {
                    Костылек.Add(vectorPlay);
                    emptySpace.Remove(vectorPlay);
                }
            }
        }
    }
}
