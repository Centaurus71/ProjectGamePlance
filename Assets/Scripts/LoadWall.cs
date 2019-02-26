using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadWall : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartLoadWall(int widthx, int lengthy)
    {
        LoadObject loadwall = new LoadObject();
        GameObject plane = loadwall.LoadPlane();
        GameObject wall = loadwall.LoadCube();
        GameObject cylinder = loadwall.Cylinder();
        GameObject cubebox = loadwall.Cubebox();
        GameObject player = loadwall.LoadPlayer();
        List <Vector3> emptySpace = new List<Vector3>();
        string complexity = "lung";  // доступные уровни lung, medium, hard, t


        int fildCenterX = 0;
        int fildCenterY = 0;
        int width = widthx;  //ширина
        int length = lengthy;  //длина
        int ix = 0;
        int iz = 0;
        for (int x = 0; x < width; x++)
        {
            iz = 0;
            for (int z = 0; z < length; z++)
            {
                if (x == 0 | z == 0 | x == width - 1 | z == length - 1 )
                {
                    Instantiate(wall, new Vector3(x * 10 + ix, 5, z * 10 + iz), Quaternion.identity); //установка стен
                }
                else if (x % 2 == 0 & z % 2 == 0)
                {
                    Instantiate(wall, new Vector3(x * 10 + ix, 5, z * 10 + iz), Quaternion.identity); //установка стен внутри поля
                }
                /*else if (x%2 == 0 & z %2 !=0)
                {
                    emptySpace.Add(new Vector3 (x * 10 + ix, 5, z * 10 + iz));
                }
                else if (x % 2 != 0 & z % 2 == 0)
                {
                    emptySpace.Add(new Vector3(x * 10 + ix, 5, z * 10 + iz));
                }*/
                /* else if ((x % 2 != 0 & z % 2 != 0) | (x % 2 != 0 & z % 2 == 0) & (x != 1 & z != 1))
                {
                    emptySpace.Add(new Vector3(x * 10 + ix, 5, z * 10 + iz));
                }*/

                else if ((x % 2 != 0 & z % 2 != 0) | (x % 2 != 0 & z % 2 == 0) | (x % 2 == 0 & z % 2 != 0))
                {
                    emptySpace.Add(new Vector3(x * 10 + ix, 5, z * 10 + iz));
                }
                iz++;
            }
            ix++;
        }
        int numberEmpty = emptySpace.Count;
        //определение координат центра поля
        fildCenterX = ((width -1)  * 10 + ix ) /2;
        fildCenterY = ((length-1) * 10 + iz - 1) / 2;
        //опредление ширины поля
        plane.transform.localScale = new Vector3(width + (0.1f*width), 1, length + (0.1f*length));
        //загрузка поля
        Instantiate(plane, new Vector3(fildCenterX, 0, fildCenterY), Quaternion.identity);
        //загрузка player
        int randomNumber = Random.Range(0, numberEmpty - 1);
        Instantiate(player, emptySpace[randomNumber], Quaternion.identity);

        LoadBox loadBox = new LoadBox();
        loadBox.loadBox(emptySpace, randomNumber, complexity);
    }
}
