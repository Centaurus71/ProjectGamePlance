using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Field : MonoBehaviour
{
    const int cubeScaleX = 10;
    const int cubeScaleZ = 10;
    const int cubeScaleY = 5;
    const float ratioField = 0.1f;
    public static List<Vector3> emptySpace = new List<Vector3>();

    public void StartLoadField (int widthX, int lengthY, Level level)
    {
        LoadObject loadObject = new LoadObject();
        GameObject plane = loadObject.LoadPlane();
        GameObject wall = loadObject.LoadCube();
        GameObject cylinder = loadObject.LoadCylinder();
        GameObject cubebox = loadObject.LoadBox();
        GameObject player = loadObject.LoadPlayer();
        //List<Vector3> emptySpace = new List<Vector3>();

        int width = widthX;
        int length = lengthY;
        int indexX = 0;
        int indexZ = 0;

        LoadWall(wall, emptySpace, width, length, ref indexX, ref indexZ);
        int numberEmpty = emptySpace.Count;

        LoadField(plane, width, length, indexX, indexZ);

        int randomNumber = Random.Range(0, numberEmpty - 1);
        Instantiate(player, emptySpace[randomNumber], Quaternion.identity);

        Enemy enemy = new Enemy();
        enemy.LoadEnemy(emptySpace);

        

        Box Box = new Box();
        Box.LoadBox(emptySpace, randomNumber, level);
    }

    private static void LoadField(GameObject plane, int width, int length, int indexX, int indexZ)
    {
        int fildCenterX = 0;
        int fildCenterY = 0;
        fildCenterX = ((width - 1) * 10 + indexX) / 2;
        fildCenterY = ((length - 1) * 10 + indexZ - 1) / 2;
        plane.transform.localScale = new Vector3(width + (ratioField * width), 1, length + (ratioField * length));
        Instantiate(plane, new Vector3(fildCenterX, 0, fildCenterY), Quaternion.identity);
    }

    private static void LoadWall(GameObject wall, List<Vector3> emptySpace, int width, int length, ref int indexX, ref int indexZ)
    {
        for (int x = 0; x < width; x++)
        {
            indexZ = 0;
            for (int z = 0; z < length; z++)
            {
                if (x == 0 | z == 0 | x == width - 1 | z == length - 1 | (x % 2 == 0 & z % 2 == 0))
                {
                    Instantiate(wall, new Vector3(x * cubeScaleX + indexX, cubeScaleY, z * cubeScaleZ + indexZ), Quaternion.identity);
                }
                else if ((x % 2 != 0 & z % 2 != 0) | (x % 2 != 0 & z % 2 == 0) | (x % 2 == 0 & z % 2 != 0))
                {
                    emptySpace.Add(new Vector3(x * cubeScaleX + indexX, cubeScaleY, z * cubeScaleZ + indexZ));
                }
                indexZ++;
            }
            indexX++;
        }
    }
}
