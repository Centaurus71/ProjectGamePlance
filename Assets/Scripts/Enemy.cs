using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    LoadObject objectEnemy = new LoadObject();
    GameObject enemy;
    Vector3 localPosition;
    Vector3 moveVectorX = new Vector3(1, 0, 0);
    Vector3 moveVectorZ = new Vector3(0, 0, 11);
    private void Start()
    {
        
    }

    public void LoadEnemy (List<Vector3> emptySpace)
    {
        enemy = objectEnemy.LoadEnemy();
        int nubmerSpace = emptySpace.Count;
        int randomNumber = Random.Range(0, nubmerSpace - 1);
        Instantiate(enemy, emptySpace[randomNumber], Quaternion.identity);
        localPosition = emptySpace[randomNumber];
        emptySpace.RemoveAt(randomNumber);
    }

    private void Update()
    {
        /*localPosition -= moveVectorX;
        transform.Translate(localPosition * Time.deltaTime);
        print("sdfsdfsdf");*/
    }
}
