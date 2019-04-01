using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gains : MonoBehaviour
{
    LoadObject objectGains = new LoadObject();
    GameObject gainsSpeed;
    GameObject gainsWall;


    public void LoadGains (List <Vector3> emptySpace)
    {
        gainsSpeed = objectGains.LoadGainsSpeed();
        gainsWall  = objectGains.LoadGainsWall(); 
        int numderEmptySpace = emptySpace.Count;
        int numderRandom = Random.Range(0,numderEmptySpace-1);
        Instantiate(gainsSpeed, emptySpace[numderRandom], Quaternion.identity);
        numderEmptySpace = emptySpace.Count;
        numderRandom = Random.Range(0, numderEmptySpace - 1);
        Instantiate(gainsWall, emptySpace[numderRandom], Quaternion.identity);
    }
    
    void Update()
    {
        
    }
}
