using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEventHandler : MonoBehaviour {

    public int BassEffect = 0;
    public int SynthEffect = 0;
    public int HarmonyEffect = 0;
    public int DrumsEffect = 0;
    public int Level = 0;

    private void OnEnable()
    {
        AudioManager manager = GameObject.Find("Audiomanager").GetComponent<AudioManager>();

        manager.SetVolumeHard(0);
        manager.fireOnOff = 0;
        manager.FadeIn(2);
    }
}
