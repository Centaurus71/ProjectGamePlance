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
        GameObject box = loadwall.LoadCube();
        GameObject cubebox = loadwall.Cubebox();
        
        int qq = 0;
        int qqq = 0;
        int width = widthx;  //ширина
        int length = lengthy;  //длина
        int ix = 0;
        int iz = 0;
        for (int x = 0; x < width; x++)
        {
            int n = Random.Range(0, 10);
            iz = 0;
            for (int z = 0; z < length; z++)
            {
                int nn = Random.Range(0,10);
                if (x == 0 | z == 0 | x == width - 1 | z == length - 1 )
                {
                    Instantiate(wall, new Vector3(x * 10 + ix, 5, z * 10 + iz), Quaternion.identity); //установка стен
                }
                else if (x % 2 == 0 & z % 2 == 0)
                {
                    Instantiate(box, new Vector3(x * 10 + ix, 5, z * 10 + iz), Quaternion.identity); //установка препядствий
                }
               /* else if ((x % 2 != 0 & z % 2 != 0) | (x%2 == 0 & z %2 !=0) & n == 1)
                {
                    Instantiate(cubebox, new Vector3(x * 10 + ix, 2, z * 10 + iz), Quaternion.identity); //установка препядствий
                }*/
                /*else if ((x % 2 != 0 & z % 2 != 0) | (x % 2 != 0 & z % 2 == 0) & (x != 1 & z != 1) & (nn == 1))
                {
                    Instantiate(cubebox, new Vector3(x * 10 + ix, 2, z * 10 + iz), Quaternion.identity); //установка препядствий
                }*/
                iz++;
            }
            ix++;
        }
        //определение координат центра поля
        qq = ((width -1)  * 10 + ix ) /2;
        qqq = ((length-1) * 10 + iz - 1) / 2;
        //опредление ширины поля
        plane.transform.localScale = new Vector3(width + (0.1f*width), 1, length + (0.1f*length));
        //загрузка поля
        Instantiate(plane, new Vector3(qq, 0, qqq), Quaternion.identity);
    }
}
