using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    //public Transform target;
    LoadObject loadObject = new LoadObject();
    public static List<GameObject> listBomb = new List<GameObject>();
    const int numberBomb = 5;
    bool statusCollisions = false;

    public void LoadBomb(Vector3 vestorBomb)
    {
        GameObject bomb = loadObject.LoadBomd();
        if (listBomb.Count < numberBomb)
        {
            listBomb.Add(bomb);
            Instantiate(bomb, vestorBomb, Quaternion.identity);
        }
        else
        {
            print("No bomb");
        }
    }
}
