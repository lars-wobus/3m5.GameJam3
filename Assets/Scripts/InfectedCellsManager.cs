using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectedCellsManager : MonoBehaviour {

    public IntEvent InfectedCellsChanged;

    private int infectedcells;
    public int InfectedCells
    {
        get
        {
            return infectedcells;
        }
        set
        {
            infectedcells = value;
            InfectedCellsChanged.Invoke(value);
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
