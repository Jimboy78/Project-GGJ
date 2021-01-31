using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToCredits : MonoBehaviour
{

    IEnumerator MoveToMenu()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("CreditsScene");
    }

    // Start is called before the first frame update
    void Start()
    {
// StartCoroutine(MoveToMenu());
    }

    void Update()
    {
        if (Input.anyKey)
        {
            StartCoroutine(MoveToMenu());
        }

    }
}
