using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform2 : MonoBehaviour {

    Transform platformTransform;
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


        if (position.y > -4.7f || position.y < -11f)
        {
            direction *= -1;
        }
    }
}
