using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

    [RequireComponent(typeof(Rigidbody))]


    public class PlayerControl : MonoBehaviour
    {

        public FloatingJoystick joystick;
    public GameObject FloatingJoystick;
    public float movementSpeed;
    public float rotationSpeed;
    [Header("JUMP")]
    public bool canJump;
    public float jumpForce = 10f;
    public float gravityScale = 10f;
    public float fallGravityScale = 10f;
    public float curGravityScale;
    public Transform GroundCheck;
    public LayerMask groundLayer;
    public float groundCheckDistance = 0.9f;
    private Rigidbody rb;
    public bool isGrounded;

    public Canvas inputCanvas;
    public bool isJoystick;
    private Animator MyAnim;

    public AudioClip jumpClip;
    public AudioClip coinClip;

    private void Start()
        {
        curGravityScale = gravityScale;
            EnableJoystickInput();
            rb = GetComponent<Rigidbody>();
            MyAnim = GetComponent<Animator>();
    }

        public void EnableJoystickInput()
        {
            isJoystick = true;
            inputCanvas.gameObject.SetActive(true);
        }

    private void FixedUpdate()
    {
        if (isJoystick && !GameManager.instance.isDead)
        {

            var movementDir = new Vector3(joystick.Direction.x, 0.0f, joystick.Direction.y);
            rb.velocity = new Vector3(joystick.Direction.x * movementSpeed, rb.velocity.y, joystick.Direction.y * movementSpeed);


            if (movementDir.sqrMagnitude <= 0 || !isGrounded)
            {
                MyAnim.SetBool("RUN", false);
                return;
            }
            

            MyAnim.SetBool("RUN", true);
                MyAnim.SetBool("JUMP", false);
            
            
            var targetDir = Vector3.RotateTowards(transform.forward, movementDir, rotationSpeed * Time.deltaTime, 0.0f);

            transform.rotation = Quaternion.LookRotation(targetDir);
        }
        

    }
    public void Update()
    {
        isGrounded = Physics.Raycast(GroundCheck.position, Vector3.down, groundCheckDistance, groundLayer);

        // Debug to visualize the raycast in the Scene view
        Debug.DrawRay(transform.position, Vector3.down * groundCheckDistance, Color.red);
        if (isGrounded) canJump = true;
        else canJump = false;
        if (!canJump) MyAnim.SetBool("JUMP", false);
        if ((Input.GetButtonDown("Jump")) && isGrounded && !GameManager.instance.isDead)
        {
            MyAnim.SetBool("JUMP", true);
            rb.AddForce(Vector2.up * jumpForce,ForceMode.Impulse);
        }
        if (Input.GetButtonUp("Jump"))
        {
            MyAnim.SetBool("JUMP", false);
        }
        
        if (GameManager.instance.isDead)
        {
            Vector3 Smoothed_Position = Vector3.Lerp(this.gameObject.GetComponent<CapsuleCollider>().center, new Vector3(0, 0.035f, 0), 1f * Time.deltaTime);
            this.gameObject.GetComponent<CapsuleCollider>().center = Smoothed_Position;
             
            MyAnim.SetBool("Dead", true);
        }

    }
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ground"))
            {
                //isGrounded = true;
            }
        if (other.CompareTag("Coin"))
        {

            Sounds_Manager.instance.SFX(coinClip);
            GameManager.instance.CoinCounts += 1;
            GameManager.instance.SpawnCoin();
            Destroy(other.gameObject);
        }
            
        }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            //isGrounded = false;
        }

    }
    public void OnClick_Jump()
        {
        if(isGrounded && !GameManager.instance.isDead)
        {

            MyAnim.SetBool("JUMP", true);
            Sounds_Manager.instance.SFX(jumpClip);
            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            
        }
        }
    }
//}