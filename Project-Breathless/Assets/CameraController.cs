using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    
    private float rotationDirection;
    public float rotationSpeed;
    private float rotationTemp;
    private float zoomDirection;
    public float zoomSpeed;
    public float maxZoomMeters;
    public float minZoomMeters;
    private float zoomTemp;

    

    void Update()
    {
        CameraRotate();
        CameraZoom();

       

    }

    void CameraRotate()
    {
        rotationDirection = 0f;

        if (Input.GetKey(KeyCode.Q))
        {
            rotationDirection = -1f;
        }

        if (Input.GetKey(KeyCode.E))
        {
            rotationDirection = 1f;
        }
        GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineOrbitalTransposer>().m_XAxis.m_InputAxisValue = rotationDirection * rotationSpeed;
    }

    void CameraZoom()
    {
        zoomDirection = 0f;

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            zoomDirection = -1f;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            zoomDirection = 1f;
        }
        
        GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = Mathf.Clamp((GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView + (zoomDirection * zoomSpeed)), maxZoomMeters, minZoomMeters);

    }


}
