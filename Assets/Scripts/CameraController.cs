using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform focus;
    public Vector3 offset;
    public bool useOffsetValues;
    public float rotateCamera;
    public Transform pivot;
    public float maxViewAngle;
    public float minViewAngle;
    public bool invertY;

    void Start()
    {
        if (!(useOffsetValues))
        {
            offset = focus.position - transform.position;
        }

        pivot.transform.position = focus.transform.position;
        pivot.transform.parent = focus.transform;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        //Get X position of mouse and rotate to focus
        float horizontal = Input.GetAxis("Mouse X") * rotateCamera;
        focus.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Mouse Y") * rotateCamera;

        if(invertY)
        {
            pivot.Rotate(vertical, 0, 0);
        }
        else
        {
            pivot.Rotate(-vertical, 0, 0);
        }

        if(pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);
        }
        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f + minViewAngle)
        {
            pivot.rotation = Quaternion.Euler(360f + minViewAngle, 0, 0);
        }

        float desiredYAngle = focus.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = focus.position - (rotation * offset);

        if(transform.position.y < focus.position.y)
        {
            transform.position = new Vector3(transform.position.x, focus.position.y , transform.position.z);
        }
        transform.LookAt(focus);
    }
}
