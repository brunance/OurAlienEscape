using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    private Transform cameraSwitch;

    void Start()
    {
        cameraSwitch = GetComponent<Transform>();
    }

    void Update()
    {
        CameraRotation();
    }

    void CameraRotation()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            transform.eulerAngles = cameraSwitch.transform.position += new Vector3(0f, 0f, -90f);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            transform.eulerAngles = cameraSwitch.transform.position += new Vector3(0f, 0f, 90f);
        }
    }
}
