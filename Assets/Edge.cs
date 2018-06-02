using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour {

    public Node start;
    public Node end;
    public LineRenderer linedrawer;

	// Use this for initialization
	void Start () {
        linedrawer = GetComponent<LineRenderer>();
        linedrawer.positionCount = 2;
        linedrawer.SetPosition(0, start.transform.position);
        linedrawer.SetPosition(1, end.transform.position);
        Debug.Log(start.transform.position);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDrawGizmos()
    {
        if (start == null || end == null)
            return;
        Vector3 pos = start.transform.position;
        Vector3 pos2 = end.transform.position;
        Gizmos.DrawLine(pos, pos2);
    }
}
