using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [Header("Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private int health = 100;

    [Header("Unity Setup Reference")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private GameObject gameManager;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private MonoBehaviour[] disableObjects;

    private Vector3 _velocity;
    private bool _isGrounded;
    private float _groundDistance = 0.4f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settingsPanel.SetActive(true);

            foreach (var obj in disableObjects)
            {
                obj.enabled = false;
            }

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        Move();
    }

    public void CloseMenu()
    {
        settingsPanel.SetActive(false);

        foreach (var obj in disableObjects)
        {
            obj.enabled = true;
        }

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
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

    public void GetDamage(int value)
    {
        if (health > 0)
            health -= value;
        else
        {
            gameManager.GetComponent<GameManager>().LoadSaveScene();           
        }
    }
}
