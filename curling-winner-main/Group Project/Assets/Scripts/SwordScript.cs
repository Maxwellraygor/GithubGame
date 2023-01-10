using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SwordScript : MonoBehaviour
{  
    private GameObject sword;
    //private bool isSwordActive;
    private Animation anim;
    
    void Start()
    {
        //isSwordActive = false;
        anim = gameObject.GetComponent<Animation>();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed left click.");
            anim.Play("Sword_Swing");
        }
    }
}

