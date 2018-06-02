using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour {

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
}
