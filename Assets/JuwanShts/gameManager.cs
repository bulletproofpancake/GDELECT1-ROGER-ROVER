using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class gameManager : MonoBehaviour
{

    public Text happinessText;
    public Text hungerText;

    public Pet pet;


    private void Awake()
    {
        SetEntryTime();
    }

    private static void SetEntryTime()
    {
        PlayerPrefs.SetString("entryTime", DateTime.Now.ToString());
        Debug.LogWarning(PlayerPrefs.GetString("entryTime"));
        Debug.LogWarning(PlayerPrefs.GetString("exitTime"));
    }

    public void SetExitTime()
    {
        PlayerPrefs.SetString("exitTime", DateTime.Now.ToString());
        Debug.LogWarning(PlayerPrefs.GetString("exitTime"));
    }

    private void Update()
    {
        happinessText.text = pet.checkHapiness.ToString();
        hungerText.text = pet.checkHunger.ToString();
        
        if(Input.GetKeyDown(KeyCode.Space)) SetExitTime();

    }


}
