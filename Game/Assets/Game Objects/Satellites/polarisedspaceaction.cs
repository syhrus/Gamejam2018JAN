using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class polarisedspaceaction : MonoBehaviour {

    public AudioManager.Track filteredTrack;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile" && other.GetComponent<ProjectileAudioLink>().thisTrack != filteredTrack)
        {
            Destroy(other.gameObject);
        }
    }
}
