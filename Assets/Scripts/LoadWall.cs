using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadWall : MonoBehaviour
{
    public void StartLoadWall(int widthX, int lengthY, string complexity1)
    {
        LoadObject loadObject = new LoadObject();
        GameObject plane = loadObject.loadPlane();
        GameObject wall = loadObject.loadCube();
        GameObject cylinder = loadObject.loadcylinder();
        GameObject cubebox = loadObject.loadcubebox();
        GameObject player = loadObject.loadPlayer();
        List <Vector3> emptySpace = new List<Vector3>();
        string complexity = complexity1; 


        int fildCenterX = 0;
        int fildCenterY = 0;
        int width = widthX;  
        int length = lengthY; 
        int ix = 0;
        int iz = 0;
        for (int x = 0; x < width; x++)
        {
            iz = 0;
            for (int z = 0; z < length; z++)
            {
                if (x == 0 | z == 0 | x == width - 1 | z == length - 1 | (x % 2 == 0 & z % 2 == 0))
                {
                    Instantiate(wall, new Vector3(x * 10 + ix, 5, z * 10 + iz), Quaternion.identity); 
                }
                else if ((x % 2 != 0 & z % 2 != 0) | (x % 2 != 0 & z % 2 == 0) | (x % 2 == 0 & z % 2 != 0))
                {
                    emptySpace.Add(new Vector3(x * 10 + ix, 5, z * 10 + iz));
                }
                iz++;
            }
            ix++;
        }
        int numberEmpty = emptySpace.Count;
        fildCenterX = ((width -1)  * 10 + ix ) /2;
        fildCenterY = ((length-1) * 10 + iz - 1) / 2;
        plane.transform.localScale = new Vector3(width + (0.1f*width), 1, length + (0.1f*length));
        Instantiate(plane, new Vector3(fildCenterX, 0, fildCenterY), Quaternion.identity);
        int randomNumber = Random.Range(0, numberEmpty - 1);
        Instantiate(player, emptySpace[randomNumber], Quaternion.identity);

        LoadBox Box = new LoadBox();
        Box.loadBox(emptySpace, randomNumber, complexity);
    }
}
