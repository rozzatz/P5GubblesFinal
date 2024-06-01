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
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        animator = GetComponentInChildren<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float forwardMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float turnMovement = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;

        transform.Translate(Vector3.forward * forwardMovement);
        transform.Rotate(Vector3.up * turnMovement);

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
        animator.SetFloat("Speed", 0);
    }

    private void Walk()
    {
        speed = walkSpeed;
        animator.SetFloat("Speed", 0.5f);
    }
    private void Jump()
    {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;
        animator.SetTrigger("jump");
        animator.SetFloat("Speed", 1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
           
        }
        if (collision.gameObject.CompareTag("Bad"))
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.EndGame();
        }
    }
}
