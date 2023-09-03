using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{

    [SerializeField] Canvas bloodSplatterCanvas;
    [SerializeField] float displayTime = 0.3f;


    void Start()
    {
        bloodSplatterCanvas.enabled = false;
    }

    public void ShowBloodSplatterCanvas()
    {
        StartCoroutine(ShowBloodSplatter());
    }
    
    IEnumerator ShowBloodSplatter()
    {
        bloodSplatterCanvas.enabled = true;
        yield return new WaitForSeconds(displayTime);
        bloodSplatterCanvas.enabled = false;
    }
}
