using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ObjectFly : MonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected Vector3 direction;
    private void OnEnable()
    {
        GetDirection();
    }
    protected virtual void MovingtoPlayer(float speed)
    {
        transform.parent.Translate(speed * Time.deltaTime* direction);
    }

    protected virtual void Spin(Vector3 vector,float rotationSpeed)
    {
        transform.parent.transform.GetChild(0).transform.Rotate(vector, rotationSpeed * Time.deltaTime);
    }
    protected virtual void GetDirection()
    {
        Vector3 playerPosition = GameObject.Find("Player").transform.position;
        targetPosition = new Vector3(playerPosition.x,1f, playerPosition.z);
        direction = targetPosition - transform.parent.position;
    }

    protected virtual void LookAt()
    {
        Vector3 playerPosition = GameObject.Find("Player").transform.position;
        targetPosition = new Vector3(playerPosition.x, 1f, playerPosition.z);
        transform.LookAt(targetPosition);
    }

}
