using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public PlayerMovement controller;
    public Animator animator;
    
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    
  
    void Update(){
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        
        //Animacion para moverse, el Mathf.Abs es para que siempre sea postivo
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump")){
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if(Input.GetButtonDown("Attack1")){
            Attack1();
        }

        if(Input.GetButtonDown("Dash")){
            Dash();
        }

         if(Input.GetButtonDown("Horizontal")){
            runSpeed = 40f;
        }
    }

    //Metodo para cuando caigas del salto
    public void OnLanding() {
        animator.SetBool("IsJumping", false);

    }

    //Metodo para todo lo relacionado al ataque 1(animacion, daño, etc...)
    void Attack1 (){
        animator.SetTrigger("IsAttacking1");
    }

    //Metodo para todo lo relacionado al dash(animacion, velocidad, etc...)
    void Dash (){
        animator.SetTrigger("IsDashing");
        runSpeed=70f;
        
    }

    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
