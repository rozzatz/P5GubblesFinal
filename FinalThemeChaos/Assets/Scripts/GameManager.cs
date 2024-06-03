using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;
using Random = UnityEngine.Random;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    private const int Value = 1;
    public bool isGameActive;
    public GameObject titleScreen;
    public GameObject GameOver;
    public GameObject Player;
    public List<GameObject> fallingObjects;
    float SpawnRate = 0.7f;
    public float Score;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // summons timer text
        timerText.text = Score.ToString();

  
    }
    IEnumerator SpawnFallingObjects()
    {
        while (isGameActive == true)
        {
            // starts spawning objects from object list at random range and updates score 
            yield return new WaitForSeconds(SpawnRate);
            int index = Random.Range(0, fallingObjects.Count);
            Instantiate(fallingObjects[index]);
            Score += 1;
        }
       
    }

   


    public void StartGame()
    {
        // starts the game, deactivates title screen, starts spawning objects and starts score, and summons player
        isGameActive = true;
      
        titleScreen.gameObject.SetActive(false);
        GameOver.gameObject.SetActive(false);

        StartCoroutine(SpawnFallingObjects());


        Score = 0;
    
       

        Instantiate(Player);    

    }

    public void ReStartGame()
    {
        // starts the game, deactivates title screen, starts spawning objects and starts score, and summons player
        isGameActive = true;

        StartCoroutine(SpawnFallingObjects());
        titleScreen.gameObject.SetActive(false);
        GameOver.gameObject.SetActive(false);
       
        Score = 0;
        Instantiate(Player);

    } 


    public void EndGame()
    {
        // ends the game and summons game over screen
     
        isGameActive = false;
    
        GameOver.gameObject.SetActive(true);

     

    }
}
