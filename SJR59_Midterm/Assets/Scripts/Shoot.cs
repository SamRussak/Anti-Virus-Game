using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{   
    public Transform ShootOffset;
    public float ShootSpeed;
    public Button Button;
    //add listener to button, if clicked call fire method
    void Start()
    {
        Button.onClick.AddListener(() => { Fire(); });
    }
    //shoots a bullet from the BulletPool
    public void Fire()
    {        
        GameObject obj = BulletPool.current.getPoolObj();
        if (obj == null) return;

        obj.transform.position = ShootOffset.position;
        obj.transform.rotation = ShootOffset.rotation;
        obj.SetActive(true);
        Rigidbody r = obj.GetComponent<Rigidbody>();
        r.velocity = Vector3.zero;
        r.angularVelocity = Vector3.zero;
        r.AddForce(transform.forward * ShootSpeed, ForceMode.VelocityChange);      
    }
  
}
