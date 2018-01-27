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
            float MouseDelta = Input.GetAxis("Mouse X");
            Debug.Log("Change: " + MouseDelta);

            barrel.RotateAround(transform.position, new Vector3(0, 0, -1), MouseDelta * rotateSpeed);
        }
        if (FIRE && canFire)
        {
            GameObject firedProjectile = Instantiate(Projectile, barrel.position, new Quaternion());
			firedProjectile.GetComponent<Rigidbody>().mass = speedMod;
            firedProjectile.GetComponent<Rigidbody>().AddForce(barrel.up, ForceMode.Impulse);
            firedProjectile.GetComponent<ProjectileAudioLink>().thisTrack = thisTrack;
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
