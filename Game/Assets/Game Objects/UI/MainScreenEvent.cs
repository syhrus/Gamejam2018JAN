using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenEvent : MonoBehaviour {

    bool showMenu = false;
    GameObject instructions;

	void Start () {
        
        GameObject.Find("Audiomanager").GetComponent<AudioManager>().fireOnOff = 2;
        GameObject.Find("Audiomanager").GetComponent<AudioManager>().FadeIn(20);
        instructions = GameObject.Find("InstructionScreen");
        StartCoroutine(ZoomLogo());
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            showMenu = true;
        }
        instructions.SetActive(showMenu);
    }

    public void LoadLevel()
    {
        GameObject.Find("Audiomanager").GetComponent<AudioManager>().StopAudio();
        Destroy(GameObject.Find("Audiomanager"));
        SceneManager.LoadScene("Level01", LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
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