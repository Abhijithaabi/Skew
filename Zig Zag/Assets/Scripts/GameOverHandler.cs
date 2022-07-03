using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOverHandler : MonoBehaviour
{
    Player player;
    scoreKeeper scoreKeeper;
    [SerializeField] Canvas GameoverCanvas;
    [SerializeField] TextMeshProUGUI currentScoreTxt;
    [SerializeField] TextMeshProUGUI highScoreTxt;
    float currentScore;
    float highScore;
    void Start()
    {
        player = FindObjectOfType<Player>();
        scoreKeeper = FindObjectOfType<scoreKeeper>();
        GameoverCanvas.gameObject.SetActive(false);
    }

    
    void Update()
    {
        if(player.GetIsDead())
        {
            EnableGameOver();
        }  
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void MenuGame()
    {
        SceneManager.LoadScene(0);
    }
    void EnableGameOver()
    {
        GameoverCanvas.gameObject.SetActive(true);
        scoreKeeper.DisableScoreTxt();
        currentScore = scoreKeeper.getCurrentScore();
        currentScoreTxt.text = "Your Score : " + Mathf.FloorToInt(currentScore);
        highScore = scoreKeeper.getHighScore();
        if(currentScore>highScore)
        {
            scoreKeeper.setHighscore(currentScore);
        }
        highScoreTxt.text = "Best Score : "+ Mathf.FloorToInt(highScore).ToString();

    }
}
