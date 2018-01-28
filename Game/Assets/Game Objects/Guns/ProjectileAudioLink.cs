using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAudioLink : MonoBehaviour {

    public AudioManager.Track thisTrack;
    public AudioManager.EffectType currentEffect = AudioManager.EffectType.CLEAN;

    Vector3 origPos;
    SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        origPos = transform.position;
        Physics.IgnoreLayerCollision(8, 8, true);
    }

    private void Update()
    {
        
        Vector3 moveDirection = gameObject.transform.position - origPos;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
        }
        switch (currentEffect)
        {
            case AudioManager.EffectType.CLEAN:
                {
                    sprite.color = new Color(1,1,1);
                    break;
                }
            case AudioManager.EffectType.RINGMOD:
                {
                    sprite.color = new Color(0.8f, 0f, 0.8f); //hot pink
                    break;
                }
            case AudioManager.EffectType.FLANGE:
                {
                    sprite.color = new Color(0f, 1f, 0f); //green
                    break;
                }
            case AudioManager.EffectType.BITCRUSH:
                {
                    sprite.color = new Color(0.8f, 0f, 0f); //red
                    break;
                }
            case AudioManager.EffectType.SQUELCH:
                {
                    sprite.color = new Color(0.8f, 0.4f, 0.1f); //orange
                    break;
                }
            case AudioManager.EffectType.REVERB:
                {
                    sprite.color = new Color(0.8f, 0.8f, 0f); //yellow
                    break;
                }
            case AudioManager.EffectType.VOICE:
                {
                    sprite.color = new Color(0f, 0.3f, 1f); //dark blue
                    break;
                }
        }
    }

    public void SetCorrectEffect()
    {
        switch (thisTrack)
        {
            case AudioManager.Track.Bass:
                {
                    currentEffect = GameObject.Find("LevelEventHandler").GetComponent<LevelEventHandler>().BassEffect;
                    break;
                }
            case AudioManager.Track.Synth:
                {
                    currentEffect = GameObject.Find("LevelEventHandler").GetComponent<LevelEventHandler>().SynthEffect;
                    break;
                }
            case AudioManager.Track.Drums:
                {
                    currentEffect = GameObject.Find("LevelEventHandler").GetComponent<LevelEventHandler>().DrumsEffect;
                    break;
                }
            case AudioManager.Track.Harmonys:
                {
                    currentEffect = GameObject.Find("LevelEventHandler").GetComponent<LevelEventHandler>().HarmonyEffect;
                    break;
                }
        }
    }
}
