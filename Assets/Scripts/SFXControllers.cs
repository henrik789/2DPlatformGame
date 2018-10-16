using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Handles the particle effects
public class SFXControllers : MonoBehaviour
{
    public GameObject sfxCoin;
    public GameObject magicRing1;
    public static SFXControllers instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;


    }

    public void CoinSparkle(Vector3 pos){
        Instantiate(sfxCoin, pos, Quaternion.identity);        
    }

    public void MagicRing1(Vector3 pos)
    {
        //pos = new Vector3(1, 1, 6);
        Instantiate(magicRing1, pos, Quaternion.identity);
    }

}
