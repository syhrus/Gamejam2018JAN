using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

    int Level;
    AudioManager manager;

    private void Start()
    {
        manager = GameObject.Find("Audiomanager").GetComponent<AudioManager>();
        Level = GameObject.Find("LevelEventHandler").GetComponent<LevelEventHandler>().Level;
    }

    public void LoadNextLevel()
    {
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile");

        for (int i = 0; i < 4; i++)
        {
            switch (projectiles[i].GetComponent<ProjectileAudioLink>().thisTrack)
            {
                case AudioManager.Track.Bass:
                    {
                        GameObject.Find("LevelEventHandler").GetComponent<LevelEventHandler>().BassEffect = projectiles[i].GetComponent<ProjectileAudioLink>().currentEffect;
                        break;
                    }
                case AudioManager.Track.Drums:
                    {
                        GameObject.Find("LevelEventHandler").GetComponent<LevelEventHandler>().DrumsEffect = projectiles[i].GetComponent<ProjectileAudioLink>().currentEffect;
                        break;
                    }
                case AudioManager.Track.Harmonys:
                    {
                        GameObject.Find("LevelEventHandler").GetComponent<LevelEventHandler>().HarmonyEffect = projectiles[i].GetComponent<ProjectileAudioLink>().currentEffect;
                        break;
                    }
                case AudioManager.Track.Synth:
                    {
                        GameObject.Find("LevelEventHandler").GetComponent<LevelEventHandler>().SynthEffect = projectiles[i].GetComponent<ProjectileAudioLink>().currentEffect;
                        break;
                    }
            }
        }


        manager.StopAudio();
        GameObject.Find("LevelEventHandler").GetComponent<LevelEventHandler>().Level++;
        SceneManager.LoadScene(Level+1, LoadSceneMode.Single);
        GameObject.Find("FireButton").GetComponent<FireZeMissiles>().ReinitGuns();
        manager.startAllAudio();
        manager.SetVolumeHard(0);
        manager.fireOnOff = 0;
        manager.FadeIn(2);
    }
}
