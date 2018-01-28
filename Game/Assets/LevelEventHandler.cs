using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEventHandler : MonoBehaviour {

    public int BassEffect = 0;
    public int SynthEffect = 0;
    public int HarmonyEffect = 0;
    public int DrumsEffect = 0;
    public int Level = 1;
    AudioManager manager;

    private void OnEnable()
    {
        manager = GameObject.Find("Audiomanager").GetComponent<AudioManager>();

        manager.SetVolumeHard(0);
        manager.fireOnOff = 0;
        manager.FadeIn(2);
    }

    public void LoadNextLevel()
    {
        manager.StopAudio();
        SceneManager.LoadScene(Level++, LoadSceneMode.Single);
    }
}
