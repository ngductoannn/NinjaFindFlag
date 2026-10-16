using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private bool isGround;
    private Animator animator;

    public Text KeyText; 
    private int countKey = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        KeyText.text = countKey + "/3";
    }

    // Update is called once per frame
    void Update()
    {
        KeyText.text = countKey + "/3";
        animator.SetFloat("Yvelocity", rb.velocity.y);
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(Time.deltaTime*-1*speed, 0, 0));
            transform.localScale = new Vector3(-1,1,1);
            if (isGround)
            {
                animator.SetInteger("Status", 1);
            }
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(Time.deltaTime*speed, 0, 0));
            transform.localScale = new Vector3(1,1,1);
            if (isGround)
            {
                animator.SetInteger("Status", 1);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            isGround = false;
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode2D.Impulse);
            animator.SetInteger("Status", 2);
        }
        if (!(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            if (isGround)
                animator.SetInteger("Status", 0);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene("GameWin");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            isGround = true;
        }
        if(collision.gameObject.tag == "key")
        {
            countKey++;
            Destroy(collision.gameObject);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            isGround = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "stair" || collision.gameObject.tag == "elevator")
        {
            isGround = true;
        }
        if(collision.gameObject.tag == "water" || collision.gameObject.tag == "enemy" || collision.gameObject.tag == "obstacle")
        {
            countKey = 0;
            SceneManager.LoadScene("GameOver");
        }
        if(collision.gameObject.tag == "flag" && countKey >= 3) 
        {
            SceneManager.LoadScene("GameWin");
        }
    }

}
