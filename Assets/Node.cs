using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class FloatEvent : UnityEvent<float> { };

public class Node : MonoBehaviour {



    public List<Node> neighbours = new List<Node>();
    public int Treshhold { get; set; }
    public bool isSupercell;

    private Graph map;
    private InfectedCellsManager InfectedCellsManger;

    public FloatEvent SporeCountChanged;

    private static int MinSporeCount = 0;
    private static int MaxSporeCount = 10;

    [SerializeField] private int sporeCount = 0;

    private SporeCountManager SporeCountManager { get; set;}

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
            if(SporeCountChanged == null)
            {
                return;
            }
            SporeCountChanged.Invoke((float)sporeCount / Treshhold);
        }
    }

    // Use this for initialization
    void Start () {
        var parent = transform.parent;
        map = parent.GetComponent<Graph>();
        SporeCountManager = parent.GetComponentInChildren<SporeCountManager>();
        InfectedCellsManger = parent.GetComponentInChildren<InfectedCellsManager>();
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
        if (SporeCount >= Treshhold) //already activated
        {
            return;
        }
        SporeCount += spores;
        if(SporeCount < Treshhold)
        {
            return;
        }
        // -> Node activated
        if(isSupercell)
        {
            SporeCountManager.GlobalSporeCount++;
        }
        map.CleanUp(this);
        map.cell_count--;
        InfectedCellsManger.InfectedCells++;
        if (map.CellCountChanged == null)
        {
            return;
        }
        map.CellCountChanged.Invoke(map.cell_count);
        transform.gameObject.SetActive(false);
        foreach (Node next in neighbours)
        {
            next.AddSpores(1);
        }
    }

    public void Activate()
    {
        if (!isSupercell || sporeCount == 0)
        {
            AddSpores(Treshhold - sporeCount);
            SporeCountManager.GlobalSporeCount--;
            InfectedCellsManger.InfectedCells++;
            return;
        }
        Debug.Log("Invalid move!");
    }

}
