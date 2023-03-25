using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using EasyUI.Toast;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;

    private BoxCollider2D coll;

    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;
    public float dirX = 0f;

    [SerializeField]
    private float moveSpeed = 25f;

    [SerializeField]
    private float jumpSpeed = 14f;

    private enum MovementState { idle, running , jumping , falling}

    private bool moveLeft;
    private bool moveRight;
    public bool IsEditor;
    private float horizontalMove;

    public static PlayerMovement instance;

    public GameObject pauseMenu;
    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();


        moveLeft = false;
        moveRight = false;
    }

   
    // Update is called once per frame
    void Update()
    {
        if(IsEditor)
        {
            dirX = Input.GetAxis("Horizontal");
        }
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);



        if (Input.GetButtonDown("Jump") && IsGrounded())  
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        

        //MovePlayer();
       
        AnimationUpdate();
    }

    //private void MovePlayer()
    //{
    //    if(moveLeft)
    //    {
    //        horizontalMove = -moveSpeed;
    //    }
    //    else if (moveRight)
    //    {
    //        horizontalMove = moveSpeed;
    //    }
    //    else { 
    //    horizontalMove = 0;
    //    }
    //}

    public void AnimationUpdate()
    {

        MovementState state;
        if (dirX > 0f )
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

    //private void FixedUpdate()
    //{
    //    rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    //}

    public void Right()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }
    
    public void Left()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    public void Jump()
    {

        if (IsGrounded())
        {
            Debug.Log("1");
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
            Debug.Log("2");

    }

    public void PauseMenuButton()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    } 
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
   
}
