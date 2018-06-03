using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialAnimation : MonoBehaviour {

    [SerializeField] private Material material;
    [SerializeField] private Vector2 offset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        material.SetTextureOffset("_MainTex", offset * Time.time);
    }
}
