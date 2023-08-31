using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float maximumIntensity = 4f;
    [SerializeField] float maximumAngle = 60f;

    [SerializeField] float lightDecay = 0.1f;
    [SerializeField] float angleDecay = 0.1f;
    [SerializeField] float minimumAngle = 30f;
    

    Light myLight;

    private void Start()
    {
        myLight = GetComponent<Light>();
        myLight.intensity = maximumIntensity;
        myLight.spotAngle = maximumAngle;
    }

    private void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    private void DecreaseLightIntensity()
    {
        if (myLight.spotAngle > minimumAngle)
        {
            myLight.spotAngle -= angleDecay * Time.deltaTime;
        }
    }

    private void DecreaseLightAngle()
    {
        myLight.intensity -= lightDecay * Time.deltaTime;
    }

    public void RechargeFlashlight()
    {
        myLight.intensity = maximumIntensity;
        myLight.spotAngle = maximumAngle;
    }
}
