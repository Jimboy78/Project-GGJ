using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour
{

    
    IEnumerator MoveToMenu()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Transform");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey)
        {
            StartCoroutine(MoveToMenu());
        }
        
    }
}
