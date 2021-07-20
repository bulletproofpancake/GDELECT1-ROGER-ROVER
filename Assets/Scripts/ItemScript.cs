using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    private Pet _pet;
    [SerializeField] private int cost;
    [SerializeField] private Text costDisplay;

    private void Start()
    {
        _pet = FindObjectOfType<Pet>();
        costDisplay = GetComponentInChildren<Text>();
        costDisplay.text = $"Buy: {cost}";
    }

    public void BuyFood(int value)
    {
        if (CashManager.instance.cash >= cost)
            _pet.AddToHunger(value);
    }

    public void BuyAccessories(int value)
    {
        if (CashManager.instance.cash >= cost)
            _pet.AddToHappiness(value);
    }
    
}
