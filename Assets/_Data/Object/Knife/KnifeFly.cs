using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeFly : ObjectFly
{
    [SerializeField] protected float speed = 1f;
    private void FixedUpdate()
    {
        MovingtoPlayer(speed);
        LookAt();
    }
}
