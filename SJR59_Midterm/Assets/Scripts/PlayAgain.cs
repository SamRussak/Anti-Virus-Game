using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayAgain : MonoBehaviour {

    public Button buttonB;

    //Add listener to button
    //if user wants to play again call method
    void Start()
    {       
        buttonB.onClick.AddListener(() => { restartGame(); });
    }
    //restarts the game for player
    void restartGame()
    {
        SceneManager.LoadScene("Floor1");
    }
}
