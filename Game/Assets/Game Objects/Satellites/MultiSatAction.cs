using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiSatAction : MonoBehaviour {

    public float WaitForSeconds = 2;

    public AudioManager.EffectType audioEffect;
    public float effectStrength = 1;
    public GameObject explosion;
    public enum Direction { Left, Right };
    public Direction direction;
    public float angle;

    private bool fired = false;

    void Start()
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
        float side = 1;
        if(direction == Direction.Left)
        {
            side = -1;
        }

        transform.Find("SecondAntenna").Rotate(Vector3.forward, angle * side);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Projectile")
        {
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.transform.position = transform.position;
            
            StartCoroutine(WaitThenLaunch(other, fired));
            fired = !fired;
        }
    }

    IEnumerator WaitThenLaunch(Collider other, bool fired)
    {
        yield return new WaitForSeconds(WaitForSeconds);
        GameObject.Find("Audiomanager").GetComponent<AudioManager>().AddEffect(audioEffect, effectStrength, other.GetComponent<ProjectileAudioLink>().thisTrack);
        if (fired)
        {
            other.GetComponent<Rigidbody>().AddForce(transform.Find("SecondAntenna").up, ForceMode.Impulse);
        }
        else
        {
            other.GetComponent<Rigidbody>().AddForce(transform.up, ForceMode.Impulse);
        }


    }
}
