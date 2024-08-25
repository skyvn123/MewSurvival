using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    protected static InputManager instance;
    public static InputManager Instance { get => instance; }
    [SerializeField] protected Vector3 mousePosition;
    public Vector3 MousePosition { get => mousePosition; }

    private void Awake()
    {
        if (instance != null) Debug.Log("Only 1 Input manager allow");
        InputManager.instance = this;
    }
    private void FixedUpdate()
    {
        GetMousePosition();
    }

    protected virtual void GetMousePosition()
    {
        this.mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
