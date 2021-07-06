using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour //https://gamedev.stackexchange.com/questions/119623/set-a-chance-to-spawn-for-each-gameobject-in-an-array
{
    [System.Serializable]
    public struct Spawnable
    {
        public GameObject gameObject;
        public float weight;
    }

    [SerializeField]
    public Spawnable[] spawnList;

    [SerializeField]
    private float _totalSpawnWeight;

    [SerializeField]
    private Vector3 center;
    [SerializeField]
    private Vector3 size;


    [SerializeField]
    private float SpawnIntervals;
    [SerializeField]
    private float maximumSpawnTime;
    [SerializeField]
    private float minimumSpawnTime;
    [SerializeField]
    private int StartWait;

    [SerializeField] 
    private bool stop;
    void OnValidate()
    {
        _totalSpawnWeight = 0f;
        foreach (var Spawnable in spawnList)
            _totalSpawnWeight += Spawnable.weight;
    }

    void Awake()
    {
        OnValidate();
    }

 

    void Start()
    {
        //int i = objectPrefab.Length;
        //Array.Resize(ref objectPrefab_RateUp, objectPrefab_RateUp.Length + i);
        StartCoroutine(SpawnFood());
    }

    // Update is called once per frame
    void Update()
    {
       
        SpawnIntervals = Random.Range(minimumSpawnTime, maximumSpawnTime);

    }

    IEnumerator SpawnFood()
    {
        yield return new WaitForSeconds(StartWait);

        while (!stop)
        {
           Vector3 pos = center + new Vector3(UnityEngine.Random.Range(-size.x / 2, size.x / 2),
            Random.Range(-size.y / 2, size.y / 2),
            Random.Range(-size.z / 2, size.z / 2));

            // Generate a random position in the list.
            float pick = Random.value * _totalSpawnWeight;
            int chosenIndex = 0;
            float cumulativeWeight = spawnList[0].weight;

            // Step through the list until we've accumulated more weight than this.
            // The length check is for safety in case rounding errors accumulate.
            while (pick > cumulativeWeight && chosenIndex < spawnList.Length - 1)
            {
                chosenIndex++;
                cumulativeWeight += spawnList[chosenIndex].weight;
            }

            // Spawn the chosen item.
            Instantiate(spawnList[chosenIndex].gameObject, pos, spawnList[chosenIndex].gameObject.transform.rotation);


            yield return new WaitForSeconds(SpawnIntervals);
        }
     

    }    


    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }

   

}




/*
 1. Spawn at random places
 2. Has limit of spawn
    ~Objects are not destroyed overtime
 */