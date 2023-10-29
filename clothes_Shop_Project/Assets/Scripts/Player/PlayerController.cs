using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Moviment and Animation")]

    [SerializeField] private float speed = 10f;

    private Rigidbody2D rbPlayer;
    private Vector3 moviment;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moviment = Vector3.zero;
        moviment.x = Input.GetAxisRaw("Horizontal");
        moviment.y = Input.GetAxisRaw("Vertical");

        UpdatePositionAndAnimation();
    }

    private void UpdatePositionAndAnimation()
    {
        if (moviment != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("valueX", moviment.x);
            animator.SetFloat("valueY", moviment.y);
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    private void MoveCharacter()
    {
        rbPlayer.MovePosition(transform.position + moviment * speed * Time.deltaTime);
    }
}
