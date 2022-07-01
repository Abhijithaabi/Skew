using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    Player player;
    
    void Start()
    {
        player = FindObjectOfType<Player>();
        
    }

    
    void Update()
    {
        if(player.GetIsDead())
        {
            if(Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
