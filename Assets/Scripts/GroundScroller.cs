using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    [SerializeField]
    private GameObject[] grounds;


    private void Update()
    {
      
        for (int i = 0; i < grounds.Length; i++)
        {
            grounds[i].transform.Translate(Vector2.left * Config.moveSpeed * Time.deltaTime);

            if (grounds[i].transform.position.x < -7)
            {
                grounds[i].transform.Translate(Vector2.right * 14);
            }
        }
        
       
    }
}
