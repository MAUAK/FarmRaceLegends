using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMoviment2 : MonoBehaviour
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
        rb.velocity = new Vector3(movimento.x, 0, movimento.y) * Time.fixedDeltaTime *600;
    }

    public void SetJump(InputAction.CallbackContext value)
    {
        rb.AddForce(Vector3.up * 100);
    }
}
