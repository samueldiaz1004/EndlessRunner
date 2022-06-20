using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask boxCastMask;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jumpSFX;
    [SerializeField] private GameObject platform;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float downForce = 5f;
    private bool jump;
    private bool fall;

    void Update()
    {
        // Jump if the space kwy is pressed and only if the player is touching the ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            // Play audio clip if the player jumps
            audioSource.clip = jumpSFX;
            audioSource.Play();
            jump = true;
            fall = false;
        }
        // While the space key is not pressed, it makes the player fall faster
        if (!Input.GetKey(KeyCode.Space))
        {
            fall = true;
        }

        // For animation transitions
        if (isGrounded())
        {
            animator.SetBool("Jump",false);
        }
        else
        {
            animator.SetBool("Jump", true);
        }
    }

    private void FixedUpdate()
    {
        if (jump)
        {
            // Propels player upwards
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        } 
        else if (fall)
        {
            // Adds force downwards while falling
            rigidBody.AddForce(Vector2.down * downForce);
        }
    }

    // Function to check if player is touching a game object on a specific layer
    private bool isGrounded()
    {
        RaycastHit2D rayCast = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0,
                          Vector2.down, 0.1f, boxCastMask);
        return rayCast.collider != null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Platform"))
        {
            GameManager.Instance.spawnPlatform();
        }
    }
}
