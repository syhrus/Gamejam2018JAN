using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCutTest : MonoBehaviour {

	// Use this for initialization
	void Start () {

		BLINDED_AM_ME.MeshCut.Cut (transform.gameObject, transform.position, transform.right, null);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
