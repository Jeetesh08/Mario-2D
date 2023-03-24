using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;

    private BoxCollider2D coll;

    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;
    private float dirX = 0f;

    [SerializeField]
    private float moveSpeed = 25f;

    [SerializeField]
    private float jumpSpeed = 14f;

    private enum MovementState { idle, running , jumping , falling}

    [SerializeField] private AudioSource jumpSoundEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
          dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);



        if (Input.GetButtonDown ("Jump") && IsGrounded())  
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

        //if (IsGrounded() && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        //{
        //    Touch touch = Input.GetTouch(0);
        //    float middleX = Screen.width / 2f;
        //    if (touch.position.x > middleX - 50f && touch.position.x < middleX + 50f)
        //    {
        //        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpSpeed);
        //    }
        //}

        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        //{
        //    Touch touch = Input.GetTouch(0);
        //    float middleX = Screen.width / 2f;
        //    if (touch.position.x < middleX)
        //    {
        //        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        //    }
        //    else
        //    {
        //        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        //    }
        //}
        //if (Input.GetButtonDown("Horizontal"))
        //{
        //    GetComponent<Rigidbody2D>().velocity = new Vector3(15, 0, 0);
        //}


        AnimationUpdate();
    }

    private void AnimationUpdate()
    {

        MovementState state;
        if (dirX > 0f || )
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {

            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if(rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }

        if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
       return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    public void Right()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;

    }

    public void Left()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

    }

    public void Jump()
    {

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

    }
}