using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour {

    SporeCountManager sporecounter;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var clickableObject = DoRayCastToFindClickableGameObjects();
            if(clickableObject == null)
            {
                return;
            }
            clickableObject.Activate();
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            sporecounter.GlobalSporeCount++;
        }
    }

    private Node DoRayCastToFindClickableGameObjects()
    {
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
        if (!hit)
        {
            return null;
        }
        return hitInfo.transform.GetComponent<Node>();
    }

    private void Start()
    {
        sporecounter = GameObject.FindGameObjectWithTag("SporeCount").GetComponent<SporeCountManager>();
    }
}
