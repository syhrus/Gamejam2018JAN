using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenEvent : MonoBehaviour {
    
	void Start () {
        
        GameObject.Find("Audiomanager").GetComponent<AudioManager>().fireOnOff = 1;
        GameObject.Find("Audiomanager").GetComponent<AudioManager>().FadeIn(20);

        StartCoroutine(ZoomLogo());
    }

    IEnumerator ZoomLogo()
    {
        Transform pic = GameObject.Find("Lores Logo").transform;
        float i = 1;
        float delta = 0.000075f;
        while (i < 1.107)
        {
            i += delta;
            pic.localScale = pic.localScale * (1.0f + delta);
            yield return new WaitForEndOfFrame();
        }
    }
}