using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Operation
{
    Add,
    Compute
}

public class SearchWaysPlayer : MonoBehaviour
{
    public void EmptyPlayerCell(ref List<Vector3> emptySpace, Vector3 vectorPlay, Vector3 vectorDirection, Operation op)
    {
        if (op == Operation.Add)
        {
            for (int i = 0; i < 3; i++)
            {
                vectorPlay = vectorPlay + vectorDirection;
                if (emptySpace.IndexOf(vectorPlay) == -1)
                {
                    break;
                }
                else
                {
                    emptySpace.Remove(vectorPlay);
                }
            }
        }
        else if (op == Operation.Compute)
        {
            for (int i = 0; i < 3; i++)
            {
                vectorPlay = vectorPlay - vectorDirection;
                if (emptySpace.IndexOf(vectorPlay) == -1)
                {
                    break;
                }
                else
                {
                    emptySpace.Remove(vectorPlay);
                }
            }
        }
    }
}
