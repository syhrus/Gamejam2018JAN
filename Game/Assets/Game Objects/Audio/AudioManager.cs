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

    public GunAim.Track bigArpBassIndex = GunAim.Track.Bass;

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
        bigArpBassParameter.setValue(bigArpBassIndex);
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
        bigArpBassIndex = 0;
    }

    public void AddEffect(BasicSatAction.EffectType effectType, float effectStrength, GunAim.Track track)
    {
        //Add in how each effect is handled here.
    }
}
