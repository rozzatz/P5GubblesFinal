using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // summons button and game manager to start game
        button = GetComponent<Button>();
        button.onClick.AddListener(StartGame);

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGame()
    {
        
        //starts game
        gameManager.StartGame();
    }
}
