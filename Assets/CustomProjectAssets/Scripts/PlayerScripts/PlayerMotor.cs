using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMotor : NetworkBehaviour
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


    private Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        // Cursor.lockState = CursorLockMode.Locked;
    }
    private void Start()
    {
        rb.isKinematic = !base.hasAuthority;
    }
    // Update is called once per frame
    void Update()
    {
        if(base.hasAuthority)
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
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * UpForce);
        }
    }

    private void MoveForward()
    {
        if (Input.GetAxis("Vertical")!=0)
        {
            rb.AddRelativeForce(Vector3.forward * ForwardSpeed * Input.GetAxis("Vertical"));
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
            rb.AddRelativeForce(Vector3.right * Input.GetAxis("Horizontal") * SideMovement);
            tiltAmountSidewayes = Mathf.SmoothDamp(tiltAmountSidewayes, -20 * Input.GetAxis("Horizontal"), ref tiltAmountVelocity, 0.1f);
        }
        else
        {
            tiltAmountSidewayes = Mathf.SmoothDamp(tiltAmountSidewayes, 0, ref tiltAmountVelocity, 0.1f);
        }
        model.rotation = Quaternion.Euler(new Vector3(model.rotation.x, model.rotation.y, tiltAmountSidewayes));
    }
}
