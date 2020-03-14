using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float moveHorizontal = 0;
    public float speed;
    public float max_speed;
    public float jump_scalar;
    private bool is_on_ground;

    private Rigidbody2D rb2d;
    private Animator animator;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("Running", false);
    }

    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));

        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", !true);
        }

        if (rb2d.velocity.magnitude < max_speed)
        {
            Vector2 movement = new Vector2(moveHorizontal, 0);
            rb2d.AddForce(movement * speed);
        }

        if (Input.GetButtonDown("Jump") && is_on_ground)
        {
            Vector2 jump_force = new Vector2(0, jump_scalar);
            rb2d.AddForce(jump_force);
        }

        flipping_animation();

    }

    private void flipping_animation()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb2d.transform.localScale =  new Vector3(-1f, 1f, 1f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb2d.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CollisionIsWithGround(collision))
        {
            is_on_ground = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (CollisionIsWithGround(collision))
        {
            is_on_ground = false;
        }
    }

    private bool CollisionIsWithGround(Collision2D collision)
    {
        bool is_with_ground = false;
        foreach(ContactPoint2D c in collision.contacts)
        {
            Vector2 collision_direction_vector = c.point - rb2d.position;
            if(collision_direction_vector.y < 0)
            {
                is_with_ground = true;
            }
        }

        return is_with_ground;
    }
}
