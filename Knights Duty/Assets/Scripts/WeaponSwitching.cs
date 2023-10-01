using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    int weaponSelected = 1;

    [SerializeField]
    GameObject Sword, Shield, Melee;


    Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        SwapWeapon (1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(weaponSelected != 1)
            {
                SwapWeapon(1);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (weaponSelected != 2)
            {
                SwapWeapon(2);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (weaponSelected != 3)
            {
                SwapWeapon(3);
            }
        }

        if (Input.GetMouseButton(0) && weaponSelected == 1)
        {
            anim.SetBool("SA1", true);
        }
        else
        {
            anim.SetBool("SA1", false);
        }

        if (Input.GetMouseButton(1) && weaponSelected == 1)
        {
            anim.SetBool("SA2", true);
        }
        else
        {
            anim.SetBool("SA2", false);
        }

        if (Input.GetMouseButton(0) && weaponSelected == 2)
        {
            anim.SetBool("SHA1", true);
        }
        else
        {
            anim.SetBool("SHA1", false);
        }

        if (Input.GetMouseButton(1) && weaponSelected == 2)
        {
            anim.SetBool("SHA2", true);
        }
        else
        {
            anim.SetBool("SHA2", false);
        }
    }

    void SwapWeapon(int weaponType)
    {
        if(weaponType == 1)
        {
            Sword.SetActive(true);
            Shield.SetActive(false);
            Melee.SetActive(false);

            weaponSelected = 1;
            anim.SetInteger("weaponType", weaponType);
            anim.SetTrigger("weaponSwitchTrigger");
        }

        if (weaponType == 2)
        {
            Sword.SetActive(false);
            Shield.SetActive(true);
            Melee.SetActive(false);

            weaponSelected = 2;
            anim.SetInteger("weaponType", weaponType);
            anim.SetTrigger("weaponSwitchTrigger");
        }

        if (weaponType == 3)
        {
            Sword.SetActive(false);
            Shield.SetActive(false);
            Melee.SetActive(true);

            weaponSelected = 3;
            anim.SetInteger("weaponType", weaponType);
            anim.SetTrigger("weaponSwitchTrigger");
        }
    }
}
