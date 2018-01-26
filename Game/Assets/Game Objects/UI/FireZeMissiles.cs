using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireZeMissiles : MonoBehaviour {

    public List<GunAim> allGuns;

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
