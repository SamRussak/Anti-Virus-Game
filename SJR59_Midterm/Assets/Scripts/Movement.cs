using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private Transform t = null;
    public Bot Man;
    private Rigidbody r = null;
    public float TurnSpeed;
    public float Health = 100;
    public Button buttonL;
    public Button buttonR;
    public Button buttonF;
    public Button buttonB;
    public GameObject endGame;

    // get transform and rigidbody of Anti-Virus
    // add listeners to buttons
    //if a particular button is clicked, call the correct method
    void Start()
    {
        t = this.GetComponent<Transform>();
        r = this.GetComponent<Rigidbody>();
        buttonL.onClick.AddListener(() => { Left(); });
        buttonR.onClick.AddListener(() => { Right(); });
        buttonF.onClick.AddListener(() => { Forward(); });
        buttonB.onClick.AddListener(() => { Backward(); });      
    }
    //move player forward
    public void Forward()
    {   
        Vector3 dir = Vector3.zero;
        dir = t.forward * 1f;
        t.position += dir * Time.deltaTime * Man.Speed;
    }
    //turn the player right
    public void Right()
    {
        Quaternion rotation = t.rotation;
        rotation *= Quaternion.AngleAxis(TurnSpeed * Time.deltaTime, Vector3.up);
        t.rotation = rotation;
    }
    //turn the player left
    public void Left()
    {
        Quaternion rotation = t.rotation;
        rotation *= Quaternion.AngleAxis(TurnSpeed * Time.deltaTime * -1f, Vector3.up);
        t.rotation = rotation;
    }
    //move the player backward
    public void Backward()
    {
        Vector3 dir = Vector3.zero;
        dir = t.forward * -1f;
        t.position += dir * Time.deltaTime * Man.Speed;
    }
    //check players health, if dead eand game
    void Update()
    {
        if (Health <= 0f)
        {
            gameObject.SetActive(false);
            endGame.SetActive(true);            
        }

    }
    //lower health is bullet hits player
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Bullet(Clone)"))
        {
            Health -= 5;
        }
    }


}
//But class for Anti-Virus
[Serializable]
public class Bot
{
    public float Speed;

}

