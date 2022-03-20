using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseWeapons : MonoBehaviour
{
   [SerializeField] Attack attack;
   [SerializeField] private float FireRate;
   [SerializeField] private GameObject FirePos;
   [SerializeField] private int ammoCount;


    
    void Update()
    {
        SelectWeapons();
    }
    void OnEnable()  // Bu kod obje aktif olduğunda çalışır.
    {
        attack.GetFireRate = FireRate;
        attack.GetAmmo = ammoCount;
    }
    void SelectWeapons()
    {
        switch(Input.inputString)
        {
            case "1":
                attack.weapons[0].SetActive(true);
                attack.weapons[1].SetActive(false);
                break;
            case "2":
                 attack.weapons[1].SetActive(true);
                 attack.weapons[0].SetActive(false);
                break;
            case "3":

                break;
            default:
                break;
        }
    }
}
