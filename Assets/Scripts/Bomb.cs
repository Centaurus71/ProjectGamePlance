using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    LoadObject loadObject = new LoadObject();
    public static List<GameObject> listBomb = new List<GameObject>();
    const int numberBomb = 5;
   
    
    
    public void LoadBomb(Vector3 vestorBomb)
    {
        GameObject bomb= loadObject.LoadBomd();
        if (listBomb.Count < numberBomb)
        {

            listBomb.Add(bomb);
            Instantiate(bomb, RoundingVector(vestorBomb), Quaternion.identity);
        }
        else
        {
            print("No bomb");
        }
    }

    private Vector3 RoundingVector(Vector3 vectorBomb)
    {
        int x = (int) (vectorBomb.x / 11) * 11;
        int z = (int)(vectorBomb.z / 11) * 11;
        Vector3 roundVector = new Vector3(x, 5, z);
        return roundVector;
    }
}
