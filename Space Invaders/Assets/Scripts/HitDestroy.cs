using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDestroy : MonoBehaviour {

    public GameObject shot;
    public Transform shotSpawn;

    private float nextFire = 0;
    private float fireRate;

    private GameObject gameCont;
    public int scoreValue;
    
    void Start ()
    {
        gameCont = GameObject.Find("GameContoller");

        fireRate = Random.Range(5, 20);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Boundary")
        {
            if (other.tag == "Player")
            {
                
            }
            else
            {
                Destroy(other.gameObject);
                Destroy(gameObject);

                gameCont.GetComponent<GameController>().AddScore(scoreValue);
            }
        }
    }

    void Update()
    {
        //if (Time.time > nextFire)
        //{
        //    nextFire = Time.time + fireRate;
        //    Instantiate(shot, this.transform.position, shotSpawn.rotation);
        //}
    }
}
