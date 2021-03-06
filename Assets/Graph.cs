﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class IntEvent : UnityEvent<int> { };

public class Graph : MonoBehaviour {

    public IntEvent CellCountChanged;
    
    public int cell_count;
        

    public Transform[] prefabs;
    public List<Transform> node_transforms;
    public List<Transform> edge_transforms;
    public List<Node> nodes;
    public List<Transform> organs;
    public List<Edge> edges;
    public Transform prefab_edge;

    private int edge_count = 0;


    private const int difficulty_max_thr_diff = 2;
    private const int difficulty_num_supercells = 4;
    private const int difficulty_supercell_spore_reward = 0;

    private Vector3[] vectors = {
        // Cluster oben links
        new Vector3(0, 1, 0),
        new Vector3(0, 3, 0),
        new Vector3(2, 2, 0),
        new Vector3(4, 1, 0),
        new Vector3(4, 3, 0),
        new Vector3(6, 2, 0),
        new Vector3(2, 0, 0),
        new Vector3(2, 4, 0),
        new Vector3(6, 0, 0),
        new Vector3(2, 5, 0),
        //rest of center
        new Vector3(-2, 0, 0),
        new Vector3(0, -1, 0),
        // unten rechts - 12 and on
        new Vector3(-4, 0, 0),
        new Vector3(-4, -1, 0),
        new Vector3(-2, -2, 0),
        new Vector3(0, -2, 0),
        new Vector3(-2, -3, 0),
        new Vector3(-4, -3, 0),
        new Vector3(-6, -2, 0),
        new Vector3(-6, -1, 0),
        // unten links
        new Vector3(2, -1, 0),
        new Vector3(2, -3, 0),
        new Vector3(4, -2, 0),
        new Vector3(6, -1, 0),
        new Vector3(1.5f, -4, 0),
        // oben rechts
        new Vector3(-4, 1.5f, 0),
        new Vector3(-6, 2, 0),
        new Vector3(-4, 3, 0),
        new Vector3(-2, 4, 0),
        new Vector3(-2, 2.5f, 0)

    };

    private List<int> supercells;

    private int[,] predefined_edges =
    {
        //oben links, zenter
        {0, 1 }, {0, 2 },
        {1, 2 }, {2, 3},
        {2, 4 }, {3, 5},
        {4, 5 }, {0, 6},
        {1, 7 }, {7, 4},
        {8, 5 }, {8, 3},
        {8, 6 }, {9, 4},
        {9, 7 },
        // zenter
        {0, 10 }, {10, 11}, {6, 11},
        //unten rechts
        {10, 12 }, {12, 13},
        {13, 14 }, {11, 14},
        {12, 14 }, {6, 15},
        {14, 15 }, {15, 16 },
        {14, 16 }, {16, 17},
        {17, 18 }, {13, 18},
        {12, 19 }, {13, 19},
        // unten rechts
        {6, 20 }, {8, 20},
        {15, 20 }, {20, 22},
        {15, 21 }, {16, 21},
        {21, 22 }, {21, 24},
        {22, 23 }, {23, 24},
        {23, 8 }, {24, 17 },
        // oben rechts
        {10, 25 }, {19, 25},
        {25, 27 }, {19, 26},
        {26, 27 }, {27, 28},
        {27, 29 },
        {28, 1 }, {29, 1},
        {29, 10 }

    };

    // Use this for initialization
    void Start()
    {
        System.Random rng = new System.Random();
        // Initialize vars in other classes, managers
        GetComponentInChildren<SporeCountManager>().GlobalSporeCount = 4;
        GetComponentInChildren<InfectedCellsManager>().InfectedCells = 0;



        // Determine targets
        supercells = new List<int>();
        organs = new List<Transform>();
        int rng_result;
        bool retry;
        for(int i = 0; i < difficulty_num_supercells; ) // Determine Supercells
        {
            retry = false;
            rng_result = rng.Next(0, vectors.Length);
            if (supercells.Contains(rng_result))
            {
                continue;
            }
            else
            {
                foreach (int comp in supercells)
                {
                    for(int index = 0; index < predefined_edges.Length / 2; index++)
                    {
                        if (predefined_edges[index, 0] == comp && predefined_edges[index, 1] == rng_result || predefined_edges[index, 0] == rng_result && predefined_edges[index, 1] == comp)
                            retry = true;
                    }
                }
                if(retry)
                {
                    continue;
                }
                supercells.Add(rng_result);
                i++;
            }
        }

        // Initialize Nodes
        for (int i = 0; i < vectors.Length; i++)
        {
            Transform newnode;
            if (!supercells.Contains(i))
            {
                newnode = Instantiate(prefabs[0], vectors[i], Quaternion.identity);
            }
            else
            {
                newnode = Instantiate(prefabs[2], vectors[i], Quaternion.identity);
                if(organs.Count < 1) //Teeth
                {
                    organs.Add(Instantiate(prefabs[3], vectors[i], Quaternion.identity, newnode));
                }
                else
                {
                    if (organs.Count < 3) // Feet
                    {
                        organs.Add(Instantiate(prefabs[4], vectors[i] - new Vector3(0, 0.33f, 0), Quaternion.identity, newnode));
                    }
                    else
                    {
                        if(organs.Count < 4) // Spooky floating eyeballs
                        {
                            organs.Add(Instantiate(prefabs[5], vectors[i], Quaternion.identity, newnode));
                        }
                    }
                }
            }
            node_transforms.Add(newnode);
            newnode.parent = transform;
        }
        nodes = new List<Node>();
        Node n;
        for (int i = 0; i < node_transforms.Count; i++)
        {
            n = node_transforms[i].GetComponent<Node>();
            var cmc = n.GetComponent<ChangeMaterialColor>();
            n.SporeCountChanged.AddListener(cmc.InterpolateMaterialProperties);
            n.isSupercell = supercells.Contains(i);
            nodes.Add(n);
        }
        cell_count = nodes.Count;
        CellCountChanged.Invoke(cell_count);
        

        edge_transforms = new List<Transform>();
        edges = new List<Edge>();
        for (int i = 0; i < predefined_edges.Length / 2; i++)
            edge_transforms.Add(Instantiate(prefabs[1]));
        for (int i = 0; i < predefined_edges.Length / 2; i++)
            edges.Add(edge_transforms[i].GetComponent<Edge>());


        for(int i = 0; i < predefined_edges.Length / 2; i++)
        {
            initEdge(predefined_edges[i, 0], predefined_edges[i, 1]);
        }

        // Init Threshholds
        int organs_created = 0;
        for (int i = 0; i < node_transforms.Count; i++)
        {
            n = node_transforms[i].GetComponent<Node>();
            n.Treshhold = rng.Next(Mathf.Max(2, n.neighbours.Count - difficulty_max_thr_diff), n.neighbours.Count);
            node_transforms[i].transform.localScale = new Vector3(0.2f + 0.15f * n.Treshhold, 0.2f + 0.15f * n.Treshhold, 0.2f + 0.15f * n.Treshhold);
            if(nodes[i].isSupercell)
            {
                organs[organs_created].localScale.Scale(new Vector3(0.2f + 0.15f * n.Treshhold, 0.15f + 0.15f * n.Treshhold, 0.15f + 0.15f * n.Treshhold));
                //organs[organs_created].localScale = new Vector3(0.2f + 0.15f * n.Treshhold, 0.15f + 0.15f * n.Treshhold, 0.15f + 0.15f * n.Treshhold);
                if(organs_created < 3 && organs_created > 0) //its a feet
                {
                    organs[organs_created].Rotate(new Vector3(0, 90, 0));
                }
                organs_created++;
            }
        }
        // Create supercell contents
    }



    internal void CleanUp(Node node)
    {
        int num_edges = edges.Count;
        for(int i = num_edges - 1; i >= 0; i--)
        {
            if(edges[i].ConnectsTo(node))
            {
                edge_transforms[i].gameObject.SetActive(false);
                edges.RemoveAt(i);
                edge_transforms.RemoveAt(i);
            }
        }
    }

    private void initEdge(int start, int end)
    {
        edges[edge_count].SetNodes(nodes[start], nodes[end]);
        nodes[start].AddNeighbour(nodes[end]);
        nodes[end].AddNeighbour(nodes[start]);
        edge_count++;
    }
	
	// Update is called once per frame
	void Update () {

    }
}
