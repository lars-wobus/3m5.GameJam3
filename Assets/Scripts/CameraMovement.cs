using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour {

    public int triggerDistance = 50; //maximum distance form screenborder to trigger camera movement
    public float movementSpeed = 10f;
    public float maxDistance = 100f;
    private Vector3 origin = Vector3.zero; //starting position of camera

    private void Start() { origin = transform.position; }

    private void FixedUpdate()
    {
        //firstly check if mouse is in game window
        if (Input.mouse.position.x >= 0 & Input.mouse.position.x <= Screen.width & Input.mouse.position.y >= 0 & Input.mouse.position.y <= Screen.height)
        { 
            if (Input.mouse.position.x <= TriggerDistance) transform.position.x -= movementSpeed * Time.deltaTime;
            if (Input.mouse.position.x >= Screen.width - triggerDistance) transform.position.x += movementSpeed * Time.deltaTime;
            if (Input.mouse.position.y <= TriggerDistance) transform.position.y -= movementSpeed * Time.deltaTime;
            if (Input.mouse.position.y >= Screen.height - triggerDistance) transform.position.y += movementSpeed * Time.deltaTime;
        }

        //check if camera is too far away
        if (Vector3.Magnitude(transform.position - origin) >= maxDistance)
        {
            Vector2 Pos = Vector2.ClampMagnitude(new Vector2(transform.position.x - origin.x, transform.y - origin.y));
            transform.position = origin + new Vector3(Pos.x, Pos.y, 0);
        }
    }
}
