using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int score;
    public Text scoreTxt;
    public AudioSource swishAudio;

    void Start()
    {
        score = 0;
        scoreTxt.text = score.ToString();
    }

    void Update()
    {
        
    }
    
    public void updateScore()
    {
        score++;
        scoreTxt.text = score.ToString();
        swishAudio.Play();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(0);
    }
    public int getLastScore()
    {
        return score;
    }
}
