using System;
using Core;
using UnityEngine.UI;
using UnityEngine;

public class gameManager : Singleton<gameManager>
{
    public Pet pet;
    public int hoursPassed;

    protected override void Awake()
    {
        base.Awake();
        SetEntryTime();
        CalculateTimePassed();
    }

    private void Start()
    {
        pet = FindObjectOfType<Pet>();
    }

    private void SetEntryTime()
    {
        PlayerPrefs.SetString("entryTime", DateTime.Now.ToString());
    }
    
    public void SetExitStats()
    {
        if(pet != null)
        {
            PlayerPrefs.SetInt("happiness", pet.Happiness);
            PlayerPrefs.SetInt("hunger", pet.Hunger);
        }
        
        PlayerPrefs.SetInt("cash", CashManager.instance.cash);
        PlayerPrefs.SetString("exitTime", DateTime.Now.ToString());
    }

    private void CalculateTimePassed()
    {
        var entryTime = PlayerPrefs.GetString("entryTime");
        var exitTime = PlayerPrefs.GetString("exitTime");
        
        var entryDate = DateTime.Parse(entryTime);
        var exitDate = DateTime.Parse(exitTime);

        var timeSinceExit = entryDate.Subtract(exitDate);

        hoursPassed = timeSinceExit.Hours;
    }
}
