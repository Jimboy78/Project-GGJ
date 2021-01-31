using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawner : MonoBehaviour
{

    public GameObject myPrefab;
    public float startTime = 5;
    public float spawnTime = 3;


    public GameObject BarrelPrefab;
    public GameObject LogPrefab;
    public GameObject RockPrefab;

    private List<GameObject> Prefabs;
 
     void Start()
     {
 
        StartCoroutine(SpawnTimeDelay());
        BarrelPrefab = (GameObject)Resources.Load("Prefab/Barrel", typeof(GameObject));
        LogPrefab    = (GameObject)Resources.Load("Prefab/Log",    typeof(GameObject));
        RockPrefab   = (GameObject)Resources.Load("Prefab/Rock",   typeof(GameObject));
        Prefabs = new List<GameObject>(){BarrelPrefab, LogPrefab,RockPrefab};
     }
    IEnumerator SpawnTimeDelay(){
        yield return new WaitForSeconds(startTime);
            while (true){
                float carril =-8.5f + 4* Random.Range(0, 5);
                Instantiate(Prefabs[Random.Range(0, 3)], new Vector3(carril, 10, 0), Quaternion.identity);
                yield return new WaitForSeconds(spawnTime);
            }
    }
    

}
