using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class gameManager : MonoBehaviour
{

    public Text happinessText;
    public Text hungerText;
    public Text hoursText;
    public Pet pet;

    public int hoursPassed;

    private void Awake()
    {
        SetEntryTime();
    }

    private void Start()
    {
        CalculateTimePassed();
    }

    private void SetEntryTime()
    {
        PlayerPrefs.SetString("entryTime", DateTime.Now.ToString());
    }

    public void SetExitTime()
    {
        PlayerPrefs.SetString("exitTime", DateTime.Now.ToString());
    }

    private void CalculateTimePassed()
    {
        var entryTime = PlayerPrefs.GetString("entryTime");
        var exitTime = PlayerPrefs.GetString("exitTime");
        
        var entryDate = DateTime.Parse(entryTime);
        var exitDate = DateTime.Parse(exitTime);

        var timeSinceExit = entryDate.Subtract(exitDate);

        //TODO: CHANGE TO HOURS
        hoursPassed = timeSinceExit.Minutes;

    }

    private void Update()
    {
        happinessText.text = $"Happiness: {pet.checkHapiness}";
        hungerText.text = $"Hunger: {pet.checkHunger}";
        hoursText.text = $"Hours since last play: {hoursPassed}";
    }


}
