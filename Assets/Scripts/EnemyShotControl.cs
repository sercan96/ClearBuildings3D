using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotControl : MonoBehaviour
{
    [SerializeField] private Transform aimTransform;
    [SerializeField] private float shotRange = 10;
    [SerializeField] private LayerMask shootLayer;
    private Attack attackScript;
    [SerializeField] bool isReloaded;
    private float reloadTime = 5f;

    void Start()
    {
        attackScript = GetComponent<Attack>();

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
        attackScript.GetAmmo = attackScript.enemyAmmoCount;  
        isReloaded= false;
    }
    void RateOfEnemyAttack()
    {
        if(attackScript.GetAmmo <= 0 && isReloaded == false)
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
        print("Can shoot" + hit);
        return hit;
    }
    void Fire()
    {
        attackScript.Enemy(0.8f);
    }
}
