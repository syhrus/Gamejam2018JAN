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
        Debug.Log("CLICK");
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            isClicked = false;
        };

        if (isClicked)
        {
            float MouseDelta = Input.GetAxis("Mouse X");
            Debug.Log("Change: " + MouseDelta);

            transform.Rotate(new Vector3(0, 0, -1), MouseDelta * rotateSpeed);
        }
    }
}
