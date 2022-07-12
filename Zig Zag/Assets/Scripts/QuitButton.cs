using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
    // Start is called before the first frame update
   public void Quitgame()
   {
    Application.Quit();
    Debug.Log("Quit");
   }
   public void BacktoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
