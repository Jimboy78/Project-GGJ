using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoToPlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
                StartCoroutine(MoveToMenu());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator MoveToMenu()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene("GameplayScene");
    }
}
