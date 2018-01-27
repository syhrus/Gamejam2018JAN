using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour {

    GameObject[] oneUse;

    private void Start()
    {
        oneUse = GameObject.FindGameObjectsWithTag("NeedsReset");
    }

    public void ResetLevel()
    {
        GameObject[] goals = GameObject.FindGameObjectsWithTag("Goal");
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile");
        GameObject[] guns = GameObject.FindGameObjectsWithTag("Gun");
        

        for (int i = 0; i < projectiles.Length; i++)
        {
            Destroy(projectiles[i]);
        }

        for (int i = 0; i < goals.Length; i++)
        {
            goals[i].GetComponent<GoalSatAction>().ClearSigs();
        };

        for(int i = 0; i < guns.Length; i++)
        {
            guns[i].GetComponent<GunAim>().canFire = true;
        }
        for (int i = 0; i < oneUse.Length; i++)
        {
            oneUse[i].SetActive(true);
        }
    }
}
