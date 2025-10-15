using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Windows;

public class PLATO : MonoBehaviour
{
    protected bool recogido;
    [SerializeField] protected Transform mesaDestino;

    [SerializeField] protected Transform player;
    protected CAMARERO camarero;
    protected float distancePlayer;

    protected virtual void Awake()
    {
        recogido = false;
    }

    protected virtual void Update()
    {
        distancePlayer = Vector2.Distance(transform.position, player.position);
        if (!recogido && !camarero.conPlato && distancePlayer < 0.8f && UnityEngine.Input.GetKeyDown(KeyCode.E))
        {
            recogido = true;
            camarero.conPlato = true;
            LlevarPlato();
        }
        else if (recogido)
        {
            Debug.Log("Se ha recogio");
            float distanceMesa = Vector2.Distance(player.position, mesaDestino.position);
            if (distanceMesa < 0.8f && UnityEngine.Input.GetKeyDown(KeyCode.E)) 
            {
                EntregarPlato();
            }
        }
    }

    public void AsignarPlayer(Transform p)
    {
        Debug.Log("Se ha asignao player");
        player = p;
        camarero = player.GetComponent<CAMARERO>();
    }

    protected virtual void LlevarPlato() 
    {
        //El sprite deja de verse
    }
    
    protected virtual void EntregarPlato()
    {
        camarero.conPlato = false;
        Destroy(gameObject);
    }

    public void AsignarMesa(Transform mesa) 
    {
        Debug.Log("se ha asignao mesa");
        //se llama en la factory al crear un plato
        mesaDestino = mesa;
    }
}
