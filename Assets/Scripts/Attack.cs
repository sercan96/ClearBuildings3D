using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject firePos;
    [SerializeField] float rateOfFire;
    [SerializeField] private bool isPlayer = false;
    [SerializeField] private bool isEnemy = false;
    [SerializeField] private int maxEnemyAmmo = 5;

    private GameManager _gameManager;

    public GameObject[] weapons;
    public int maxAmmo ;
    
    private int ammoCount;
    public int GetAmmo { get{return ammoCount;} set{ammoCount = value; if(ammoCount > maxAmmo) ammoCount = maxAmmo;  }}
    // private Rigidbody rb; // Başka bir objenin Rigidbody si ile işlem yap.
    // private Rigidbody rb2;  // Bu scripte bağlı olan objenin Rigidbody si ile işlem yap.
    private AudioClip _audioClip;
    public AudioClip GetAudioClip
    {
        get => _audioClip;
        set => _audioClip = value;
    }
   
    private AudioSource audioSource;
    public int enemyAmmoCount
    {
        get => maxEnemyAmmo;
    }

    public float GetFireRate
    {
        get => rateOfFire;
        set => rateOfFire = value;
    }

    public int GetClipSize
    {
        get => maxAmmo;
        set => maxAmmo = value;
    }
    // EnemyShotControl enemyShotControl = new EnemyShotControl();
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }   
    void Update()
    {
        FireRange();
        Player();

    }
    public void FireRange()
    {
         rateOfFire -=Time.deltaTime;
    }
    void Player()
    {
        if(isPlayer && _gameManager.GetIsGameActive)
        {
            if(Input.GetMouseButtonDown(0)) 
            {
                Fire(rateOfFire);
            }
        }
    }
    public void Enemy(float timeFire)
    {
       if(isEnemy)
       {
           Fire(timeFire);
       }
    }
    void Fire(float timeofFire)
    {                  
        float difference = 180 - transform.eulerAngles.y;
        // Debug.Log("difference : " + difference);
        if(rateOfFire <=0 && ammoCount >0)
        {
            if(Mathf.Abs(difference) >= 90) // Merminin ne tarafa bakacağını belirledik.
            {              
                Debug.Log("sol");   
                Instantiate(bulletPrefab,firePos.gameObject.transform.position,Quaternion.Euler(0f,0f,-90f));    // sağ (90 dan büyük)      
            }
            else
            {            
                Debug.Log("sağ");   
                Instantiate(bulletPrefab,firePos.gameObject.transform.position,Quaternion.Euler(0f,0f,90f));   // sol (90 dan küçük)
            }   
            rateOfFire = timeofFire; 
            ammoCount --;
            audioSource.PlayOneShot(_audioClip);
        }
                  
    }
}
