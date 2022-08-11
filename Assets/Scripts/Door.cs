using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Key keycode;
    public Animator anim;

    void Start()
    {
        keycode = FindObjectOfType<Key>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        isOpen();
    }

    void isOpen()
    {
        if(keycode.caught == true)
        {
            anim.SetBool("isOpen", true);
        }
    }
}
