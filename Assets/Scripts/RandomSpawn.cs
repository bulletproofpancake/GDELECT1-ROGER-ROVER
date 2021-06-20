using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject objectPrefab;

    [SerializeField]
    private Vector3 center;
    [SerializeField]
    private Vector3 size;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            SpawnFood();
        
    }

    public void SpawnFood()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 
            Random.Range(-size.y / 2, size.y / 2), 
            Random.Range(-size.z / 2, size.z / 2));

        Instantiate(objectPrefab, pos, Quaternion.identity);

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