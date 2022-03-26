using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotControl : MonoBehaviour
{
    
    [SerializeField] private Transform aimTransform;
    [SerializeField] private float shotRange = 10;
    [SerializeField] private LayerMask shootLayer;
    [SerializeField] bool isReloaded;
    
    private Attack _attackScript;
    private float reloadTime = 5f;
    private Movement movement;
    [SerializeField] private AudioClip _audioClip;

    public EnemyShotControl(Movement movement)
    {
        this.movement = movement;
    }

    void Start()
    {
        _attackScript = GetComponent<Attack>();
        
    }

    void Update()
    {
      
        if(Aim())
        {
            Fire();
        }
        RateOfEnemyAttack();
    }
    void Reload()
    {
        // Düşmanın mermisini asıl mermi propertisine eşitledik.
        // Get bölümünde return maxEnemyAmmo = 5; olduğu için 5 değerini GetAmmo ya atamış olduk.
        _attackScript.GetAmmo = _attackScript.enemyAmmoCount;  
        isReloaded= false;
    }
    void RateOfEnemyAttack()
    {
        if (_attackScript.GetAmmo <= 0 && isReloaded == false)
        {
            Invoke(nameof(Reload), reloadTime);
            isReloaded = true;
        }
    }
    /// <summary>
    /// 1. Başlangıç pozisyonu
    /// 2. Hangi yönde olacağı
    /// 3. Uzunluğu
    /// 4. Hangi fiziksel objeye çarparsam sana true dönerim bilgisi   
    /// </summary>
    public bool Aim()
    {
        bool hit = Physics.Raycast(aimTransform.position,transform.right,shotRange,shootLayer);
        Debug.DrawRay(aimTransform.position,transform.right * shotRange, Color.blue);
        return hit;
    }
    void Fire()
    {
        _attackScript.Enemy(0.5f);
        _attackScript.GetAudioClip = _audioClip;

    }
}
