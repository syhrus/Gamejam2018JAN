using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireZeMissiles : MonoBehaviour {

    private List<GunAim> allGuns;

    private void Start()
    {
        GameObject[] Gunz = GameObject.FindGameObjectsWithTag("Gun");
        for (int i = 0; i < Gunz.Length; i++)
        {
            allGuns.Add(Gunz[i].GetComponent<GunAim>());
        }
    }

    public void FireAll()
    {
        Debug.Log("FIRE");
        for(int i = 0; i<allGuns.Count; i++)
        {
            Debug.Log("i");
            allGuns[i].Fire();
        }
    }

}
