using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{   
    // Start is called before the first frame update
    void Start()
    {
        Field load = new Field();
        load.StartLoadField(15,21,Level.fieldNull);    // доступные уровни easy, medium, hard, test
    }
}
