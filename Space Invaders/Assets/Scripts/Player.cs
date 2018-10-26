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
    private bool invincible = false;
    private float invincibleTime = 20;
    private float invincibleTick = 0;
    private MeshRenderer mesh;

    public int speed;
    public Boundary boundary;
    public float fireRate;
    public float flashTime;

    public GameObject shot;
    public Transform shotSpawn;
    
    void Start ()
    {
        rb = this.GetComponent<Rigidbody>();
        mesh = this.GetComponent<MeshRenderer>();
        StartCoroutine(Flash());
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
        if (!GameController.gameOver)
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

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Shot")
        {
            rb.position = new Vector3(0.0f, 0.0f, rb.position.z);
            invincible = true;
            mesh.enabled = false;
        }

        if (other.tag == "Invader" && GameController.lives >= 1)
        {
           GameController.lives -= 1;
           Application.LoadLevel(Application.loadedLevel);
        }
        else if (other.tag == "Invader" && GameController.lives == 0)
        {
            GameController.gameOver = true;
        }
    }

    IEnumerator Flash()
    {
        while (true)
        {
            if (invincible)
            {
                if (mesh.isVisible)
                {
                    mesh.enabled = false;
                }
                else
                {
                    mesh.enabled = true;
                }

                print("flashtime:" + invincibleTick + "invincTime:" + invincibleTime);

                if(invincibleTick > invincibleTime)
                {
                    invincible = false;
                    invincibleTick = 0;
                    mesh.enabled = true;
                }
                invincibleTick += Time.time;
                
            }
            yield return new WaitForSeconds(flashTime);
        }
    }
}
