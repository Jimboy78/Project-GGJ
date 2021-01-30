using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BtnClick : MonoBehaviour
{

    IEnumerator ChangeSceneWithDelay()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MenuScene");
    }

   public void BtnNewScene(){
        StartCoroutine(ChangeSceneWithDelay());
   }
}
