using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Windows;

public class PLATO : MonoBehaviour
{
    private bool recogido;

    [SerializeField] Transform player;
    private CAMARERO camarero;
    float distance;

    private void Awake()
    {
        recogido = false;
        camarero = player.GetComponent<CAMARERO>();
    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.position);
        if (!recogido && !camarero.conPlato && distance < 0.8 && UnityEngine.Input.GetKeyDown(KeyCode.E))
        {
            recogido = true;
            camarero.conPlato = true;
        }
        else if (recogido)
        {

        }
    }
}
