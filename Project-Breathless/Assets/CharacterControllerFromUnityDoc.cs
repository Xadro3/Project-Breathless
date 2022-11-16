using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerFromUnityDoc : MonoBehaviour
{

    private CharacterController controller;
    public GameObject[] CameraArray;
    private int cameraNumber;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private void Start()
    {
        foreach (var c in CameraArray)
        {
            c.SetActive(false);
        }
        CameraArray[0].SetActive(true);
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }


        if (Input.GetKey(KeyCode.Q) && cameraNumber ==0)
        {
            CameraArray[cameraNumber].GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineOrbitalTransposer>().m_XAxis.Value -= 1f;

        }

        if (Input.GetKey(KeyCode.E) && cameraNumber == 0)
        {
            CameraArray[cameraNumber].GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineOrbitalTransposer>().m_XAxis.Value += 1f;

        }


        if (Input.GetKeyDown(KeyCode.V) && cameraNumber != CameraArray.Length-1)
        {
            CameraArray[cameraNumber].SetActive(false);
            cameraNumber++;
            CameraArray[cameraNumber].SetActive(true);
            
        }

        if (Input.GetKeyDown(KeyCode.C) && cameraNumber != 0)
        {
            CameraArray[cameraNumber].SetActive(false);
            cameraNumber--;
            CameraArray[cameraNumber].SetActive(true);
        }

        if (Input.mouseScrollDelta.y >= 0.1 && cameraNumber == 0)
        {
            CameraArray[cameraNumber].GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineOrbitalTransposer>().m_FollowOffset.y -= 0.5f; 
        }

        if (Input.mouseScrollDelta.y <= -0.1 && cameraNumber == 0)
        {
            CameraArray[cameraNumber].GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineOrbitalTransposer>().m_FollowOffset.y += 0.5f;
        }

        if (Input.mouseScrollDelta.y >= 0.1 && cameraNumber != 0)
        {
            CameraArray[cameraNumber].GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance -= 0.5f;
        }

        if (Input.mouseScrollDelta.y <= - 0.1 && cameraNumber != 0)
        {
            CameraArray[cameraNumber].GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance += 0.5f;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}

