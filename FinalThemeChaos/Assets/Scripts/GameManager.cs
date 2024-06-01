using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private const int Value = 1;
    public bool isGameActive;
    public GameObject titleScreen;
    public GameObject GameOver;
    public GameObject Player;
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

        titleScreen.gameObject.SetActive(false);
        GameOver.gameObject.SetActive(false);

        StartCoroutine(SpawnFallingObjects());

        Instantiate(Player);    

    }

    public void EndGame()
    {
        isGameActive = false;

        GameOver.gameObject.SetActive(true);

        Debug.Log("Game over!");
    }
}
