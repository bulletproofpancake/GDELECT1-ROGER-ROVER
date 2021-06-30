using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject Burger;
    public Transform spawnFood;

    public void food()
    {
        Instantiate(Burger, spawnFood);
    }
}
