using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoveEnemy : MonoBehaviour
{
    Vector3 localVectorEnemy;
    Vector3 vectorMoveZ = new Vector3(0, 0, 11);
    Vector3 vectorMoveX = new Vector3(11, 0, 0);

    List<Vector3> testListVectorPlusZ = new List<Vector3>();
    List<Vector3> testListVectorPlusX = new List<Vector3>();
    List<Vector3> testListVectorMinusZ = new List<Vector3>();
    List<Vector3> testListVectorMinusX = new List<Vector3>();

    List<Vector3> occupiedCells = new List<Vector3>();
    List<Vector3> сканточек = new List<Vector3>();
    Queue queue = new Queue();
    LoadObject objectEnemy = new LoadObject();
    GameObject enemy;
    bool startMoveEnemy = false;
    bool statusOff = false;
    bool qw = false;
    int number = 0;
    const int cellSize = 11;
    LoadObject loadObject = new LoadObject();

    // Start is called before the first frame update
    void Start()
    {
        localVectorEnemy = transform.localPosition;
        сканточек.Add(localVectorEnemy);
    }

    private void Update()
    {
        /*if (qw == false & number == 0)
        {
            StartMoveEnemyByCells(localVectorEnemy);
        }*/
            
    }

    public void LoadEnemy(List<Vector3> emptySpace)
    {
        enemy = objectEnemy.LoadEnemy();
        int nubmerSpace = emptySpace.Count;
        int randomNumber = Random.Range(0, nubmerSpace - 1);
        Instantiate(enemy, emptySpace[randomNumber], Quaternion.identity);
        localVectorEnemy = emptySpace[randomNumber];
        emptySpace.RemoveAt(randomNumber);
    }


    void StartMoveEnemyByCells(Vector3 localVectorEnemy)
    {
        number++;
        GameObject game = loadObject.LoadPoint();
        qw = true;
        if (startMoveEnemy == false)
        {
            Vector3 moveVectorPlusZ = localVectorEnemy + vectorMoveZ;
            Vector3 moveVectorMinusZ = localVectorEnemy - vectorMoveZ;
            Vector3 moveVectorPlusX = localVectorEnemy + vectorMoveX;
            Vector3 moveVectorMinusX = localVectorEnemy - vectorMoveX;

            if (Field.emptySpace.IndexOf(moveVectorPlusZ) != -1)
            {
                сканточек.Add(moveVectorPlusZ);
                testListVectorPlusZ.Add(moveVectorPlusZ);
                queue.Enqueue(moveVectorPlusZ);
                Instantiate(game, moveVectorPlusZ, Quaternion.identity);
            }
            if (Field.emptySpace.IndexOf(moveVectorPlusX) != -1)
            {
                сканточек.Add(moveVectorPlusX);
                testListVectorPlusX.Add(moveVectorPlusX);
                queue.Enqueue(moveVectorPlusX);
                Instantiate(game, moveVectorPlusX, Quaternion.identity);
            }
            if (Field.emptySpace.IndexOf(moveVectorMinusZ) != -1)
            {
                сканточек.Add(moveVectorMinusZ);
                testListVectorMinusZ.Add(moveVectorMinusZ);
                queue.Enqueue(moveVectorMinusZ);
                Instantiate(game, moveVectorMinusZ, Quaternion.identity);
            }
            if (Field.emptySpace.IndexOf(moveVectorMinusX) != -1)
            {
                сканточек.Add(moveVectorMinusX);
                testListVectorMinusX.Add(moveVectorMinusX);
                queue.Enqueue(moveVectorMinusX);
                Instantiate(game, moveVectorMinusX, Quaternion.identity);
            }
            startMoveEnemy = true;
        }

        foreach (Vector3 vector in сканточек)
        {
            print("Массив " + vector);
        }
        foreach (Vector3 vector in queue)
        {
            print("Очередь " + vector);
        }
        for (;;)
        {
            Vector3 timeVector = new Vector3(0, 0, 0);
            timeVector = (Vector3) queue.Dequeue();
            Vector3 moveVectorPlusZ1 = timeVector + vectorMoveZ;
            Vector3 moveVectorMinusZ1 = timeVector - vectorMoveZ;
            Vector3 moveVectorPlusX1 = timeVector + vectorMoveX;
            Vector3 moveVectorMinusX1 = timeVector - vectorMoveX;

            print("moveVectorPlusZ1 " + moveVectorPlusZ1);
            print("moveVectorMinusZ1 " + moveVectorMinusZ1);
            print("moveVectorPlusX1 " + moveVectorPlusX1);
            print("moveVectorMinusX1 " + moveVectorMinusX1);

            if (Field.emptySpace.IndexOf(moveVectorPlusZ1) != -1)
            {
                    сканточек.Add(moveVectorPlusZ1);
                    testListVectorPlusZ.Add(moveVectorPlusZ1);
                    queue.Enqueue(moveVectorPlusZ1);
                    Instantiate(game, moveVectorPlusZ1, Quaternion.identity);

                    if (moveVectorPlusZ1 == PlayerControl.upPlayVector)
                    {
                        statusOff = true;
                        break;
                    }
               
            }
            if (Field.emptySpace.IndexOf(moveVectorPlusX1) != -1)
            {
                    сканточек.Add(moveVectorPlusX1);
                    testListVectorPlusX.Add(moveVectorPlusX1);
                    queue.Enqueue(moveVectorPlusX1);
                    Instantiate(game, moveVectorPlusX1, Quaternion.identity);

                    if (moveVectorPlusX1 == PlayerControl.upPlayVector)
                    {
                        statusOff = true;
                        break;
                    }
                
                
            }
            if (Field.emptySpace.IndexOf(moveVectorMinusZ1) != -1) 
            {
                сканточек.Add(moveVectorMinusZ1);
                testListVectorMinusZ.Add(moveVectorMinusZ1);
                queue.Enqueue(moveVectorMinusZ1);
                Instantiate(game, moveVectorMinusZ1, Quaternion.identity);
                
                if (moveVectorMinusZ1 == PlayerControl.upPlayVector)
                {
                    statusOff = true;
                    break;
                }
            }
            if (Field.emptySpace.IndexOf(moveVectorMinusX1) != -1)
            {
                сканточек.Add(moveVectorMinusX1);
                testListVectorMinusX.Add(moveVectorMinusX1);
                queue.Enqueue(moveVectorMinusX1);
                Instantiate(game, moveVectorMinusX1, Quaternion.identity);

                if (moveVectorMinusX1 == PlayerControl.upPlayVector)
                {
                    statusOff = true;
                    break;
                }
            }
        }
    }
}
