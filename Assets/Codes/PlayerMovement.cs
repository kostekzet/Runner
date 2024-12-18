using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform GFX;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float groundDistance = 0.25f;
    [SerializeField] private float jumpTime = 0.3f;

    [SerializeField] private float crouchHeight = 0.5f;

    private bool isGrounded = false;
    private bool isJumping = true;
    private float jumpTimer;

    private Animator animator;
    AudioManager audioManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, groundDistance, groundLayer);

        // Skok
        #region JUMPING
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            audioManager.PlaySFX(audioManager.jump);
            isJumping = true;
            rb.velocity = Vector2.up * jumpForce;


            animator.SetBool("isJumping", true);
        }

        if (isJumping && Input.GetButton("Jump"))
        {
            if (jumpTimer < jumpTime)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimer += Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            jumpTimer = 0;
        }
        #endregion

 
        #region FALLING
        if (!isGrounded && rb.velocity.y < 0)
        {
            animator.SetBool("isFalling", true);
            animator.SetBool("isJumping", false);
        }
        else if (isGrounded)
        {
            animator.SetBool("isFalling", false);
            animator.SetBool("isJumping", false);
        }
        #endregion

        // Kucanie
        #region CROUCHING
        if (isGrounded && Input.GetButton("Crouch"))
        {
            audioManager.PlaySFX(audioManager.land);
            GFX.localScale = new Vector3(GFX.localScale.x, crouchHeight, GFX.localScale.z);
            animator.SetBool("isCrouching", true);
        }
        else
        {
            GFX.localScale = new Vector3(GFX.localScale.x, 1f, GFX.localScale.z);
            animator.SetBool("isCrouching", false);
        }
        #endregion



        if (isGrounded && !Input.GetButton("Crouch"))
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}
