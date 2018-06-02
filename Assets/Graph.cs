using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {

    public Transform[] prefabs;
    public List<Transform> node_transforms;
    public List<Transform> edge_transforms;
    public List<Node> nodes;
    public List<Edge> edges;
    public Transform prefab_edge;

    int num_edges = 7;


    // Use this for initialization
    void Start () {
        node_transforms.Add(Instantiate(prefabs[0], new Vector3(0, 1, 0), Quaternion.identity));
        node_transforms.Add(Instantiate(prefabs[0], new Vector3(0, 3, 0), Quaternion.identity));
        node_transforms.Add(Instantiate(prefabs[0], new Vector3(2, 2, 0), Quaternion.identity));
        node_transforms.Add(Instantiate(prefabs[0], new Vector3(4, 1, 0), Quaternion.identity));
        node_transforms.Add(Instantiate(prefabs[0], new Vector3(4, 3, 0), Quaternion.identity));
        node_transforms.Add(Instantiate(prefabs[0], new Vector3(6, 2, 0), Quaternion.identity));
        nodes = new List<Node>();
        for (int i = 0; i < node_transforms.Count; i++)
            nodes.Add(node_transforms[i].GetComponent<Node>());
        edge_transforms = new List<Transform>();
        edges = new List<Edge>();
        for (int i = 0; i < num_edges; i++)
            edge_transforms.Add(Instantiate(prefabs[1]));
        for (int i = 0; i < num_edges; i++)
            edges.Add(edge_transforms[i].GetComponent<Edge>());
        initEdge(0, 0, 1);
        initEdge(1, 0, 2);
        initEdge(2, 1, 2);
        initEdge(3, 2, 3);
        initEdge(4, 2, 4);
        initEdge(5, 3, 5);
        initEdge(6, 4, 5);

    }

    private void initEdge(int index, int start, int end)
    {
        edges[index].SetNodes(nodes[start], nodes[end]);
        nodes[start].AddNeighbour(nodes[end]);
        nodes[end].AddNeighbour(nodes[start]);
    }
	
	// Update is called once per frame
	void Update () {

    }
}
