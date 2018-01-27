﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD;

public class AudioManager : MonoBehaviour {

    //singleton
    public static AudioManager instance;

    FMOD.Studio.EventInstance music01Event;
    FMOD.Studio.ParameterInstance bassEffectParameter;

    public enum EffectType { CLEAN, BITCRUSH, REVERB, RINGMOD, FLANGE, SQUELCH, };
    public enum Track { Bass, Synth, Drums, Harmony };

    public int bassEffectIndex = 0;

    private void Awake()
    {
        //singleton
        instance = this;
    }

    // Use this for initialization
    void Start () 
    {
        music01Event = FMODUnity.RuntimeManager.CreateInstance("event:/Music01");
        music01Event.getParameter("BassEffect", out bassEffectParameter);
	}
	
	// Update is called once per frame
	void Update () 
    {
        bigArpBassParameter.setValue(bassEffectIndex);
	}

    public void startAllAudio ()
    {
        music01Event.start();
        UnityEngine.Debug.Log("music start?");
    }


    public void resetAudioEffects ()
    {
        bassEffectIndex = 0;
    }

    public void AddEffect(EffectType effectType, float effectStrength, Track track)
    {
        //Add in how each effect is handled here.

        switch (track)
        {
            case Track.Bass: {
                    switch (effectType)
                    {
                        case EffectType.CLEAN:
                            {
                                bassEffectIndex = 0;
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
                        case EffectType.SQUELCH:
                            {
                                bassEffectIndex = 4;
                                break;
                            }
                    }

                    break;
                };

            default
                {
                    break;
                }
        }
    }
}
