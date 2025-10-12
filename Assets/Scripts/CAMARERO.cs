using UnityEngine;
using UnityEngine.InputSystem;

public class CAMARERO : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    private PlayerInput playerInput;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        movementDirection = playerInput.actions["Move"].ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = movementDirection * movementSpeed;
    }
}
