using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkSpeed;

    private Vector3 moveDirection;

    private Rigidbody playerRb;
    private Animator animator;
    public float speed;
    public float turnSpeed;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public ParticleSystem explosionParticle;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // summons rigid body and adds gravity to it, while getting the game manager and animator components, to summon player upon starting the game and animate it respectively
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        animator = GetComponentInChildren<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // summons void movement.
        Movement();
    }

    void Movement()
    {
        float forwardMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float turnMovement = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;

        // moves the player
        transform.Translate(Vector3.forward * forwardMovement);
        transform.Rotate(Vector3.up * turnMovement);

        //plays the animations for each corresponing input.
        if (isOnGround)
        {
            if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.UpArrow))
            {
                Walk();
            }
            else if (moveDirection == Vector3.zero)
            {
                Idle();
            }

            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                Jump();
            }
        }

    }

    private void Idle()
    {
        // idle animation
        animator.SetFloat("Speed", 0);
    }

    private void Walk()
    {
        // walk animation
        speed = walkSpeed;
        animator.SetFloat("Speed", 0.5f);
    }
    private void Jump()
    {
        // adds force to the player to make it jump while on the ground, and sets up jump animation
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;
        animator.SetTrigger("jump");
        animator.SetFloat("Speed", 1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // checks if player is on ground so it can jump
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
           
        }
        // checks if falling object touches plyer to kill it, play an explosion particle, and end the game
        if (collision.gameObject.CompareTag("Bad"))
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.EndGame();
        }
    }
}
