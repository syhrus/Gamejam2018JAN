using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IonStormAction : MonoBehaviour {

    private Color lerpedColor;
    private float lerpValue = Random.Range(0,1);
    private float flip = 1.0f;
    public Color colour1;
    public Color colour2;
	
	void Update () {
        lerpedColor = Color.Lerp( colour1, colour2, lerpValue);
        
        lerpValue += 0.01f * flip * Random.Range(0.5f,1.5f);

        if(lerpValue > 1)
        {
            lerpValue = 1.0f;
            flip = -1.0f;
        }
        if(lerpValue < 0)
        {
            lerpValue = 0.0f;
            flip = 1.0f;
        }

        GetComponent<Light>().color = lerpedColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Projectile")
        {
            Destroy(other.gameObject);
        }
    }
}
