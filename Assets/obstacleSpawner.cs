using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawner : MonoBehaviour
{

    public GameObject myPrefab;
    public float spawnTime = 3;



 
     void Start()
     {
 
         StartCoroutine(SpawnTimeDelay());
     }
     IEnumerator SpawnTimeDelay()
     {
         while (true)
             {
                 
                float carril =-6 + 6* Random.Range(0, 3);
                Instantiate(myPrefab, new Vector3(carril, 10, 0), Quaternion.identity);
                 yield return new WaitForSeconds(spawnTime);
               
             }
     }
    

}
