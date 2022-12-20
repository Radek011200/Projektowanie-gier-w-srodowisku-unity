using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 30f;
    bool jump = false;
    bool attack = false;
    float horizontalMove = 0f;
   
    void Update()
    {
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        if (Input.GetKey("e"))
        {
            attack = true;
            animator.SetBool("Attack", true);
        }
        else
        {
            attack = false;
            animator.SetBool("Attack", false);
        }
        
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
        
        attack = false;
    }

    public void OnLanding()
    {
        Debug.Log("OnLanding()");
        animator.SetBool("IsJumping", false);
    }
}