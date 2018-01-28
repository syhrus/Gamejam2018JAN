using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class polarisedspaceaction : MonoBehaviour {

    public AudioManager.Track filteredTrack;
    public AudioManager.EffectType audioEffect;
    public float effectStrength = 0;

    private void Start()
    {
        switch (audioEffect)
        {
            case AudioManager.EffectType.CLEAN:
                {
                    GetComponent<Light>().color = new Color(0.4f, 0.4f, 0.4f); //grey
                    break;
                }
            case AudioManager.EffectType.RINGMOD:
                {
                    GetComponent<Light>().color = new Color(0.8f, 0f, 0.8f); //hot pink
                    break;
                }
            case AudioManager.EffectType.FLANGE:
                {
                    GetComponent<Light>().color = new Color(0f, 1f, 0f); //green
                    break;
                }
            case AudioManager.EffectType.BITCRUSH:
                {
                    GetComponent<Light>().color = new Color(0.8f, 0f, 0f); //red
                    break;
                }
            case AudioManager.EffectType.SQUELCH:
                {
                    GetComponent<Light>().color = new Color(0.8f, 0.4f, 0.1f); //orange
                    break;
                }
            case AudioManager.EffectType.REVERB:
                {
                    GetComponent<Light>().color = new Color(0.8f, 0.8f, 0f); //yellow
                    break;
                }
            case AudioManager.EffectType.VOICE:
                {
                    GetComponent<Light>().color = new Color(0f, 0.3f, 1f); //dark blue
                    break;
                }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            if (other.GetComponent<ProjectileAudioLink>().thisTrack != filteredTrack) {
                Destroy(other.gameObject);
            }
            else
            {
                other.GetComponent<ProjectileAudioLink>().currentEffect = audioEffect;
                GameObject.Find("Audiomanager").GetComponent<AudioManager>().AddEffect(audioEffect, effectStrength, other.GetComponent<ProjectileAudioLink>().thisTrack);
            }
        }
    }
}
