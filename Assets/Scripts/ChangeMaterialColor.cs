using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialColor : MonoBehaviour {

    public Material StartMaterial { get; private set; }
    public Material EndMaterial { get; private set; }

    private Renderer Renderer {get; set;}
    //private SporeColorManager SporeColorManager { get; set; }


	// Use this for initialization
	void Start () {
        Renderer = GetComponent<Renderer>();
        var sporeColorManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<SporeColorManager>();
        StartMaterial = sporeColorManager.GetMaterial(0);
        EndMaterial = sporeColorManager.GetMaterial(1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InterpolateMaterialProperties(float value)
    {
        Debug.Log(value);
        Debug.Log(StartMaterial);
        Debug.Log(EndMaterial);
        Renderer.material.Lerp(StartMaterial, EndMaterial, value);
    }
}
