using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEventHandler : MonoBehaviour {

    public AudioManager.EffectType BassEffect;
    public AudioManager.EffectType SynthEffect;
    public AudioManager.EffectType HarmonyEffect;
    public AudioManager.EffectType DrumsEffect;
    public int Level = 1;
    AudioManager manager;

    private void OnEnable()
    {
        DontDestroyOnLoad(gameObject);
        manager = GameObject.Find("Audiomanager").GetComponent<AudioManager>();

        manager.SetVolumeHard(0);
        manager.fireOnOff = 0;
        manager.FadeIn(2);
    }

    

    
}
