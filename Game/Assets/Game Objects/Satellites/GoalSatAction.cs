using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSatAction : MonoBehaviour {

    private List<Transform> Signals;
    private Transform[] SignalStorage;
    public float timeOut;
    public bool Win = false;
    private GameObject winButton;


    private void Start()
    {
        Signals = new List<Transform>();
        SignalStorage = transform.GetComponentsInChildren<Transform>();
        winButton = GameObject.Find("Next Level Button");
    }

    private void Update()
    {
        if(Signals.Count == SignalStorage.Length - 1)
        {
            Debug.Log("YOU WIN");
            Win = true;
        }
        winButton.SetActive(Win);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.transform.position = SignalStorage[Signals.Count + 1].position;
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            Signals.Add(other.transform);
            StartCoroutine(SignalTimer(other.transform, SignalStorage[Signals.Count]));
        }
    }

    public void ClearSigs()
    {
        Signals.Clear();
        for (int i = 1; i < SignalStorage.Length; i++)
        {
            SignalStorage[i].GetComponent<Light>().range = 0;
        }
    }

    private IEnumerator SignalTimer(Transform signal, Transform Location)
    {
        Location.GetComponent<Light>().range = 1;
        float delta = 1 / (10 * timeOut);

        while (Location.GetComponent<Light>().range > 0 && !Win)
        {
            yield return new WaitForSeconds(0.1f);
            Location.GetComponent<Light>().range -= delta;
        }

        if (!Win)
        {
            Signals.Remove(signal);
            Destroy(signal.gameObject);
        }
        else
        {
            Location.GetComponent<Light>().range = 1;
            Location.GetComponent<Light>().color = Color.white;
        }

    }
}
