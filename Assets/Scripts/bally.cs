using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bally : MonoBehaviour
{
    public bool isDead;
    public float velocity = 1f;
    public Rigidbody2D rb2D;
    public Transform Followplatform;
    public GameManager manager;
    public GameObject tryAgainScreen;
    public AudioSource lostAudio;
    public AudioSource bounceAudio;
    public bool isScored = true;
    public Text bestScoreTxt;


    private void Start()
    {
        Time.timeScale = 1;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb2D.velocity = Vector2.up * velocity;
            bounceAudio.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "DeathArea")
        {
            lostAction();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "ScoreArea" && isScored == false)
        {
            lostAction();
            return;
        }

        if (collision.gameObject.tag == "ScoreArea")
        {
            manager.updateScore();
            isScored = true;
        }
        else
        {
            isScored = false;
        }   
    }

    private void lostAction()
    {
        isDead = true;
        Time.timeScale = 0;
        tryAgainScreen.SetActive(true);
        lostAudio.Play();

        var savedScore = PlayerPrefs.GetInt("lastScore");
        if (savedScore < manager.getLastScore()) {
            savedScore = manager.getLastScore();
            PlayerPrefs.SetInt("lastScore", savedScore);
        }
        bestScoreTxt.text = "Best\n" + savedScore;
    }

}
