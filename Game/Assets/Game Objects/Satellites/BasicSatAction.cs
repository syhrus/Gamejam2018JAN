using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSatAction : MonoBehaviour {

    public float WaitForSeconds = 2;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if(other.tag == "Projectile")
        {
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.transform.position = transform.position;

            StartCoroutine(WaitThenLaunch(other));
        }
    }

    IEnumerator WaitThenLaunch(Collider other)
    {
        yield return new WaitForSeconds(WaitForSeconds);

        other.GetComponent<Rigidbody>().AddForce(transform.up, ForceMode.Impulse);
    }
}
