using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{

    [SerializeField] private float maxSpeed;
    [SerializeField] private float currentSpeed;
    [SerializeField] private float enginePower;
    [SerializeField] private float pitchSpeed;
    [SerializeField] private float rollSpeed;

    [SerializeField] private float verticalInput;
    [SerializeField] private float horizontalInput;


    void FixedUpdate()
    {
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
        currentSpeed = maxSpeed * enginePower / 100;
        

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * currentSpeed);

        // tilt the plane up/down
        transform.Rotate(Vector3.right * pitchSpeed * verticalInput * Time.deltaTime);
        // roll the plane right/left
        transform.Rotate(Vector3.forward * rollSpeed * horizontalInput * Time.deltaTime);
        

    }
}
