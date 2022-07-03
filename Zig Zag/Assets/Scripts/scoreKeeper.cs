using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreKeeper : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] float scoreMultiplier;
    float score = 0;
    bool shouldCount = false;
    float highScore;  
    private static scoreKeeper Instance;
    private void Awake() {
        highScore = PlayerPrefs.GetFloat("HighScore",0);
        
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        if(!shouldCount){return;}
        score += scoreMultiplier * Time.deltaTime;
        Debug.Log(scoreMultiplier * Time.deltaTime);
        scoreTxt.text = Mathf.FloorToInt(score).ToString();
    }
    public void stopScoreCount()
    {
        shouldCount = false;
        
    }
    public void startScoreCount()
    {
        shouldCount = true;
    }
    public void DisableScoreTxt()
    {
        scoreTxt.enabled = false;
    }
    public float getCurrentScore()
    {
        return score;
    }
    public float getHighScore()
    {
        return highScore;
    }
    public void setHighscore(float score)
    {
        PlayerPrefs.SetFloat("HighScore",score);
    }
    
    
}
