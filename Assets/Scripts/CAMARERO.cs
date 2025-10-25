using UnityEngine;
using UnityEngine.InputSystem;

public class CAMARERO : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    private PlayerInput playerInput;
    private BoxCollider2D bc;

    public bool conPlato;
    PLATO plato;

    [SerializeField]
    private float rangoInteractuable = 0.8f;


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

    public void OnIneractionInputEvent(InputAction.CallbackContext context) 
    {
        //Solo hace la función una vez por pulsación
        if (!context.performed) return;

        //Busca colliders2d dentro de un radio de interaccion
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, rangoInteractuable);

        PLATO nearestDish = null;
        float lowerDistance = rangoInteractuable + 1f;

        //por cada collider que toca
        foreach (var c in hitColliders)
        {
            //busca un plato
            PLATO dish = c.GetComponent<PLATO>();
            if (dish != null) 
            {
                //el más cercano
                float distance = Vector2.Distance(transform.position, dish.transform.position);
                if (distance < lowerDistance)
                { 
                    //actualiza el plato
                    lowerDistance = distance;
                    nearestDish = dish;
                }
            }
        }

        if (nearestDish != null)
        {
            //interactua con el plato más cercano
            nearestDish.OnInteract();
        }
    }
}
