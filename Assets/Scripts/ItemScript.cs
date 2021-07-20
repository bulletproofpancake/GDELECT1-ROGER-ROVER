using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    private Pet _pet;
    [SerializeField] private int cost;
    [SerializeField] private Text costDisplay;
    private UIManager _uiManager;

    private void Start()
    {
        _pet = FindObjectOfType<Pet>();
        _uiManager = FindObjectOfType<UIManager>();
        costDisplay = GetComponentInChildren<Text>();
        costDisplay.text = $"Buy: {cost}";
    }

    public void BuyFood(int value)
    {
        if (CashManager.instance.cash >= cost)
        {
            _pet.PlayAnimation("Happy");
            _pet.AddToHunger(value);
            _uiManager.closeFoodPanel();
        }
    }

    public void BuyAccessories(int value)
    {
        if (CashManager.instance.cash >= cost)
        {
            _pet.PlayAnimation("Happy");
            _pet.AddToHappiness(value);
            _uiManager.closeShopPanel();
        }
    }
    
}
