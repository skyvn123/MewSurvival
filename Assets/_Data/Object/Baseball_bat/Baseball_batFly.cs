using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baseball_batFly : ObjectFly
{
    [SerializeField] protected float speed = 0.5f;
    [SerializeField] protected float rotationspeed = 1500f;
    private void FixedUpdate()
    {
        MovingtoPlayer(speed);
        Spin(Vector3.left, rotationspeed);
    }
}
