using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;
    
    private float movementX;
    [SerializeField]
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    private bool isGrounded = true;
    private bool shallJump;
    private string GROUND_TAG = "Ground";

    private string ENEMY_TAG = "Enemy";
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PLayerMoveKeyboard();
        AnimatePlayer();
        
        if (Input.GetButtonDown("Jump") && isGrounded) {
            shallJump = true;
        }
        
    }

    private void FixedUpdate() {

        if (shallJump == true){
            PlayerJump();
        }
        
    }

    void PLayerMoveKeyboard(){

        movementX = Input.GetAxisRaw("Horizontal");
        
        transform.position += new Vector3(movementX,0f,0f) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer() {

        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else {
            anim.SetBool(WALK_ANIMATION, false);
        }

    }

    void PlayerJump() {

        isGrounded = false;
        shallJump = false;
        myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

    }

    private void OnCollisionEnter2D(Collision2D collision){
        
        if (collision.gameObject.CompareTag(GROUND_TAG)){
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag(ENEMY_TAG)) {
            Destroy(gameObject);

        }

    
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {

        if (collision.CompareTag(ENEMY_TAG)) {
            Destroy(gameObject);
        }

    }
}
