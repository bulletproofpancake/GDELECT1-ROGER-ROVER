using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CashManager : MonoBehaviour
{
    public static CashManager instance;

    public int cash;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        cash = PlayerPrefs.GetInt("cash");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cash += 100;
        }
    }

    public void Spend(int cost)
    {
        cash -= cost;
    }
    
}
