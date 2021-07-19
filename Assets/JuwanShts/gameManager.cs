using System;
using Core;
using UnityEngine.UI;
using UnityEngine;

public class gameManager : Singleton<gameManager>
{

    public Text happinessText;
    public Text hungerText;
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

    //TODO: CALL ON EXIT
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
        hoursPassed = timeSinceExit.Hours;
        
        print(hoursPassed);

    }

    private void Update()
    {
        happinessText.text = $"Happiness: {pet.Happiness}";
        hungerText.text = $"Hunger: {pet.Hunger}";
    }


}
