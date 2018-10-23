using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeControl : MonoBehaviour
{

    Transform bridgeTransform;
    public float speedBoost;
    private int direction = 1;
    ////public float upForce;
    //void Start()
    //{

    //}


    void Update()
    {

        Vector3 position = transform.position;
        position.y += speedBoost * direction;
        //position.y *= upForce;
        transform.position = position;


        if (position.y > 5f || position.y < -5.5f)
        {
            direction *= -1;
        }
    }
}