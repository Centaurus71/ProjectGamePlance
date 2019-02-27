using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    private float sensitiveX = 4f;
    private float sensitiveY = 4f;
    private float rotationMinX = -360;
    private float rotationMaxX = 360;
    private float rotationMinY = -60;
    private float rotationMaxY = 60;
    private Quaternion startRot;
    private float startRotationX = 0;
    private float startRotationY = 0;

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb)
        {
            rb.freezeRotation = true;
        }
        startRot = transform.localRotation;
    }

    private void FixedUpdate()
    {
        startRotationX += Input.GetAxis("Mouse X") * sensitiveX;
        startRotationY += Input.GetAxis("Mouse Y") * sensitiveY;
        startRotationX = startRotationX % 360;
        startRotationY = startRotationY % 360;
        startRotationX = Mathf.Clamp(startRotationX, rotationMinX, rotationMaxX);
        startRotationY = Mathf.Clamp(startRotationY, rotationMinY, rotationMaxY);
        Quaternion xQuaternion = Quaternion.AngleAxis(startRotationX, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis(startRotationY, Vector3.left);
        transform.localRotation = startRot * xQuaternion * yQuaternion;
    }
}
