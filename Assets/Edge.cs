using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Edge : MonoBehaviour  {

    public Node start;
    public Node end;
    public LineRenderer linedrawer;

	// Use this for initialization
	void Start () {
        linedrawer = GetComponent<LineRenderer>();
        linedrawer.positionCount = 2;
        linedrawer.SetPosition(0, start.transform.position);
        linedrawer.SetPosition(1, end.transform.position);
    }
	
    public void SetNodes(Node start, Node end)
    {
        this.start = start;
        this.end = end;
    }

	// Update is called once per frame
	void Update () {
        linedrawer.SetPosition(0, start.transform.position);
        linedrawer.SetPosition(1, end.transform.position);
    }

    public void OnDrawGizmos()
    {
        if (start == null || end == null)
            return;
        Vector3 pos = start.transform.position;
        Vector3 pos2 = end.transform.position;
        Gizmos.DrawLine(pos, pos2);
    }

    public bool ConnectsTo(Node target)
    {
        return (start == target || end == target);
    }
}
