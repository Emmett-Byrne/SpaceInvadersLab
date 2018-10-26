using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunkerHit : MonoBehaviour {

    private GameObject bunker;

	void Start ()
    {
        bunker = this.GetComponent<GameObject>();
	}
	
    void OnTriggerEnter(Collider other)
    {

    }

	void Update ()
    {
	
	}
}
