using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public int triggerDistance = 50; //maximum distance form screenborder to trigger camera movement
    public float movementSpeed = 10f;
    public float maxDistance = 100f;
    private Vector3 origin = Vector3.zero; //starting position of camera

    private void Start() { origin = transform.position; }
    public float TriggerDistance
    {
        get{
            return triggerDistance;
        }
    }

    private void FixedUpdate()
    {
        //Debug.Log(Input.mousePosition);
        //firstly check if mouse is in game window
        //if (Input.mousePosition.x >= 0 || Input.mousePosition.x <= Screen.width || Input.mousePosition.y >= 0 || Input.mousePosition.y <= Screen.height)
        {
            Vector3 position = transform.position;
            var delta = movementSpeed * Time.deltaTime;
            if (Input.mousePosition.x <= TriggerDistance) transform.position = new Vector3(position.x + delta, position.y, position.z);
            if (Input.mousePosition.x >= Screen.width - triggerDistance) transform.position = new Vector3(position.x - delta, position.y, position.z);
            if (Input.mousePosition.y <= TriggerDistance) transform.position = new Vector3(position.x, position.y - delta, position.z);
            if (Input.mousePosition.y >= Screen.height - triggerDistance) transform.position = new Vector3(position.x, position.y + delta, position.z);
        }
        Debug.Log(transform.position);
        //check if camera is too far away
        if (Vector3.Magnitude(transform.position - origin) >= maxDistance)
        {
            Vector2 Pos = Vector2.ClampMagnitude(new Vector2(transform.position.x - origin.x, transform.position.y - origin.y), maxDistance);
            transform.position = origin + new Vector3(Pos.x, Pos.y, 0);
        }
    }
}
