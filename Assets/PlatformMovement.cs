using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private PlatformEffector2D effector2D;

    public float platformWaitTime;
    private float waitedTime;

    private void Start()
    {
        effector2D = GetComponent<PlatformEffector2D>();
    }

    private void Update()
    {
        if (Input.GetKeyUp("s"))
        {
            waitedTime = platformWaitTime;
        }

        if (Input.GetKey("s"))
        {
            if (waitedTime <= 0)
            {
                effector2D.rotationalOffset = 180f;
                waitedTime = platformWaitTime;
            }
            else
            {
                waitedTime -= Time.deltaTime;
            }
        }

        if (Input.GetKey("space"))
        {
            effector2D.rotationalOffset = 0;
        }
    }
}
