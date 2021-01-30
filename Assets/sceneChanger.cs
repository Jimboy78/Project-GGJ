using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class sceneChanger : MonoBehaviour
{

   public void changeSceneTo(string sceneName){
        SceneManager.LoadScene(sceneName);
   }

   public void exitGame(){
       Debug.Log("Esto no anda bro... fijate que onda");
       Application.Quit();

   }
}
