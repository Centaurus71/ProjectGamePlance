using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadObject : MonoBehaviour
{
    public GameObject LoadPlane()
    {
        GameObject plane = Resources.Load("Prefaps/Plane") as GameObject;
        return plane;
    }
    public GameObject LoadCube()
    {
        GameObject cube = Resources.Load("Prefaps/Cube") as GameObject;
        return cube;
    }

    public GameObject LoadLight()
    {
        GameObject light = Resources.Load("Prefaps/Light") as GameObject;
        return light;
    }

    public GameObject LoadCylinder()
    {
        GameObject cylinder = Resources.Load("Prefaps/Cylinder") as GameObject;
        return cylinder;
    }

    public GameObject LoadBox()
    {
        GameObject cubebox = Resources.Load("Prefaps/Cubebox") as GameObject;
        return cubebox;
    }

    public GameObject LoadPlayer()
    {
        GameObject player = Resources.Load("Prefaps/Other/Player") as GameObject;
        return player;
    }

    public GameObject LoadBomd()
    {
        GameObject bomb = Resources.Load("Prefaps/Sphere") as GameObject;
        return bomb;
    }

    public GameObject LoadEnemy()
    {
        GameObject enemy = Resources.Load("Prefaps/Other/Enemy") as GameObject;
        return enemy;
    }
}
