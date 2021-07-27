using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryManager : MonoBehaviour
{
    [SerializeField] private GameObject hat, satellite, drone;
    
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
    
    public void BuyItem(string itemName)
    {
        var status = PlayerPrefs.GetInt(itemName + "_bought");

        switch (status)
        {
            case 0:
                PlayerPrefs.SetInt(itemName+"_bought",1);
                break;
            case 1:
                PlayerPrefs.SetInt(itemName+"_bought",0);
                break;
        }
    }
    
}
