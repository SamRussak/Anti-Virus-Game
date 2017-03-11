using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour {
    public float lifeTime = 2f;
    public GameObject Explosion;
    //When bullet is enabled call destroy method
    void OnEnable ()
    {
        Invoke("Destroy", lifeTime);
	}
    //destroyes bullet after 2 seconds
    void Destroy()
    {
        gameObject.SetActive(false);
    }
    //cancels invoke to make sure it doesn't get called while disabled
    void OnDisable()
    {
        CancelInvoke();
    }
    //if buttel hits something, create explosion
    void OnCollisionEnter(Collision collision)
    {
        GameObject obj = ExplosionPool.current.getPoolObj();
        if (obj == null) return;

        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
        gameObject.SetActive(false);

    }


}
