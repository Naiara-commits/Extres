using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Windows;

public class PLATO : MonoBehaviour
{
    protected bool recogido;

    [SerializeField] 
    protected Transform player;
    protected CAMARERO camarero;
    protected float distancePlayer;
    protected float distanceMesa;

    [SerializeField]
    protected float rangoInteractuable= 0.8f;

    protected virtual void Awake()
    {
        recogido = false;
    }

    protected virtual void Update()
    {
        //calcula la distancia del plato y la del jugador para ver si esta a la distancia para recoger el plato
        distancePlayer = Vector2.Distance(transform.position, player.position);
        if (!recogido && !camarero.conPlato && distancePlayer < rangoInteractuable && UnityEngine.Input.GetKeyDown(KeyCode.E))
        {
            //ha recogido el plato 
            RecogerPlato();
        }
        //si el jugador tiene un plato e interactua
        else if (recogido)
        {
            if ( UnityEngine.Input.GetKeyDown(KeyCode.E)) 
            {
                //busca la mesa (con la tag del plato que lleva el jugador) mas cercana en la distancia de interaccion del jugador
                Transform mesaCercana = BuscarMesaCercana();
                if (mesaCercana != null)
                {
                    //Entrega el plato
                    EntregarPlato(mesaCercana);
                }
            }
        }
    }

    public void SetPlayer(Transform p)
    {
        player = p;
        camarero = player.GetComponent<CAMARERO>();
    }

    protected virtual void RecogerPlato() 
    {
        recogido = true;
        camarero.conPlato = true;
        //El sprite deja de verse o llevarlo en la mano
    }

    protected Transform BuscarMesaCercana()
    {
        //Un circle collider para que cada vez que el jugador intente entregar un plato busque las mesas cercanas
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(player.position, rangoInteractuable);
        
        Transform masCercano = null;
        float distMasCercana = rangoInteractuable+1;
        string platoTag = transform.gameObject.tag;

        //por cada collider en el rango de interaccion
        foreach (var c in hitColliders)
        {
            //si tiene la misma tag
            if(c.transform.CompareTag(platoTag))
            {
                //calcula la distancia y se queda con el que está más cerca
                float d = Vector2.Distance(player.position, c.transform.position);
                if (d < distMasCercana)
                {
                    distMasCercana = d;
                    masCercano = c.transform;
                }
            }
        }
        //Devuelve la mesa mas cercana con la tag adecuada
        return masCercano;
    }


    protected virtual void EntregarPlato(Transform mesaEntregar)
    {
        //Entrega el plato a la mesa
        camarero.conPlato = false;
        //Destruye el plato
        Destroy(gameObject);
    }
}
