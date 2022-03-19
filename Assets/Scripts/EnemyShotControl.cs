using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotControl : MonoBehaviour
{
    [SerializeField] private Transform aimTransform;
    [SerializeField] private float shotRange = 10;
    [SerializeField] private LayerMask shootLayer;

    void Update()
    {
        Aim();
    }
    /// <summary>
    /// 1. Başlangıç pozisyonu
    /// 2. Hangi yönde olacağı
    /// 3. Uzunluğu
    /// 4. Hangi objeye çarpacarsam sana true dönerim bilgisi
    /// </summary>
    void Aim()
    {
        bool hit = Physics.Raycast(aimTransform.position,transform.right,shotRange,shootLayer);
        Debug.DrawRay(aimTransform.position,transform.right * shotRange, Color.blue);
        print("Can shoot" + hit);
        if(hit)
        {
            Destroy(GameObject.Find("Player"));
        }
    }
}
