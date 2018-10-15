using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    private GameObject gameCont;
    public int scoreValue;

    void Start()
    {
        gameCont = GameObject.Find("GameContoller");
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Boundary")
        {
            if(other.tag == "Player")
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                gameCont.GetComponent<GameController>().endGame();
            }
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);

            gameCont.GetComponent<GameController>().addScore(scoreValue);
        }
    }
}
