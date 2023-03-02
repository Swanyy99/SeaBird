using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGroundScroller : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Backgrounds;



    private void Update()
    {
        moveBackground();
    }

    private void moveBackground()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "GameScene")
        {
            for (int i = 0; i < Backgrounds.Length; i++)
            {
                Backgrounds[i].transform.Translate(Vector2.left * Config.BackGroundMoveSpeed * Time.deltaTime);

                if (Backgrounds[i].transform.position.x < -20.72f)
                {
                    Backgrounds[i].transform.Translate(Vector2.right * 41.44f);
                }
            }
        }

        else if (scene.name == "TitleScene")
        {
            for (int i = 0; i < Backgrounds.Length; i++)
            {
                Backgrounds[i].transform.Translate(Vector2.left * 3f * Time.deltaTime);

                if (Backgrounds[i].transform.position.x < -20.72f)
                {
                    Backgrounds[i].transform.Translate(Vector2.right * 41.44f);
                }
            }
        }
    }
}
