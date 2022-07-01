 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuHandler : MonoBehaviour
{
    [SerializeField] GameObject MenuPanel;
    
    
    bool IsMenuenabled;

    
    void Start()
    {
        IsMenuenabled = true;
        
    }

    
    void Update()
    {
        
       
    }
    void DisableMenu()
    {
        MenuPanel.gameObject.SetActive(false);
        IsMenuenabled = false;
    }
    public bool getIsMenuEnabled()
    {
        return IsMenuenabled;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

}
