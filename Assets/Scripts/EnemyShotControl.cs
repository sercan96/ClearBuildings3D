using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotControl : MonoBehaviour
{
    [SerializeField] private Transform aimTransform;
    [SerializeField] private float shotRange = 10;
    [SerializeField] private LayerMask shootLayer;
    private Attack attackScript;

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
