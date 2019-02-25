using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startgame : LoadObject
{   
    // Start is called before the first frame update
    void Start()
    {
        LoadWall load = new LoadWall();
        load.StartLoadWall(17,19);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
