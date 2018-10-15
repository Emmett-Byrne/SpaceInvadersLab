using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax;
}

public class Player : MonoBehaviour {

    private Rigidbody rb;
    private float nextFire = 0;

    public int speed;
    public Boundary boundary;
    public float fireRate;

    public GameObject shot;
    public Transform shotSpawn;
    
    void Start ()
    {
        rb = this.GetComponent<Rigidbody>();
    }
	
	void Update () {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 move = new Vector3(moveHorizontal, 0.0f, 0.0f);
        rb.velocity = move * speed;

        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            rb.position.z
        );
    }
}
