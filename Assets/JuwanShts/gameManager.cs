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

    private void Update()
    {
        happinessText.GetComponent<Text>().text = pet.GetComponent<Pet>().checkHapiness.ToString();
        hungerText.GetComponent<Text>().text = pet.GetComponent<Pet>().checkHunger.ToString();
    }


}
