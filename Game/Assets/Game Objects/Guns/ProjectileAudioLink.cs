using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAudioLink : MonoBehaviour {

    public AudioManager.Track thisTrack;

    Vector3 origPos;
    private void Start()
    {
        origPos = transform.position;
    }

    private void Update()
    {
        Vector3 moveDirection = gameObject.transform.position - origPos;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
        }
    }
}
