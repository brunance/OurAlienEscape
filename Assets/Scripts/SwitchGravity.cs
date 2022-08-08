using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGravity : MonoBehaviour
{
    [SerializeField] private Camera camera;
    public int counterj = 0;
    public int counterk = 0;
    int lado = 0;
    float angulo = 0;
    bool canTurn = true;
    public static GameController instance;

    void Start()
    {
        
    }

    void Update()
    {
        SpriteRotation();
        if(lado == 0)
        {
            angulo = 0;
        }
        else if (lado == 1)
        {
            angulo = 90;
        }
        else if (lado == 2)
        {
            angulo = 180;
        }
        else if (lado == 3)
        {
            angulo = 270;
        }

        camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, Quaternion.Euler(0, 0, angulo), Time.deltaTime * 4);
    }
    void SpriteRotation()
    {
        if (!canTurn)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine("waitTime");
            transform.eulerAngles += new Vector3(0f, 0f, -90f);
            if (counterj == 0)
            {
                Physics2D.gravity = new Vector2(-9.81f, 0); //esquerda
                counterj++;
                counterk = 3;
                lado = 3;

            }
            else if (counterj == 1)
            {
                Physics2D.gravity = new Vector2(0, 9.81f); //cima
                counterj++;
                counterk = 2;
                lado = 2;

            }
            else if (counterj == 2)
            {
                Physics2D.gravity = new Vector2(9.81f, 0); //direita
                counterj++;
                counterk = 1;
                lado = 1;
            }
            else if (counterj == 3)
            {
                Physics2D.gravity = new Vector2(0, -9.81f); //baixo
                counterj = 0;
                counterk = 0;
                lado = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine("waitTime");
            transform.eulerAngles += new Vector3(0f, 0f, 90f);
            //camera.transform.eulerAngles += new Vector3(0f, 0f, 90f);
            if (counterk == 0)
            {
                Physics2D.gravity = new Vector2(9.81f, 0); //direita
                counterk++;
                counterj = 3;
                lado = 1;
            }
            else if(counterk == 1)
            {
                Physics2D.gravity = new Vector2(0, 9.81f); //cima
                counterk++;
                counterj = 2;
                lado = 2;
            }
            else if(counterk == 2)
            {
                Physics2D.gravity = new Vector2(-9.81f, 0); //esquerda
                counterk++;
                counterj = 1;
                lado = 3;
            }
            else if (counterk == 3)
            {
                Physics2D.gravity = new Vector2(0, -9.81f); //baixo
                counterk = 0;
                counterj = 0;
                lado = 0;
            }
        }

    }
    IEnumerator waitTime()
    {
        canTurn = false;
        yield return new WaitForSeconds (1.5f);
        canTurn = true;
    }
}
