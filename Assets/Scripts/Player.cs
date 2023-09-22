using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpForce = 5f;

    [Header("Unity Setup Reference")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;

    private Vector3 _velocity;
    private bool _isGrounded;
    private float _groundDistance = 0.4f;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, _groundDistance, groundMask);

        if (_isGrounded && _velocity.y < 0)
            _velocity.y = -2f;

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        controller.Move(move * speed * Time.deltaTime);

        Jump();

        _velocity.y += gravity * Time.deltaTime;

        controller.Move(_velocity * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded)
            _velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
    }
}