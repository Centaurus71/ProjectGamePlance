using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    //чувствительность мыши
    private float sensitiveX = 4f;
    private float sensitiveY = 4f;

    //ограничение по повороту камеры
    private float minX = -360;
    private float maxX = 360;
    private float minY = -60;
    private float maxY = 60;

    //стартовое положение камеры
    private Quaternion startRot;
    private float rotX = 0;
    private float rotY = 0;

    private void Start()
    {
        //отключение физики на вороте 
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb)
        {
            rb.freezeRotation = true;
        }
        //считывание положения 
        startRot = transform.localRotation;
    }

    private void FixedUpdate()
    {
        //считывание позиции
        rotX += Input.GetAxis("Mouse X") * sensitiveX;
        rotY += Input.GetAxis("Mouse Y") * sensitiveY;

        //ограничеваем угол поворота
        rotX = rotX % 360;
        rotY = rotY % 360;

        rotX = Mathf.Clamp(rotX, minX, maxX);
        rotY = Mathf.Clamp(rotY, minY, maxY);
        //посчитаем угол поворота
        Quaternion xQuaternion = Quaternion.AngleAxis(rotX, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis(rotY, Vector3.left);

        transform.localRotation = startRot * xQuaternion * yQuaternion;
    }
}
