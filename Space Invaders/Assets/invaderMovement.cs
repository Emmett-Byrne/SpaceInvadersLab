using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class invaderMovement : MonoBehaviour {

    private bool direction;
    private Vector3 movement;
    public float speed;

    void Start ()
    {
        direction = false;
         movement = new Vector3(speed / transform.childCount, 0, 0);
    }
	
	void Update ()
    {
        MovementUpdater();
    }

    void MovementUpdater()
    {
        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i += 1)
            {
                if (direction)
                {
                    if (transform.GetChild(i).position.x <= -8.3)
                    {
                        MoveDown();
                        return;
                    }
                    movement = new Vector3(-(speed / transform.childCount), 0, 0);
                }
                else
                {
                    if (transform.GetChild(i).position.x >= 8.3)
                    {
                        MoveDown();
                        return;
                    }
                    movement = new Vector3(speed / transform.childCount, 0, 0);
                }
            }
            transform.Translate(movement);
        }
    }

    void MoveDown()
    {
        transform.Translate(0, 0, -0.1f);
        direction = !direction;
    }
}
