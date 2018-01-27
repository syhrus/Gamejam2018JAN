using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSatAction : MonoBehaviour {

    public float WaitForSeconds = 2;
    
    public AudioManager.EffectType audioEffect;
    public float effectStrength = 1;

	void Start()
	{	
		switch (audioEffect) {
		case AudioManager.EffectType.BITCRUSH:
			{	
				GetComponent<Light> ().color = new Color (0.8f, 0f, 0f);
				break;
			}
		case AudioManager.EffectType.SQUELCH:
			{
				GetComponent<Light> ().color = new Color (0.768f, 0.768f, 0.0784f);
				break;
			}
		case AudioManager.EffectType.REVERB:
			{
				GetComponent<Light> ().color = new Color (0.8f, 0f, 0.8f);
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
        yield return new WaitForSeconds(WaitForSeconds);
        GameObject.Find("Audiomanager").GetComponent<AudioManager>().AddEffect(audioEffect, effectStrength, other.GetComponent<ProjectileAudioLink>().thisTrack);

        other.GetComponent<Rigidbody>().AddForce(transform.up, ForceMode.Impulse);
    }
}
