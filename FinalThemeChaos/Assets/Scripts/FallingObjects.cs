using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
    public ParticleSystem explosionParticle;

    private Rigidbody Rb;
    float xRange= 6;
    float zRange = 6;
    float ySpawnPos = 15;
    private GameManager GameManager;

    // Start is called before the first frame update
    void Start()
    {
        // summons game manager and rigid body
        Rb = GetComponent<Rigidbody>();
        transform.position = RandomSpawnPos();
        GameManager = GameObject.Find("GameManager")
            .GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // destroys gameobject if falls below -12
     if (transform.position.y < -12)
        {
            Destroy(gameObject);
        }
    }
    Vector3 RandomSpawnPos()
    {
        // choses random spawn position from the established ranges
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos, Random.Range(-zRange, zRange));
    }

    void OnCollisionEnter(Collision collision)
    {
        // destroys object upon contact with other object
        Destroy(gameObject);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

    }
}
