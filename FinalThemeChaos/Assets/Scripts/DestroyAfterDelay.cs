using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Destroys particle effect after 2 seconds
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
