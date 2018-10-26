using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour {

    private Rigidbody rb;
    public float speed;

    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

        rb.velocity = transform.up * speed;
    }
    void Update()
    {
        if (GameController.gameOver)
        {
            rb.velocity = transform.up * 0;
        }
    }

}
