using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseWeapons : MonoBehaviour
{
   [SerializeField] Attack attack;
   [SerializeField] private float FireRate;
   [SerializeField] private Transform FirePos;
   [SerializeField] private int maxCount;
   private int ammoCount;
   public int GetAmmoCount
   {
       get => ammoCount;
   }
   [SerializeField] private AudioClip _audioClip;
   
   // public int GetCurrentWeaponAmmoCount
   //  {
   //      get => ammoCount;
   //      set => ammoCount = value;
   //  }
   void Awake()
   {
       ammoCount = maxCount;
       attack.maxAmmo = maxCount;
   }
    void Update()
    {
        SelectWeapons();
    }
    void OnEnable()  // Bu kod obje aktif olduğunda çalışır.
    {
        attack.GetFireRate = FireRate;
        attack.GetAmmo = ammoCount;
        attack.GetAudioClip = _audioClip;
    }
    public void SelectWeapons()
    {
        switch(Input.inputString)
        {
            case "1":
                // Silahların kalan mermi sayılarını tutmamız için gerekli kod.
                
                // GetCurrentWeaponAmmoCount = attack.weapons[1].gameObject.GetComponent<Attack>().GetAmmo;
                // GetCurrentWeaponAmmoCount = attack.weapons[2].gameObject.GetComponent<Attack>().GetAmmo;
                attack.weapons[0].SetActive(true);
                attack.weapons[1].SetActive(false);
                attack.weapons[2].SetActive(false);
                break;
            case "2":
                attack.weapons[1].SetActive(true);
                 attack.weapons[0].SetActive(false);
                 attack.weapons[2].SetActive(false);
                break;
            case "3":
                attack.weapons[2].SetActive(true);
                 attack.weapons[0].SetActive(false);
                 attack.weapons[1].SetActive(false);
                break;
            default:
                break;
        }
    }
}
