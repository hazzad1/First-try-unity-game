using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class movement : MonoBehaviour
{
    //necessary for animations and physics
    private Rigidbody2D rb2D;
    private Animator myAnimator;

    //variables to play with
    public float speed = 2.0f;
    public float hmovement;

    private bool facingRight = true;
    
    
    // Start is called before the first frame update
   private void Start()
    {
        //define the gameobjects found on the player
        rb2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        //check input given
        hmovement = Input.GetAxisRaw("Horizontal");
    }

    //runs the physics, tied to CPU and not game fps updates

    private void FixedUpdate()
    {
        //move character left and right
        rb2D.velocity = new Vector2(hmovement * speed, rb2D.velocity.y);
        Flip(hmovement);
        
    }

    //flipping function
    private void Flip(float horizontal)
    {
        if (horizontal < 0 && !facingRight || horizontal > 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

    }
}
