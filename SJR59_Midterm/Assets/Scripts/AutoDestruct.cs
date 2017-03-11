using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestruct : MonoBehaviour {
    public ParticleSystem PS;
    private bool marked = false;
    //set explosion to inactive once it has stopped
	void Update ()
    {
        if (PS.isStopped)
        {           
            gameObject.SetActive(false);
        }
	}
}
