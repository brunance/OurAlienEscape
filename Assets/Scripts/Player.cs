using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Animator anim;
    public Rigidbody2D box;

    void Start()
    {
        anim = GetComponent<Animator>();
        box = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if(Physics2D.gravity.x == 0f && Physics2D.gravity.y == -9.81f) //baixo
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal"), 0f, 0f) * Time.deltaTime * speed;

            if (Input.GetAxis("Horizontal") > 0f)
            {
                anim.SetBool("run", true);
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
            else if (Input.GetAxis("Horizontal") < 0f)
            {
                anim.SetBool("run", true);
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
        } 
        else if(Physics2D.gravity.x == -9.81f && Physics2D.gravity.y == 0f) //esquerda
        {
            transform.position += new Vector3(0f, -Input.GetAxis("Horizontal"), 0f) * Time.deltaTime * speed;

            if (Input.GetAxis("Horizontal") > 0f)
            {
                anim.SetBool("run", true);
                transform.eulerAngles = new Vector3(0f, 0f, -90f);
            }
            else if (Input.GetAxis("Horizontal") < 0f)
            {
                anim.SetBool("run", true);
                transform.eulerAngles = new Vector3(-180f, 0f, -90f);
            }
        }
        else if (Physics2D.gravity.x == 9.81f && Physics2D.gravity.y == 0f) //direita
        {
            transform.position += new Vector3(0f, Input.GetAxis("Horizontal"), 0f) * Time.deltaTime * speed;

            if (Input.GetAxis("Horizontal") > 0f)
            {
                anim.SetBool("run", true);
                transform.eulerAngles = new Vector3(0f, 0f, 90f);
            }
            else if (Input.GetAxis("Horizontal") < 0f)
            {
                anim.SetBool("run", true);
                transform.eulerAngles = new Vector3(180f, 0f, 90f);
            }
        }
        else if (Physics2D.gravity.x == 0f && Physics2D.gravity.y == 9.81f) //cima
        {
            transform.position += new Vector3(-Input.GetAxis("Horizontal"), 0f, 0f) * Time.deltaTime * speed;

            if (Input.GetAxis("Horizontal") > 0f)
            {
                anim.SetBool("run", true);
                transform.eulerAngles = new Vector3(0f, 0f, 180f);
            }
            else if (Input.GetAxis("Horizontal") < 0f)
            {
                anim.SetBool("run", true);
                transform.eulerAngles = new Vector3(0f, -180f, 180f);
            }
        }

        if (Input.GetAxis("Horizontal") == 0f)
        {
            anim.SetBool("run", false);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Spike")
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Box")
        {
            Debug.Log(box.velocity);
            if (box.velocity.x > 0.25 || box.velocity.y > 0.25 || box.velocity.x < -0.25 || box.velocity.y < -0.25)
            {
                GameController.instance.ShowGameOver();
                Destroy(gameObject);
            }
        }
    }

}
