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

    public void Fire()
    {
        fireOnOff = 1;
    }

    public void Calm()
    {
        fireOnOff = 0;
    }

    public void StopAudio()
    {
        music01Event.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
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
                                //bassEffectIndex = 0;
                                break;
                            }
                        case EffectType.BITCRUSH:
                            {
								if (bassEffectIndex == 1) 
								{
									bassEffectIndex = 0;
								}
								else 
								{
									bassEffectIndex = 1;
								}
								break;
                            }
                        case EffectType.REVERB:
                            {
								if (bassEffectIndex == 2) 
								{
									bassEffectIndex = 0;
								}
								else 
								{
									bassEffectIndex = 2;
								}
								break;
                            }
                        case EffectType.RINGMOD:
                            {
								if (bassEffectIndex == 3) 
								{
									bassEffectIndex = 0;
								}
								else 
								{
									bassEffectIndex = 3;
								}
								break;
                            }
                        case EffectType.FLANGE:
                            {
								if (bassEffectIndex == 4) 
								{
									bassEffectIndex = 0;
								}
								else 
								{
									bassEffectIndex = 4;
								}
								break;
                            }
                        case EffectType.SQUELCH:
                            {
								if (bassEffectIndex == 5) 
								{
									bassEffectIndex = 0;
								}
								else 
								{
									bassEffectIndex = 5;
								}
								break;
                            }
                        case EffectType.VOICE:
                            {
								if (bassEffectIndex == 6) 
								{
									bassEffectIndex = 0;
								}
								else 
								{
									bassEffectIndex = 6;
								}
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
                                //synthEffectIndex = 0;
                                break;
                            }
                        case EffectType.BITCRUSH:
                            {
								if (synthEffectIndex == 1) 
								{
									synthEffectIndex = 0;
								}
								else 
								{
									synthEffectIndex = 1;
								}
								break;
                            }
                        case EffectType.REVERB:
							{
								if (synthEffectIndex == 2) 
								{
									synthEffectIndex = 0;
								}
								else 
								{
									synthEffectIndex = 2;
								}
								break;
							}
                        case EffectType.RINGMOD:
                            {
								if (synthEffectIndex == 3) 
								{
									synthEffectIndex = 0;
								}
								else 
								{
									synthEffectIndex = 3;
								}
								break;
                            }
                        case EffectType.FLANGE:
                            {
								if (synthEffectIndex == 4) 
								{
									synthEffectIndex = 0;
								}
								else 
								{
									synthEffectIndex = 4;
								}
								break;
                            }
                        case EffectType.SQUELCH:
                            {
								if (synthEffectIndex == 5) 
								{
									synthEffectIndex = 0;
								}
								else 
								{
									synthEffectIndex = 5;
								}
								break;
                            }
                        case EffectType.VOICE:
                            {
								if (synthEffectIndex == 6) 
								{
									synthEffectIndex = 0;
								}
								else 
								{
									synthEffectIndex = 6;
								}
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
                                //drumsEffectIndex = 0;
                                break;
                            }
                        case EffectType.BITCRUSH:
                            {
								if (drumsEffectIndex == 1) 
								{
									drumsEffectIndex = 0;
								}
								else 
								{
									drumsEffectIndex = 1;
								}
								break;
                            }
                        case EffectType.REVERB:
                            {
								if (drumsEffectIndex == 2) 
								{
									drumsEffectIndex = 0;
								}
								else 
								{
									drumsEffectIndex = 2;
								}
								break;
                            }
                        case EffectType.RINGMOD:
                            {
								if (drumsEffectIndex == 3) 
								{
									drumsEffectIndex = 0;
								}
								else 
								{
									drumsEffectIndex = 3;
								}
								break;
                            }
                        case EffectType.FLANGE:
                            {
								if (drumsEffectIndex == 4) 
								{
									drumsEffectIndex = 0;
								}
								else 
								{
									drumsEffectIndex = 4;
								}
								break;
                            }
                        case EffectType.SQUELCH:
                            {
								if (drumsEffectIndex == 5) 
								{
									drumsEffectIndex = 0;
								}
								else 
								{
									drumsEffectIndex = 5;
								}
								break;
                            }
                        case EffectType.VOICE:
                            {
								if (drumsEffectIndex == 6) 
								{
									drumsEffectIndex = 0;
								}
								else 
								{
									drumsEffectIndex = 6;
								}
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
                                //harmonysEffectIndex = 0;
                                break;
                            }
                        case EffectType.BITCRUSH:
                            {
								if (harmonysEffectIndex == 1) 
								{
									harmonysEffectIndex = 0;
								}
								else 
								{
									harmonysEffectIndex = 1;
								}
								break;
                            }
                        case EffectType.REVERB:
                            {
								if (harmonysEffectIndex == 2) 
								{
									harmonysEffectIndex = 0;
								}
								else 
								{
									harmonysEffectIndex = 2;
								}
								break;
                            }
                        case EffectType.RINGMOD:
                            {
								if (harmonysEffectIndex == 3) 
								{
									harmonysEffectIndex = 0;
								}
								else 
								{
									harmonysEffectIndex = 3;
								}
								break;
                            }
                        case EffectType.FLANGE:
                            {
								if (harmonysEffectIndex == 4) 
								{
									harmonysEffectIndex = 0;
								}
								else 
								{
									harmonysEffectIndex = 4;
								}
								break;
                            }
                        case EffectType.SQUELCH:
                            {
								if (harmonysEffectIndex == 5) 
								{
									harmonysEffectIndex = 0;
								}
								else 
								{
									harmonysEffectIndex = 5;
								}
								break;
                            }
                        case EffectType.VOICE:
                            {
								if (harmonysEffectIndex == 6) 
								{
									harmonysEffectIndex = 0;
								}
								else 
								{
									harmonysEffectIndex = 6;
								}
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
