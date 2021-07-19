using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject FoodPanel;
    public GameObject ShopPanel;

    public void openFoodPanel()
    {
        FoodPanel.SetActive(true);
    }
    public void closeFoodPanel()
    {
        FoodPanel.SetActive(false);
    }
    public void openShopPanel()
    {
        ShopPanel.SetActive(true);
    }
    public void closeShopPanel()
    {
        ShopPanel.SetActive(false);
    }
}
