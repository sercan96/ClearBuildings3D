using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject LevelFinishedParent;
    private bool _isGameActive = true;
    private Target _playerHealth;

    public bool GetIsGameActive
    {
        get => _isGameActive;
        set => _isGameActive = value;
    }

    private void Start()
    {
        _playerHealth = GameObject.FindWithTag("Player").GetComponent<Target>();
        SilahBilgisi();
    }

    void Update()
    {
        int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount <= 0 || _playerHealth.GetHealth <= 0)
        {
            LevelFinishedParent.SetActive(true);
            _isGameActive = false;
        }
        else
        {
            LevelFinishedParent.SetActive(false);
        }
        
    }
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
        _isGameActive = true;
    }

    public void SilahBilgisi()
    {
        Invoke("GunsInfoActiveTime",5);
    }

    private void GunsInfoActiveTime()
    {
        GameObject.Find("GunsInfo").SetActive(false);
    }
}
