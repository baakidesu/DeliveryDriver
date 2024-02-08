using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]float steerSpeed = 1f;
    [SerializeField]float moveSpeed = 20f;
    [SerializeField]float slowMoveSpeed = 15f;
    [SerializeField]float boostedMoveSpeed = 30f;

  
    void Update()
        {
            float steerAmount = Input.GetAxis("Horizontal") * steerSpeed ;
            float moveAmount = Input.GetAxis("Vertical") * moveSpeed ;
            transform.Rotate(0, 0, -steerAmount);
            transform.Translate(0, moveAmount * 0.01f, 0);
           

        }

    void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowMoveSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Speed Up")
        {
            moveSpeed = boostedMoveSpeed;
        }
    }

   

    
}

