using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGravity : MonoBehaviour
{
    private Transform player;
    [SerializeField] private Camera camera;
    public int counterj = 0;
    public int counterk = 0;

    void Start()
    {
        player = GetComponent<Transform>();
    }

    void Update()
    {
        SpriteRotation();
    }

    void SpriteRotation()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            transform.eulerAngles += new Vector3(0f, 0f, -90f);
            //camera.transform.eulerAngles += new Vector3(0f, 0f, -90f);
            camera.transform.Rotate(new Vector3(0f, 0f, -90f) * (100 * Time.deltaTime));
            if (counterj == 0)
            {
                Physics2D.gravity = new Vector2(-9.81f, 0); //esquerda
                counterj++;
                counterk = 3;
            }
            else if (counterj == 1)
            {
                Physics2D.gravity = new Vector2(0, 9.81f); //cima
                counterj++;
                counterk = 2;

            }
            else if (counterj == 2)
            {
                Physics2D.gravity = new Vector2(9.81f, 0); //direita
                counterj++;
                counterk = 1;
            }
            else if (counterj == 3)
            {
                Physics2D.gravity = new Vector2(0, -9.81f); //baixo
                counterj = 0;
                counterk = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            transform.eulerAngles += new Vector3(0f, 0f, 90f);
            //camera.transform.eulerAngles += new Vector3(0f, 0f, 90f);
            if (counterk == 0)
            {
                Physics2D.gravity = new Vector2(9.81f, 0); //direita
                counterk++;
                counterj = 3;
            }
            else if(counterk == 1)
            {
                Physics2D.gravity = new Vector2(0, 9.81f); //cima
                counterk++;
                counterj = 2;
            }
            else if(counterk == 2)
            {
                Physics2D.gravity = new Vector2(-9.81f, 0); //esquerda
                counterk++;
                counterj = 1;
            }
            else if (counterk == 3)
            {
                Physics2D.gravity = new Vector2(0, -9.81f); //baixo
                counterk = 0;
                counterj = 0;
            }
        }
    }
}
