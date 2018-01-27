using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class polarisedspaceaction : MonoBehaviour {

    public AudioManager.Track filteredTrack;
    public AudioManager.EffectType audioEffect;
    public float effectStrength = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            if (other.GetComponent<ProjectileAudioLink>().thisTrack != filteredTrack) {
                Destroy(other.gameObject);
            }
            else
            {
                GameObject.Find("Audiomanager").GetComponent<AudioManager>().AddEffect(audioEffect, effectStrength, other.GetComponent<ProjectileAudioLink>().thisTrack);
            }
        }
    }
}
