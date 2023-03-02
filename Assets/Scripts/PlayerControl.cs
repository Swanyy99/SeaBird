using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControl : MonoBehaviour
{

    private Rigidbody2D rigid;

    private Animator anim;

    private Collider2D col;

    public UnityEvent OnScore;

    public UnityEvent OnDie;

    //[SerializeField]
    //private float jumpPower;

    [Range(0, 30), SerializeField]
    private int speed;

    private bool isAlive = true;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += transform.up * (-1) * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += transform.right * (-1) * speed * Time.deltaTime;
        }

        if (isAlive == false)
        {
            transform.position += transform.up * (-1) * 10 * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.R))
            PlayerPrefs.SetInt("BestScore", 0);
    }

    //public void SetGravity(bool active)
    //{
    //    rigid.simulated = active;
    //}

    // Update is called once per frame
    //public void Jump()
    //{
    //    //rigid.AddForce(Vector2.up * jumpPower , ForceMode2D.Impulse);
    //    //if (isAlive == true)
    //    //    rigid.velocity = Vector2.up * jumpPower;
    //}

    public void Die()
    {
        isAlive = false;
        col.enabled = false;
        anim.SetBool("isDead", true);
        speed = 0;
    }


    // Á¡¼ö È¹µæ
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnScore?.Invoke();
    }

    // °ÔÀÓ ¿À¹ö
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Obstacle"))
        {
            Die();
            OnDie?.Invoke();
        }
    }

}
