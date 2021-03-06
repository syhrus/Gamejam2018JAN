﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSatAction : MonoBehaviour {

    public float WaitForSeconds = 2;
    
    public AudioManager.EffectType audioEffect;
    public float effectStrength = 1;

	void Start()
	{	
		switch (audioEffect) {
		case AudioManager.EffectType.CLEAN:
			{	
				GetComponent<Light> ().color = new Color (0.4f, 0.4f, 0.4f); //grey
				break;
			}
		case AudioManager.EffectType.RINGMOD:
			{	
				GetComponent<Light> ().color = new Color (0.8f, 0f, 0.8f); //hot pink
				break;
			}
		case AudioManager.EffectType.FLANGE:
			{	
				GetComponent<Light> ().color = new Color (0f, 1f, 0f); //green
				break;
			}
		case AudioManager.EffectType.BITCRUSH:
			{	
				GetComponent<Light> ().color = new Color (0.8f, 0f, 0f); //red
				break;
			}
		case AudioManager.EffectType.SQUELCH:
			{
				GetComponent<Light> ().color = new Color (0.8f, 0.4f, 0.1f); //orange
				break;
			}
		case AudioManager.EffectType.REVERB:
			{
				GetComponent<Light> ().color = new Color (0.8f, 0.8f, 0f); //yellow
				break;
			}
		case AudioManager.EffectType.VOICE:
			{	
				GetComponent<Light> ().color = new Color (0f, 0.3f, 1f); //dark blue
				break;
			}
		}
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if(other.tag == "Projectile")
        {
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.transform.position = transform.position;

            StartCoroutine(WaitThenLaunch(other));
        }
    }

    IEnumerator WaitThenLaunch(Collider other)
    {
        float lightRange = GetComponent<Light>().range;
        Coroutine shrink = StartCoroutine(PulseLight(-0.01f, 0.1f));
        other.GetComponent<ProjectileAudioLink>().currentEffect = audioEffect;
        GameObject.Find("Audiomanager").GetComponent<AudioManager>().AddEffect(audioEffect, effectStrength, other.GetComponent<ProjectileAudioLink>().thisTrack);
        yield return new WaitForSeconds(WaitForSeconds);
        other.GetComponent<Rigidbody>().AddForce(transform.up, ForceMode.Impulse);
        StopCoroutine(shrink);
        StartCoroutine(PulseLight(0.03f, lightRange));
    }

    IEnumerator PulseLight(float rate, float target)
    {
        Light light = GetComponent<Light>();
        if (rate < 0)
        {
            while (light.range > target)
            {
                light.range += rate;
                yield return new WaitForEndOfFrame();
            }
        }
        else
        {
            while (light.range < target)
            {
                light.range += rate;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
