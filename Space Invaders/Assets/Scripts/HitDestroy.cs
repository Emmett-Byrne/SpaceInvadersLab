using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDestroy : MonoBehaviour {


    private GameObject gameCont;
    public int scoreValue;
    
    void Start ()
    {
        gameCont = GameObject.Find("GameContoller");
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

                gameCont.GetComponent<GameController>().addScore(scoreValue);
            }
        }
    }
}
