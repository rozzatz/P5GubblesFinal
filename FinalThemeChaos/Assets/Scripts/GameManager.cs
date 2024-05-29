using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    public GameObject titleScreen;
    public List<GameObject> fallingObjects;
   float SpawnRate = 0.4f;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnFallingObjects()
    {
        while (isGameActive == true)
        {
            yield return new WaitForSeconds(SpawnRate);
            int index = Random.Range(0, fallingObjects.Count);
            Instantiate(fallingObjects[index]);
        }
       
    }

    public void StartGame()
    {
        isGameActive = true;

        Debug.Log("Game Start!");

        titleScreen.gameObject.SetActive(false);

        StartCoroutine(SpawnFallingObjects());
    }
}
