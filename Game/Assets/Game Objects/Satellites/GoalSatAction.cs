using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSatAction : MonoBehaviour {

    private List<Transform> Signals;
    private Transform[] SignalStorage;
    public int NumberOfSignals;

    private void Start()
    {
        Signals = new List<Transform>();
        SignalStorage = transform.GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        if(Signals.Count == NumberOfSignals)
        {
            Debug.Log("YOU WIN");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Projectile")
        {
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.transform.position = SignalStorage[Signals.Count + 1].position;
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            Signals.Add(other.transform);

        }
    }

    public void ClearSigs()
    {
        Signals.Clear();
    }
}
