using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStartMove : MonoBehaviour
{
    public Button StartButton;

    float Timer;

    void Start()
    {
        StartButton.onClick.AddListener(TaskOnClick);
    }

    void Update()
    {

        Timer += Time.deltaTime;
        transform.Translate(Vector2.left * 3f * Time.deltaTime);



        if (Timer < 1)
            transform.Translate(Vector2.up * 0.2f * Time.deltaTime);
        else if (Timer > 1)
            transform.Translate(Vector2.down * 0.2f * Time.deltaTime);

        if (Timer >= 2)
            Timer = 0;


        if (transform.position.x < -11)
        {
            transform.Translate(Vector2.right * 22);
        }


    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("GameScene");
    }
}
