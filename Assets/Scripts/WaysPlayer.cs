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
    public void SearchWayzPlayer (ref List<Vector3> emptySpace, Vector3 vectorPlay, Vector3 vectorDirection, Vector3 vectorCorrect, Operation op)
    {
        if (op == Operation.Add)
        {
            for (int i = 0; i < 2; i++)
            {
                vectorPlay += vectorDirection;
                if (emptySpace.IndexOf(vectorPlay) == -1)
                {
                    vectorPlay += vectorCorrect;
                    emptySpace.Remove(vectorPlay);
                }
                else
                {
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
                    emptySpace.Remove(vectorPlay);
                }
                else
                {
                    emptySpace.Remove(vectorPlay);
                }
            }
        }
    }
}
