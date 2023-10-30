using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement and Animation")]

    [SerializeField] private float speed = 10f;

    private Vector3 movement;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        movement = Vector3.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        UpdatePositionAndAnimation();
    }

    private void UpdatePositionAndAnimation()
    {
        if (movement != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("valueX", movement.x);
            animator.SetFloat("valueY", movement.y);
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    private void MoveCharacter()
    {
        transform.position += movement * speed * Time.deltaTime;
    }
}