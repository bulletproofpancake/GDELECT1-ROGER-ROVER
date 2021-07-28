using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccessoryManager : MonoBehaviour
{
    [SerializeField] private GameObject hat, satellite, drone;
    [SerializeField] private GameObject hatBtn, satelliteBtn, droneBtn;
    
    // Update is called once per frame
    void Update()
    {
        ShowItem("hat");
        ShowItem("satellite");
        ShowItem("drone");
    }

    private void ShowItem(string itemName)
    {
        var status = PlayerPrefs.GetInt(itemName + "_bought");
        switch (itemName)
        {
            case "hat":
                switch (status)
                {
                    case 0:
                        hat.SetActive(false);
                        break;
                    case 1:
                        hat.SetActive(true);
                        break;
                }

                break;
            case "satellite":
                switch (status)
                {
                    case 0:
                        satellite.SetActive(false);
                        break;
                    case 1:
                        satellite.SetActive(true);
                        break;
                }

                break;
            case "drone":
                switch (status)
                {
                    case 0:
                        drone.SetActive(false);
                        break;
                    case 1:
                        drone.SetActive(true);
                        break;
                }

                break;
        }
    }

    public void SetButton(string itemName,bool status)
    {
        switch (itemName)
        {
            case "hat":
                hatBtn.SetActive(status);
                break;
            case "satellite":
                satelliteBtn.SetActive(status);
                break;
            case "drone":
                droneBtn.SetActive(status);
                break;
        }
    }
    
    public void SetButtonStatus(ItemScript item)
    {
        
        SetButton(item.name,item.hasBeenBought);
    }
    
    public void BuyItem(string itemName)
    {
        var status = PlayerPrefs.GetInt(itemName + "_bought");
        PlayerPrefs.SetInt(itemName+"_bought",1);
    }
    
}
