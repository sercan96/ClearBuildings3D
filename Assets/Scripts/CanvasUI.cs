using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;


public class CanvasUI : MonoBehaviour
{
    public Image healthImage;
    public Image AmmoFill;

    private Attack _playerAmmo;
    private Target _playerHealth;
    private ChooseWeapons _chooseWeapons;
    private int healthFillAmaount = 10;
    void Start()
    {
        _playerAmmo = GameObject.FindWithTag("Player").GetComponent<Attack>(); // player ait Attcak scriptini çektim.
        _playerHealth = _playerAmmo.GetComponent<Target>();
        _chooseWeapons = _playerAmmo.GetComponent<ChooseWeapons>();
        
    }
    void Update()
    {
        UpdateAmmoFill();
        UpdateHealthFill();
    }

    private void UpdateAmmoFill()
    {
        AmmoFill.fillAmount = (float) _playerAmmo.GetAmmo /_playerAmmo.GetClipSize; // iki değerin oranı 1 olmalı(FillAmaunt max. 1)
    }

    private void UpdateHealthFill()
    {
        healthImage.fillAmount =(float)_playerHealth.GetHealth /healthFillAmaount;
    }
}
