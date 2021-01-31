using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyKeyToMenu : MonoBehaviour
{

    IEnumerator MoveToMenu()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("MenuScene");
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {

        if(Input.anyKey)
        {
            StartCoroutine(MoveToMenu());
        }


    }
}
