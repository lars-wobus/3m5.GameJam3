using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {

    public Transform[] prefabs;
    public List<Transform> nodes;
    public List<Edge> edges;
    public Transform prefab_edge;

    int num_edges = 7;


    // Use this for initialization
    void Start () {
        nodes.Add(Instantiate(prefabs[0], new Vector3(0, 1, 0), Quaternion.identity));
        nodes.Add(Instantiate(prefabs[0], new Vector3(2, 3, 0), Quaternion.identity));
        nodes.Add(Instantiate(prefabs[0], new Vector3(2, 2, 0), Quaternion.identity));
        nodes.Add(Instantiate(prefabs[0], new Vector3(4, 1, 0), Quaternion.identity));
        nodes.Add(Instantiate(prefabs[0], new Vector3(4, 3, 0), Quaternion.identity));
        nodes.Add(Instantiate(prefabs[0], new Vector3(6, 2, 0), Quaternion.identity));

        for(int i = 0; i < num_edges; i++)
            edges.Add(Instantiate(prefabs[1]).GetComponent<Edge>());
        edges[0].SetNodes(nodes[0].GetComponent<Node>(), nodes[1].GetComponent<Node>());
        edges[1].SetNodes(nodes[0].GetComponent<Node>(), nodes[2].GetComponent<Node>());
        edges[2].SetNodes(nodes[1].GetComponent<Node>(), nodes[2].GetComponent<Node>());
        edges[3].SetNodes(nodes[2].GetComponent<Node>(), nodes[3].GetComponent<Node>());
        edges[4].SetNodes(nodes[2].GetComponent<Node>(), nodes[4].GetComponent<Node>());
        edges[5].SetNodes(nodes[3].GetComponent<Node>(), nodes[5].GetComponent<Node>());
        edges[6].SetNodes(nodes[4].GetComponent<Node>(), nodes[5].GetComponent<Node>());

    }
	
	// Update is called once per frame
	void Update () {
    }
}
