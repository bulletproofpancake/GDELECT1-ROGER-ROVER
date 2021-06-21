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
    // Start is called before the first frame update
    void Start()
    {

       // PlayerPrefs.SetString("then", "21/06/2021 11:20:12");
        updateStatus();
    }

    // Update is called once per frame
    void Update()
    {

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
}
