using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private Transform camera;
    [SerializeField]
    private float ForwardSpeed = 6f;
    [SerializeField]
    private float UpSpeed = 3f;
    [SerializeField]
    private float UpSpeedSpam = 6f;
    [SerializeField]
    private float DownSpeed = 1f;
    [SerializeField]
    private float turnSmoothTime = 0.1f;
    [SerializeField]
    private bool spamSpaceKey = false;

    private float turnSmoothVelocity = 0.1f;

    private CharacterController controller;
    private float directionY = 0f;
    // Start is called before the first frame update
    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (Input.GetKeyDown(KeyCode.R))
        {
            spamSpaceKey = !spamSpaceKey;
        }

        if (spamSpaceKey == false)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                //directionY += UpSpeed;
                controller.Move(Vector3.up * UpSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //directionY += UpSpeed;
                controller.Move(Vector3.up * UpSpeedSpam * Time.deltaTime);

            }
        }

        if (!controller.isGrounded)
        {
            //directionY -= DownSpeed;
            controller.Move(Vector3.up * DownSpeed * -1 * Time.deltaTime);
        }


        //direction.y = directionY;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * ForwardSpeed * Time.deltaTime);
        }
    }


}
