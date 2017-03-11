using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayer : MonoBehaviour {
    public float MinDistance;
    public float moveSpeed;
    private Transform player;
    public float MaxDistance;
    public GameObject ProjectilePrefab;
    public Transform ShootOffset;
    public float ShootSpeed;
    public float Health = 100;
    public float shotRate;
    private float rateTime;

    //Search for Ant-virus
    void Start() {
        player = GameObject.Find("Anti-Virus").transform;
    }
    
    void Update()
    {
        //if health is 0, reset health and set to deactive 
        if(Health <= 0)
        {
            Health = 100f;
            gameObject.SetActive(false);            
        }
        //follow and shoot player if in the appropriate distances
        transform.LookAt(player);
        if (Vector3.Distance(transform.position, player.position) >= MinDistance)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;

            if (Vector3.Distance(transform.position, player.position) <= MaxDistance && Time.time > rateTime)
            {
                rateTime = Time.time + shotRate;
                Fire();
            }

        }
    }
    //fire bullet from pool at player
    void Fire()
    {
        GameObject obj = BulletPool.current.getPoolObj();
        if (obj == null) return;

        obj.transform.position = ShootOffset.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
        Rigidbody r = obj.GetComponent<Rigidbody>();
        r.velocity = Vector3.zero;
        r.angularVelocity = Vector3.zero;
        r.AddForce(transform.forward * ShootSpeed, ForceMode.VelocityChange);
    }
    //if hit by a bullet, lower health
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Bullet(Clone)"))
        {
            Health -= 50;
        }        
    }
}
