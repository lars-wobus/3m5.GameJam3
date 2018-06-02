using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    public List<Node> neighbours = new List<Node>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddNeighbour(Node newnode)
    {
        if (!neighbours.Contains(newnode))
            neighbours.Add(newnode);
    }

}
