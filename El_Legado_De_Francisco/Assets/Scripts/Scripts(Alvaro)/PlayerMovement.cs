using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    private float speed = 3f;

    private float AttackTime = 0.16f;
    private float AttackCounter = 0.16f;
    private bool isAttacking;

    private Rigidbody2D playerRb;
    private Vector2 moveInput;
    private Animator playerAnimator;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        playerRb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed * Time.deltaTime;
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        if(moveX != 0)
        {
            float auxX = moveX;
            playerAnimator.SetFloat("AuxX", auxX);
        }
        if (moveY != 0)
        {
            float auxY = moveY;
            playerAnimator.SetFloat("AuxY", auxY);
        }
        moveInput = new Vector2(moveX, moveY).normalized;

        playerAnimator.SetFloat("Horizontal", moveX);
        playerAnimator.SetFloat("Vertical", moveY);
        playerAnimator.SetFloat("Speed", moveInput.sqrMagnitude);

        if (isAttacking)
        {
            playerRb.velocity = Vector2.zero;
            AttackCounter -= Time.deltaTime;
            if (AttackCounter <= 0) 
            {
                playerAnimator.SetBool("isAttacking", false);
                isAttacking = false;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            AttackCounter = AttackTime;
            playerAnimator.SetBool("isAttacking", true);
            isAttacking = true;
        } 
        
    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + moveInput * speed * Time.fixedDeltaTime);
    }
}
