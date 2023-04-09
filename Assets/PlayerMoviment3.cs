using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMoviment3 : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 inputMoviment;
    private Vector2 movimento;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetMoviment(InputAction.CallbackContext value)
    {        
        movimento = value.ReadValue<Vector2>(); 
    }

    private void FixedUpdate()
    {
        transform.Translate(movimento.x, 0, movimento.y);
    }

    public void SetJump(InputAction.CallbackContext value)
    {
        rb.AddForce(Vector3.up * 100);
    }
}
