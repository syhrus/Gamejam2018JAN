using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenevent : MonoBehaviour {

	void OnEnable () {
        GameObject.Find("Audiomanager").GetComponent<AudioManager>().startAllAudio();
        GameObject.Find("Audiomanager").GetComponent<AudioManager>().Win(true);
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            Application.Quit();
        }
    }
}
