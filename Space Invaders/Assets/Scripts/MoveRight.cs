using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour {

    private Rigidbody rb;
    public float speed;

    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

        rb.velocity = transform.right * speed;
    }
}
