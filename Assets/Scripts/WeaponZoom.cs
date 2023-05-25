using System.Collections;
using System.Collections.Generic;
using Cinemachine;   // for CinemachineVirtualCamera
using StarterAssets;  // for FirstPersonController
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera fpsCamera;
    [SerializeField] FirstPersonController fpsController;

    [SerializeField] float zoomedOutFOV = 40f;
    [SerializeField] float zoomedInFOV = 20f;

    [SerializeField] float zoomedOutSensitivity = 4f;
    [SerializeField] float zoomedInSensitivity = 2f;

    bool zoomToggle = false;

    private void Start()
    {
        fpsController.RotationSpeed = zoomedOutSensitivity;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!zoomToggle)
            {
                zoomToggle = true;
                fpsCamera.m_Lens.FieldOfView = zoomedInFOV;
                fpsController.RotationSpeed = zoomedInSensitivity;
            }
            else
            {
                zoomToggle = false;
                fpsCamera.m_Lens.FieldOfView = zoomedOutFOV;
                fpsController.RotationSpeed = zoomedOutSensitivity;
            }
        }    
    }
}

// Cinemachine property reference:  m_Lens.FieldOfView

// FirstPersonController property reference: RotationSpeed