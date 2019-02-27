using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadObject : MonoBehaviour
{
    public GameObject loadPlane()
    {
        GameObject plane = Resources.Load("Prefaps/Plane") as GameObject;
        return plane;
    }
    public GameObject loadCube()
    {
        GameObject cube = Resources.Load("Prefaps/Cube") as GameObject;
        return cube;
    }

    public GameObject loadLight()
    {
        GameObject light = Resources.Load("Prefaps/Light") as GameObject;
        return light;
    }

    public GameObject loadcylinder()
    {
        GameObject cylinder = Resources.Load("Prefaps/Cylinder") as GameObject;
        return cylinder;
    }

    public GameObject loadcubebox()
    {
        GameObject cubebox = Resources.Load("Prefaps/Cubebox") as GameObject;
        return cubebox;
    }

    public GameObject loadPlayer()
    {
        GameObject player = Resources.Load("Prefaps/Other/Player") as GameObject;
        return player;
    }
}
