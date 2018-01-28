using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireZeMissiles : MonoBehaviour {

    private List<GunAim> allGuns;
    AudioManager manager;

    private void Start()
    {
        ReinitGuns();
    }

    public void ReinitGuns()
    {
        allGuns = new List<GunAim>();
        GameObject[] Gunz = GameObject.FindGameObjectsWithTag("Gun");
        for (int i = 0; i < Gunz.Length; i++)
        {
            allGuns.Add(Gunz[i].GetComponent<GunAim>());
        }
        manager = GameObject.Find("Audiomanager").GetComponent<AudioManager>();
    }

    public void FireAll()
    {
        manager.fireOnOff = 1;
        for(int i = 0; i<allGuns.Count; i++)
        {
            allGuns[i].Fire();
        }
    }

}
