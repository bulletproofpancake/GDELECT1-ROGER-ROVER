using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class gameManager : MonoBehaviour
{

    public GameObject happinessText;
    public GameObject hungerText;

    public GameObject pet;

    public GameObject foodPanel;
    public Sprite[] foodIcon;

    private void Update()
    {
        happinessText.GetComponent<Text>().text = pet.GetComponent<Pet>().checkHapiness.ToString();
        hungerText.GetComponent<Text>().text = pet.GetComponent<Pet>().checkHunger.ToString();
    }

    public void buttonBehavior (int i)
    {
        switch (i)
        {
            case (0):
            default:
                foodPanel.SetActive(!foodPanel.activeInHierarchy);
                break;

        }
    }

    public void selectFood(int i)
    {
        Toggle(foodPanel);
    }

    private void Toggle(GameObject foodPanel)
    {
        throw new NotImplementedException();
    }
}
