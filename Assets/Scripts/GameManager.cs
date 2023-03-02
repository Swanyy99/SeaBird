using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Animator anim;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI bestscoreUI;
    public PlayerControl player;
    public GameObject pipeSpawner;
    public GameObject JumpButton;
    public GameObject startUI;
    public GameObject endUI;
    public GameObject RetryButton;
    public AudioSource BGM;
    public AudioSource DeathSound;
    

    private int curScore = 0;
    private int bestScore = 0;

    private void Start()
    {
        
        ReadyGame();

    }

    private void Update()
    {
        bestScore = PlayerPrefs.HasKey("BestScore") ? PlayerPrefs.GetInt("BestScore") : 0;
        bestscoreUI.text = bestScore.ToString();
    }

    public void ReadyGame()
    {
        
        startUI.SetActive(true);
        Config.moveSpeed = 8f;
    }



    public void StartGame()
    {
        pipeSpawner.SetActive(true);
        startUI.SetActive(false);
        JumpButton.SetActive(true);
        BGM.Play();


    }

    public void RetryGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void EndGame()
    {
        Config.moveSpeed = 0;

        DeathSound.Play();
        BGM.Stop();
        endUI.SetActive(true);
        pipeSpawner.SetActive(false);
        JumpButton.SetActive(false);

    }

    public void ScoreUp()
    {
        curScore++;
        if (curScore > bestScore)
        {
            bestScore = curScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }

        scoreUI.text = curScore.ToString();

    }
}
