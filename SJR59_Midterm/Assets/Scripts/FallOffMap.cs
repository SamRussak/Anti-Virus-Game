using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOffMap : MonoBehaviour {   
    public GameObject player;
    public GameObject spawn;
    //If player falls of the map, return them to the spawn point
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.Equals("Anti-Virus"))
        {
            player.transform.position = spawn.transform.position;
        }
        else
        {
            collision.gameObject.SetActive(false);                
        }
        
    }
}
