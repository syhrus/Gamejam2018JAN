using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD;

public class AudioManager : MonoBehaviour {

    //singleton
    public static AudioManager instance;

    FMOD.Studio.EventInstance music01Event;
    FMOD.Studio.ParameterInstance bigArpBassParameter;

    public enum EffectType { BITCRUSH, REVERB, SQUELCH, CLEAN, RINGMOD, FLANGE, VOICE };
    public enum Track { Bass, Synth, Drums, Harmonys, None };

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
        music01Event.getParameter("BigArpBass", out bigArpBassParameter);
	}
	
	// Update is called once per frame
	void Update () 
    {
        //bigArpBassParameter.setValue(bigArpBassIndex);

        bigArpBassParameter.setValue(bassEffectIndex);

	}

    public void startAllAudio ()
    {
        music01Event.start();
        UnityEngine.Debug.Log("music start?");
    }

//    public void bigArpBassCollision ()
//    {
//        bigArpBassIndex = bigArpBassIndex + 1;
//    }

    public void resetAudioEffects ()
    {
        bassEffectIndex = 0;
    }

    public void AddEffect(EffectType effectType, float effectStrength, Track track)
    {

        switch (track)
        {
            case Track.Bass: {
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
                        case EffectType.SQUELCH:
                            {
                                bassEffectIndex = 4;
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
