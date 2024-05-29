using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator animator;
    public float speed;
    public float turnSpeed;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            animator.SetTrigger("jump");
        }
    }

    void Movement()
    {
        float forwardMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float turnMovement = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;

        transform.Translate(Vector3.forward * forwardMovement);
        transform.Rotate(Vector3.up * turnMovement);
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
        }
    }
}
