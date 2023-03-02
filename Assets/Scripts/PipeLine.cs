using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeLine : MonoBehaviour
{



    private void Update()
    {
        transform.Translate(Vector2.left * Config.moveSpeed * Time.deltaTime);

        if (transform.position.x < -10)
            Destroy(gameObject);
    }


}
