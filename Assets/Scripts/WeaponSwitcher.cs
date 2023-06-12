using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;
    int previousWeapon;

    void Start()
    {
        SetWeaponActive();
    }

    void Update()
    {
        previousWeapon = currentWeapon;

        processKeyInput();
        processScrollWheel();

        if (previousWeapon != currentWeapon) SetWeaponActive();
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            weaponIndex++;
        }
    }

    private void processKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) currentWeapon = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2)) currentWeapon = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3)) currentWeapon = 2;
    }

    // TODO: Test with proper mouse
    private void processScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentWeapon >= transform.childCount - 1) currentWeapon = 0;
            else currentWeapon++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentWeapon <= 0) currentWeapon = 2;
            else currentWeapon--;
        }
    }

}
