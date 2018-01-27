using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD;

public class AudioManager : MonoBehaviour
{

    //singleton
    public static AudioManager instance;

    FMOD.Studio.EventInstance music01Event;
    FMOD.Studio.ParameterInstance fireParameter;

    FMOD.Studio.ParameterInstance bassEffectParameter;
    FMOD.Studio.ParameterInstance synthEffectParameter;
    FMOD.Studio.ParameterInstance drumsEffectParameter;
    FMOD.Studio.ParameterInstance harmonysEffectParameter;

    public enum EffectType { CLEAN, BITCRUSH, REVERB, RINGMOD, FLANGE, SQUELCH, VOICE };
    public enum Track { Bass, Synth, Drums, Harmonys, None };

    public int fireOnOff = 0;
    public int bassEffectIndex = 0;
    public int synthEffectIndex = 0;
    public int drumsEffectIndex = 0;
    public int harmonysEffectIndex = 0;

    public void FadeIn(float seconds)
    {
        StartCoroutine(FadeInRoutine(seconds));
    }

    private IEnumerator FadeInRoutine(float seconds)
    {
        float fadeInDelta = 1 / (seconds*20);
        for (float i = 0.0f; i < 1; i += fadeInDelta)
        {
            music01Event.setVolume(i);
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void SetVolumeHard(float volume)
    {

        music01Event.setVolume(volume);
    }
    private void Awake()
    {
        //singleton
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        music01Event = FMODUnity.RuntimeManager.CreateInstance("event:/Music01");
        music01Event.getParameter("Fire", out fireParameter);

        music01Event.getParameter("BassEffect", out bassEffectParameter);
        music01Event.getParameter("SynthEffect", out synthEffectParameter);
        music01Event.getParameter("DrumsEffect", out drumsEffectParameter);
        music01Event.getParameter("HarmonyEffect", out harmonysEffectParameter);

        music01Event.start();
        music01Event.setVolume(0);
    }

    // Update is called once per frame
    void Update()
    {
        fireParameter.setValue(fireOnOff);

        bassEffectParameter.setValue(bassEffectIndex);
        synthEffectParameter.setValue(synthEffectIndex);
        drumsEffectParameter.setValue(drumsEffectIndex);
        harmonysEffectParameter.setValue(harmonysEffectIndex);

    }

    public void startAllAudio()
    {
        music01Event.start();
        UnityEngine.Debug.Log("music start?");
    }


    public void resetAudioEffects()
    {
        bassEffectIndex = 0;
    }

    public void AddEffect(EffectType effectType, float effectStrength, Track track)
    {

        switch (track)
        {
            case Track.Bass:
                {
                    switch (effectType)
                    {
                        case EffectType.CLEAN:
                            {
                                bassEffectIndex = 0;
                                break;
                            }
                        case EffectType.BITCRUSH:
                            {
                                bassEffectIndex = 1;
                                break;
                            }
                        case EffectType.REVERB:
                            {
                                bassEffectIndex = 2;
                                break;
                            }
                        case EffectType.RINGMOD:
                            {
                                bassEffectIndex = 3;
                                break;
                            }
                        case EffectType.FLANGE:
                            {
                                bassEffectIndex = 4;
                                break;
                            }
                        case EffectType.SQUELCH:
                            {
                                bassEffectIndex = 5;
                                break;
                            }
                        case EffectType.VOICE:
                            {
                                bassEffectIndex = 6;
                                break;
                            }
                    }
                    break;
                };
            case Track.Synth:
                {
                    switch (effectType)
                    {
                        case EffectType.CLEAN:
                            {
                                synthEffectIndex = 0;
                                break;
                            }
                        case EffectType.BITCRUSH:
                            {
                                synthEffectIndex = 1;
                                break;
                            }
                        case EffectType.REVERB:
                            {
                                synthEffectIndex = 2;
                                break;
                            }
                        case EffectType.RINGMOD:
                            {
                                synthEffectIndex = 3;
                                break;
                            }
                        case EffectType.FLANGE:
                            {
                                synthEffectIndex = 4;
                                break;
                            }
                        case EffectType.SQUELCH:
                            {
                                synthEffectIndex = 5;
                                break;
                            }
                        case EffectType.VOICE:
                            {
                                synthEffectIndex = 6;
                                break;
                            }
                    }
                    break;
                };
            case Track.Drums:
                {
                    switch (effectType)
                    {
                        case EffectType.CLEAN:
                            {
                                drumsEffectIndex = 0;
                                break;
                            }
                        case EffectType.BITCRUSH:
                            {
                                drumsEffectIndex = 1;
                                break;
                            }
                        case EffectType.REVERB:
                            {
                                drumsEffectIndex = 2;
                                break;
                            }
                        case EffectType.RINGMOD:
                            {
                                drumsEffectIndex = 3;
                                break;
                            }
                        case EffectType.FLANGE:
                            {
                                drumsEffectIndex = 4;
                                break;
                            }
                        case EffectType.SQUELCH:
                            {
                                drumsEffectIndex = 5;
                                break;
                            }
                        case EffectType.VOICE:
                            {
                                drumsEffectIndex = 6;
                                break;
                            }
                    }
                    break;
                };
            case Track.Harmonys:
                {
                    switch (effectType)
                    {
                        case EffectType.CLEAN:
                            {
                                harmonysEffectIndex = 0;
                                break;
                            }
                        case EffectType.BITCRUSH:
                            {
                                harmonysEffectIndex = 1;
                                break;
                            }
                        case EffectType.REVERB:
                            {
                                harmonysEffectIndex = 2;
                                break;
                            }
                        case EffectType.RINGMOD:
                            {
                                harmonysEffectIndex = 3;
                                break;
                            }
                        case EffectType.FLANGE:
                            {
                                harmonysEffectIndex = 4;
                                break;
                            }
                        case EffectType.SQUELCH:
                            {
                                harmonysEffectIndex = 5;
                                break;
                            }
                        case EffectType.VOICE:
                            {
                                harmonysEffectIndex = 6;
                                break;
                            }
                    }
                    break;
                };
            default:
                {
                    break;
                }
        }
    }
}
