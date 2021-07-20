using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    Ray ray;

    RaycastHit hit; 

    [SerializeField]
    private int cashPlus;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetMouseButtonDown(0)) //Detect input
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Detect input location

            if(Physics.Raycast(ray,out hit, float.MaxValue)) //If input location has hit something
            {
                if(hit.rigidbody != null) //clicked nothing
                {
                    if (hit.rigidbody.gameObject.tag == "Collectables") //clicked coins
                    {
                        Destroy(hit.rigidbody.gameObject);//removes object
                        CashManager.instance.cash += cashPlus;
                        Debug.Log("+1 Coins");
                    }
                }
                else
                {
                    return; //clicked nothing
                }
          
                 
            }
        }
    }

     
}
