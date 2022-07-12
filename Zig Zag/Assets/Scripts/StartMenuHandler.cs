 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenuHandler : MonoBehaviour
{
    [SerializeField] GameObject MenuPanel;
    [SerializeField] TextMeshProUGUI highScoreTxt;
    [SerializeField] TextMeshProUGUI GemsTxt;
    
    scoreKeeper scoreKeeper;
    
    
    bool IsMenuenabled;

    
    void Start()
    {
        IsMenuenabled = true;
        scoreKeeper = FindObjectOfType<scoreKeeper>();
        float highScore =  scoreKeeper.getHighScore();
        highScoreTxt.text = Mathf.FloorToInt(highScore).ToString();
        GemsTxt.text = scoreKeeper.getnoOfGems().ToString();        
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
    public void ShopBtn()
    {
        SceneManager.LoadScene(2);
    }

}
