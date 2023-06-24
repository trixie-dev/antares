using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public Transform plane;
    public float horizontalInput;
    public float verticalInput;
    public float speed = 5f;
    public float distance = 5f;
    public float timeHolding = 0f;

    public bool isDistance = false;
    public float startFOV = 60f;
    public float maxFOV = 70f;


    public float returnSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.forward * Time.deltaTime * horizontalInput * speed);

        // left-right
        Quaternion Target = plane.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, Target, returnSpeed * Time.deltaTime);

        // forward-back
        verticalInput = Input.GetAxis("Vertical");

        if (verticalInput != 0)
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, maxFOV, 0.5f * Time.deltaTime);
        }
        else if (verticalInput == 0)
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, startFOV, 0.5f * Time.deltaTime);

        }







    }

}
