using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera fpsCamera;
    [SerializeField] float zoomedOut = 40f;
    [SerializeField] float zoomedIn = 20f;

    [SerializeField] bool zoomToggle = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!zoomToggle)
            {
                zoomToggle = true;
                fpsCamera.m_Lens.FieldOfView = zoomedIn;
            }
            else
            {
                zoomToggle = false;
                fpsCamera.m_Lens.FieldOfView = zoomedOut;
            }
        }    
    }
}
// m_Lens.FieldOfView