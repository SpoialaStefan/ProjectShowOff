using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [Tooltip("Mouse Sensitivity for rotation")]
    [SerializeField]
    private float mouseSensitivity = 100;
    [Tooltip("Lift off force. Must have positive value")]
    [SerializeField]
    private float UpForce = 50f;
    [SerializeField]
    private float ForwardSpeed = 20f;
    [SerializeField]
    private float SideMovement = 15f;
    [SerializeField]
    private Transform model;


    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        MoveUpDown();
        MoveForward();
        Rotation();
        SwerweLeftRight();
    }

    private void MoveUpDown()
    {
        if (Input.GetKey(KeyCode.E))
        {
            rigidbody.AddRelativeForce(Vector3.up * UpForce);
        }
    }

    private void MoveForward()
    {
        if (Input.GetAxis("Vertical")!=0)
        {
            rigidbody.AddRelativeForce(Vector3.forward * ForwardSpeed * Input.GetAxis("Vertical"));
        }
    }

    private void Rotation()
    {
        float mouseX = Input.GetAxis("Mouse X") *mouseSensitivity* Time.deltaTime;
        transform.Rotate(Vector3.up*mouseX);
    }

    float tiltAmountSidewayes;
    float tiltAmountVelocity;
    private void SwerweLeftRight()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            rigidbody.AddRelativeForce(Vector3.right * Input.GetAxis("Horizontal") * SideMovement);
            tiltAmountSidewayes = Mathf.SmoothDamp(tiltAmountSidewayes, -20 * Input.GetAxis("Horizontal"), ref tiltAmountVelocity, 0.1f);
        }
        else
        {
            tiltAmountSidewayes = Mathf.SmoothDamp(tiltAmountSidewayes, 0, ref tiltAmountVelocity, 0.1f);
        }
        model.rotation = Quaternion.Euler(new Vector3(model.rotation.x, model.rotation.y, tiltAmountSidewayes));
    }
}
