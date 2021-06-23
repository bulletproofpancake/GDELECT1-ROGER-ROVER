using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;//for time

public class Pet : MonoBehaviour
{
    [SerializeField]
    private int happiness;
    [SerializeField]
    private int hunger;

    private bool serverTime;
    private int clickCount;
    // Start is called before the first frame update
    void Start()
    {

        PlayerPrefs.SetString("then", "22/06/2021 11:20:12");
        updateStatus();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp (0))
        {
            Vector2 v = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(v), Vector2.zero);
            if(hit) //on click on the pet, it will increase hapiness
            {
                Debug.Log(hit.transform.gameObject.name);
                if(hit.transform.gameObject.tag == "Pet") 
                {
                    clickCount++;
                    if(clickCount >= 3)
                    {
                        clickCount = 0;
                        updateHappiness(1);
                    }
                }
            }
        }
    }

    void updateStatus()
    {
        if (!PlayerPrefs.HasKey("hunger"))
        {
            hunger = 100;
            PlayerPrefs.SetInt("hunger", hunger);

        }
        else
        {
            hunger = PlayerPrefs.GetInt("hunger");
        }
        if (!PlayerPrefs.HasKey("happiness"))
        {
            happiness = 100;
            PlayerPrefs.SetInt("happiness", happiness);

        }
        else
        {
            happiness = PlayerPrefs.GetInt("happiness");
        }

        if (!PlayerPrefs.HasKey("then"))
            PlayerPrefs.SetString("then", getStringTime());


        TimeSpan ts = getTimeSpan(); //checks the time played and reduces hunger and hapiness
        hunger -= (int)(ts.TotalHours * 2);
        if(hunger <0)
        {
            hunger = 0;
        }
        happiness -= (int)((100 - hunger) * (ts.TotalHours / 5));
        if(happiness<0)
        {
            happiness = 0;
        }
        // Debug.Log(getTimeSpan().ToString());
      //  Debug.Log(getTimeSpan().TotalHours);

        if (serverTime)
            updateServer();
        else
            InvokeRepeating("updateDevice", 0f, 30f);
    }

    void updateServer()
    {

    }
    void updateDevice()
    {
        PlayerPrefs.SetString("then", getStringTime());
    }

    TimeSpan getTimeSpan()
    {
        if (serverTime)
            return new TimeSpan();
        else
            return DateTime.Now - Convert.ToDateTime(PlayerPrefs.GetString("then"));
    }

    string getStringTime()
    {
        DateTime now = DateTime.Now;
        return now.Month + "/" + now.Day + "/" + now.Year + " " + now.Hour + ":" + now.Minute + ":" + now.Second;
    }

    public int checkHunger
    {
        get { return hunger; }
        set { hunger = value; }
    }

    public int checkHapiness
    {
        get { return happiness; }
        set { happiness = value; }
    }

    public void updateHappiness(int i)
    {
        happiness += i;
        if (happiness> 100)
        {
            happiness = 100;
        }
    }
}