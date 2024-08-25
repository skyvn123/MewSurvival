using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoinSpin : MonoBehaviour
{
    [SerializeField] protected float rotationspeed = 500f;
    void Update()
    {
        Spin(Vector3.right, rotationspeed);
    }
    protected virtual void Spin(Vector3 vector, float rotationSpeed)
    {
        transform.parent.transform.GetChild(0).transform.Rotate(vector, rotationSpeed * Time.deltaTime);
    }
}
