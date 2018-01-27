using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteRotate : MonoBehaviour {
    private bool isClicked;
    public float rotateSpeed = 1f;


    void Start()
    {
        isClicked = false;
    }

    void OnMouseDown()
    {
        isClicked = true;
        //Debug.Log("CLICK");
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            isClicked = false;
        };

        if (isClicked)
        {
            //float MouseDelta = Input.GetAxis("Mouse X");
            //Debug.Log("Change: " + MouseDelta);
            //transform.Rotate(new Vector3(0, 0, -1), MouseDelta * rotateSpeed);

            Vector3 mouse_pos = Input.mousePosition;
            mouse_pos.z = 0f; //The distance between the camera and object
            Vector3 object_pos = Camera.main.WorldToScreenPoint(transform.position);
            mouse_pos.x = mouse_pos.x - object_pos.x;
            mouse_pos.y = mouse_pos.y - object_pos.y;
            float angle = (Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg)- 90.0f;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        }
    }
}
