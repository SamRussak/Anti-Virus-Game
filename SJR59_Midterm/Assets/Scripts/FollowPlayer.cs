using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //Has Camera follow players movements and rotation
    public Transform target;
    public Vector3 offsetPosition;
    private Space offset = Space.Self;
    private bool seen = true;

    private void Update()
    {
        // compute position of player according to camera postion
        if(offset == Space.Self)
        {
            transform.position = target.TransformPoint(offsetPosition);
        }
        else
        {
            transform.position = target.position + offsetPosition;
        }

        // compute rotation of player 
        if(seen)
        {
            transform.LookAt(target);
        }
        else
        {
            transform.rotation = target.rotation;
        }
    }

}
