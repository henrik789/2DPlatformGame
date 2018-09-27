using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {
    public float speed;
    float offsetX;
    Material mat;

	void Start () {
        mat = GetComponent<Renderer>().material;
	}

	void Update () {
        offsetX += Input.GetAxisRaw("Horizontal") * speed;
        mat.SetTextureOffset("_MainTex", new Vector2(offsetX, 0));
	}
}
