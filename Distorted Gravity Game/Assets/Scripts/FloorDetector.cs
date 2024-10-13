using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDetector : MonoBehaviour
{
    public int foregroundLayer = 3;
    public Movement movement;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == foregroundLayer)
        {
            movement.isAirborne = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == foregroundLayer)
        {
            movement.isAirborne = true;
        }
    }
}

