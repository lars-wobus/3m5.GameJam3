using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    

    public List<Node> neighbours = new List<Node>();
    public int Treshhold { get; set; }
    public int ID { get; set; }

    private static int MinSporeCount = 0;
    private static int MaxSporeCount = 10;

    [SerializeField] private int sporeCount = 0;

    public int SporeCount
    {
        get
        {
            return sporeCount;
        }
        set
        {
            var tmp = Mathf.Clamp(value, MinSporeCount, MaxSporeCount);
            if (tmp == sporeCount)
            {
                return;
            }
            sporeCount = tmp;
        }
    }

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

    public void AddSpores(int spores)
    {
        if (SporeCount >= Treshhold)
        {
            return;
        }
        SporeCount += spores;
        if(SporeCount < Treshhold)
        {
            return;
        }
        // -> Node activated
        transform.parent.GetComponent<Graph>().CleanUp(this);
        transform.gameObject.SetActive(false);
        foreach (Node next in neighbours)
        {
            next.AddSpores(1);
        }
    }

    public void Activate()
    {
        AddSpores(Treshhold - sporeCount);
    }

}
