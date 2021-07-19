using System.Collections;
using UnityEngine;

public class Pet : MonoBehaviour
{
    #region Juwan Code
        // [SerializeField]
        // private int happiness;
        // [SerializeField]
        // private int hunger;
        //
        // private bool serverTime;
        // private int clickCount;
        //
        // Ray ray;
        // RaycastHit hit;
        // // Start is called before the first frame update
        // void Start()
        // {
        //
        //     PlayerPrefs.SetString("then", "22/06/2021 11:20:12");
        //     updateStatus();
        // }
        //
        // // Update is called once per frame
        // void Update()
        // {
        //     ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //     if (Physics.Raycast(ray, out hit))
        //     {
        //         if (Input.GetMouseButtonUp(0))
        //         {
        //             print(hit.collider.name);
        //             clickCount++;
        //             if (clickCount >= 3)
        //             {
        //                 clickCount = 0;
        //                 updateHappiness(1);
        //             }
        //         }
        //         
        //     }
        // }
        // private void OnCollisionEnter(Collision collision)
        // {
        //     Debug.Log(collision.gameObject.name);
        //     if (collision.gameObject.CompareTag("Food"))
        //     {
        //         Debug.Log("hit");
        //         updateHunger(30);
        //         Destroy(collision.gameObject);
        //     }
        // }
        //
        // public void OnDrop(PointerEventData eventData)
        // {
        //     Debug.Log("OnDrop");
        //     updateHunger(30);
        // }
        // void updateStatus()
        // {
        //     if (!PlayerPrefs.HasKey("hunger"))
        //     {
        //         hunger = 100;
        //         PlayerPrefs.SetInt("hunger", hunger);
        //
        //     }
        //     else
        //     {
        //         hunger = PlayerPrefs.GetInt("hunger");
        //     }
        //     if (!PlayerPrefs.HasKey("happiness"))
        //     {
        //         happiness = 100;
        //         PlayerPrefs.SetInt("happiness", happiness);
        //
        //     }
        //     else
        //     {
        //         happiness = PlayerPrefs.GetInt("happiness");
        //     }
        //
        //     if (!PlayerPrefs.HasKey("then"))
        //         PlayerPrefs.SetString("then", getStringTime());
        //
        //
        //     TimeSpan ts = getTimeSpan(); //checks the time played and reduces hunger and hapiness
        //     hunger -= (int)(ts.TotalHours * 2);
        //     if(hunger <0)
        //     {
        //         hunger = 0;
        //     }
        //     happiness -= (int)((100 - hunger) * (ts.TotalHours / 5));
        //     if(happiness<0)
        //     {
        //         happiness = 0;
        //     }
        //     // Debug.Log(getTimeSpan().ToString());
        //     //  Debug.Log(getTimeSpan().TotalHours);
        //
        //     if (serverTime)
        //         updateServer();
        //     else
        //         InvokeRepeating("updateDevice", 0f, 30f);
        // }
        //
        // void updateServer()
        // {
        //
        // }
        // void updateDevice()
        // {
        //     PlayerPrefs.SetString("then", getStringTime());
        // }
        //
        // TimeSpan getTimeSpan()
        // {
        //     if (serverTime)
        //         return new TimeSpan();
        //     else
        //         return DateTime.Now - Convert.ToDateTime(PlayerPrefs.GetString("then"));
        // }
        //
        // string getStringTime()
        // {
        //     DateTime now = DateTime.Now;
        //     return now.Month + "/" + now.Day + "/" + now.Year + " " + now.Hour + ":" + now.Minute + ":" + now.Second;
        // }
        //
        // public int checkHunger
        // {
        //     get { return hunger; }
        //     set { hunger = value; }
        // }
        //
        // public int checkHapiness
        // {
        //     get { return happiness; }
        //     set { happiness = value; }
        // }
        //
        // public void updateHappiness(int i)
        // {
        //     happiness += i;
        //     if (happiness> 100)
        //     {
        //         happiness = 100;
        //     }
        // }
        //
        // public void updateHunger(int i)
        // {
        //     hunger += i;
        //     if(hunger > 100)
        //     {
        //         hunger = 100;
        //     }
        // }
    #endregion

    private int happiness;

    private int hunger;

    public int Happiness => happiness;
    public int Hunger => hunger;

    private int _petCounter;

    public void Start()
    {
        CalculateStats();
        StartCoroutine(ReduceStats());
    }

    private void CalculateStats()
    {

        happiness = PlayerPrefs.GetInt("happiness");
        hunger = PlayerPrefs.GetInt("hunger");

        if (happiness >= 100)
            happiness = 100;
        
        if (hunger >= 100)
            hunger = 100;
        
        //multiplied to 5 because stats lose 5 points per hour
        var timePassed = gameManager.Instance.hoursPassed * 5;
        happiness = CalculateStat(happiness, timePassed);
        hunger = CalculateStat(hunger, timePassed);
        Debug.LogError(timePassed);
    }

    private int CalculateStat(int stat, int timePassed)
    {
        stat -= timePassed;
        if (stat <= 0)
            stat = 0;
        return stat;
    }

    private int AddToStat(int stat, int points)
    {
        stat += points;
        return stat;
    }

    public void AddToHappiness(int points)
    {
        happiness = AddToStat(happiness, points);
    }

    public void AddToHunger(int points)
    {
        hunger = AddToStat(hunger, points);
    }

    private void PetRover()
    {
        _petCounter++;
        // Happiness increases every 3 clicks
        if(_petCounter % 3 == 0)
            happiness = AddToStat(happiness, 1);
    }

    private void OnMouseDown()
    {
        PetRover();
    }

    IEnumerator ReduceStats()
    {
        while (true)
        {
            yield return new WaitForSeconds(120f);
            happiness = CalculateStat(happiness, 1);
            hunger = CalculateStat(hunger, 1);
        }
    }
    
}
