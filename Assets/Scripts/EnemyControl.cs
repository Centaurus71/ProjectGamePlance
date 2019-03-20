using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    LoadObject objectEnemy = new LoadObject();
    GameObject enemy;
    Vector3 localPosition;
    Vector3 moveVectorX = new Vector3(1, 0, 0);
    Vector3 moveVectorZ = new Vector3(0, 0, 11);
    bool statusCorution = false;

    private void Start()
    {

    }

    IEnumerator MoveEnemy()
    {
        statusCorution = true;
        for (int i = 0; i < 11; i++)
        {
            yield return new WaitForSeconds(0.04f);
            transform.position += moveVectorX;
        }
        statusCorution = false;
    }

    public void LoadEnemy(List<Vector3> emptySpace)
    {
        enemy = objectEnemy.LoadEnemy();
        int nubmerSpace = emptySpace.Count;
        int randomNumber = Random.Range(0, nubmerSpace - 1);
        Instantiate(enemy, emptySpace[randomNumber], Quaternion.identity);
        localPosition = emptySpace[randomNumber];
        emptySpace.RemoveAt(randomNumber);
    }

    private void FixedUpdate()
    {
        //print(RoundingVector(PlayerControl.upPlayVector));
    }

    private void Update()
    {
        /*if (statusCorution == false)
        {
            StartCoroutine(MoveEnemy());
        }*/
    }

    private Vector3 RoundingVector(Vector3 vectorPlay)
    {
        int x = (int)(vectorPlay.x / 11) * 11;
        int z = (int)(vectorPlay.z / 11) * 11;
        Vector3 roundVector = new Vector3(x, 5, z);
        return roundVector;
    }
}
