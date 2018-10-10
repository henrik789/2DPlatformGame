using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

    public enum CoinFX{
        Vanish, fly
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);
    }

    public CoinFX coinFX;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            if (coinFX == CoinFX.Vanish){
                Destroy(gameObject);
            }
    }
}
