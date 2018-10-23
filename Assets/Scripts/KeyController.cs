using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour {


    public GameObject FireButton;
    public GameObject Elevator;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))

                Debug.Log("red key");
                RedKeyUpdate();
                Destroy(gameObject);
       
    }

    public void RedKeyUpdate()
    {
        FireButton.SetActive(true);
        Elevator.SetActive(true);
        Debug.Log("firebutton");
    }
}
