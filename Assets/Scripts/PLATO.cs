using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Windows;

public class PLATO : MonoBehaviour
{
    private bool recogido;

    [SerializeField]
    private Transform player;
    private CAMARERO camarero;
    private float distancePlayer;
    private float distanceMesa;

    [SerializeField]
    private float rangoInteractuable = 0.8f;

    private void Awake()
    {
        recogido = false;
    }

    public void SetPlayer(Transform p)
    {
        player = p;
        camarero = player.GetComponent<CAMARERO>();
    }

    public void OnInteract()
    {
        //calcula la distancia del plato y la del jugador para ver si esta a la distancia para recoger el plato
        distancePlayer = Vector2.Distance(transform.position, player.position);
        if (!recogido && !camarero.conPlato)
        {
            //ha recogido el plato 
            RecogerPlato();
        }
        //si el jugador tiene un plato e interactua
        else if (recogido)
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

    private void RecogerPlato()
    {
        //Cambia los bools
        recogido = true;
        camarero.conPlato = true;

        //Se desactiva la collision
        transform.GetComponent<Collider2D>().enabled = false;

        //Se hace hijo del player para que se mueva con el
        transform.SetParent(player);
        transform.position = player.position;

    }

    private Transform BuscarMesaCercana()
    {
        //Un circle collider para que cada vez que el jugador intente entregar un plato busque las mesas cercanas
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(player.position, rangoInteractuable);

        Transform masCercano = null;
        float distMasCercana = rangoInteractuable + 1f;
        string platoTag = transform.gameObject.tag;

        //por cada collider en el rango de interaccion
        foreach (var c in hitColliders)
        {
            //si tiene la misma tag y es una mesa
            if (c.transform.CompareTag(platoTag) && c.GetComponent<Mesa>() != null)
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


    private void EntregarPlato(Transform mesaEntregar)
    {
        //Entrega el plato a la mesa
        camarero.conPlato = false;
        //Destruye el plato
        Destroy(gameObject);
    }
}
