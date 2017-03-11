using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusHealth : MonoBehaviour {

    public float Health = 100;
    public GameObject endGame;
    //If Virus is shot, lower its health
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Bullet(Clone)"))
        {
            Health -= 15;
        }
    }
    //Check health, if 0 end game
    void Update()
    {
        if(Health <= 0)
        {
            gameObject.SetActive(false);
            endGame.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
