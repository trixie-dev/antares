using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private Vector3 centerOfMass = new Vector3(0, 0, 0.7f);
    [SerializeField] private float speed = 50f;
    [SerializeField] private float enginePower;
    [SerializeField] private float pitchSpeed;
    [SerializeField] private float rollSpeed;

    [SerializeField] private float verticalInput;
    [SerializeField] private float horizontalInput;


    // Forces 
    private float forwardForce;
    private float resistanceForce;
    private float gravityForce;
    private float wingForce;

    private float tiltAngle;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass;
        gravityForce = -Physics.gravity.y;
        Physics.gravity = new Vector3(0, 0, 0);
    }

    void FixedUpdate()
    {
        forwardForce = speed * enginePower / 100;
        resistanceForce = 0.8f * forwardForce;
        
        wingForce = 1.1f * gravityForce * enginePower /100;

        // get the user's vertical and horizontal input
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = -Input.GetAxis("Horizontal");



        // engine power and speed
        enginePower = Mathf.Clamp(enginePower, 0, 100);
        if (Input.GetKey("e"))
        {
            enginePower += 20 * Time.deltaTime;
        }
        else if (Input.GetKey("q"))
        {
            enginePower -= 20 * Time.deltaTime;
        }

        // Forces
        rb.AddForce(transform.forward * forwardForce);
        Debug.Log(wingForce);
        rb.AddForce(Vector3.up * wingForce);
        rb.AddForce(Vector3.down * gravityForce);


        rb.AddForce(-transform.forward * resistanceForce);

        // tilt the plane up/down
        transform.Rotate(Vector3.right * pitchSpeed * verticalInput * Time.deltaTime);
        // roll the plane right/left
        transform.Rotate(Vector3.forward * rollSpeed * horizontalInput * Time.deltaTime);


    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, Vector3.forward * 6 + new Vector3(0, 0.5f, 0));

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, Vector3.up * 6);
    }

}
