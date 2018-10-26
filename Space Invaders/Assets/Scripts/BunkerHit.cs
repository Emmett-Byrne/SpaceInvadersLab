using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunkerHit : MonoBehaviour {
	
    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Boundary")
        {
            if (other.tag == "Shot")
            {
                if (this.transform.localScale.x > 0.4 && 
                    this.transform.localScale.y > 0.4)
                {
                    this.gameObject.transform.localScale = 
                        new Vector3(this.transform.localScale.x * 0.9f,
                        this.transform.localScale.y * 0.9f,
                        1);
                }
                else
                {
                    Destroy(this.gameObject);
                }
                Destroy(other.gameObject);
            }
        }
    }
}
