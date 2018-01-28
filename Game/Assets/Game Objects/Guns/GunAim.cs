using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAim : MonoBehaviour {

    private bool isClicked;
    public float rotateSpeed = 1f;
    public Transform barrel;
    public GameObject Projectile;
    public bool FIRE = false;
    public bool canFire = true;
	public float speedMod = 1f;
    
    public AudioManager.Track thisTrack;

    void Start () {
        barrel = transform.GetChild(0).GetComponent<Transform>();
        isClicked = false;
    }

    void OnMouseDown()
    {
        isClicked = true;
        Debug.Log("CLICK");
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            isClicked = false;
        };

        if (isClicked)
        {
            Vector3 mouse_pos = Input.mousePosition;
            mouse_pos.z = 0f; //The distance between the camera and object
            Vector3 object_pos = Camera.main.WorldToScreenPoint(transform.position);
            mouse_pos.x = mouse_pos.x - object_pos.x;
            mouse_pos.y = mouse_pos.y - object_pos.y;
            float angle = (Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg) - 90.0f;
            barrel.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        if (FIRE && canFire)
        {
            GameObject firedProjectile = Instantiate(Projectile, barrel.position, new Quaternion());
			firedProjectile.GetComponent<Rigidbody>().mass = speedMod;
            firedProjectile.GetComponent<Rigidbody>().AddForce(barrel.up, ForceMode.Impulse);
            firedProjectile.GetComponent<ProjectileAudioLink>().thisTrack = thisTrack;
            firedProjectile.GetComponent<ProjectileAudioLink>().SetCorrectEffect();
            GameObject.Find("Audiomanager").GetComponent<AudioManager>().Ping();
            FIRE = false;
            canFire = false;
        }
    }

    public void Fire()
    {
        FIRE = true;
        //AudioManager.instance.startAllAudio();
    }
}
