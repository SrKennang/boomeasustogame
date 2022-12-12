using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private float speed;
    [SerializeField] private Transform cam;
    [SerializeField] private float fallSpeed;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 camRelativeRight = cam.right;
        camRelativeRight.y = 0;
        Vector3 camRelativeForward = cam.forward;
        camRelativeForward.y = 0;

        Vector3 moveInput = horizontal * camRelativeRight + vertical * camRelativeForward;
        moveInput = moveInput.normalized;

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        Vector3 gravity = Vector3.down * fallSpeed;

        transform.rotation = Quaternion.Euler(0, cam.eulerAngles.y, 0);

        controller.Move(gravity);

        if(direction.magnitude >= 0.1f)
        {
            controller.Move(moveInput * speed * Time.deltaTime);
        }
    }
}
