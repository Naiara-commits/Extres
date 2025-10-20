using UnityEngine;
using System.Collections;

public class Mesa : MonoBehaviour
{
    public bool tieneCliente = false;
    int maxClientes = 2;
    int MesasActuales = 0;
    public GENERADOR_PLATOS generadorFactory;
    int tipoDeMesa;
    public Controlador_mesa controlador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (tieneCliente == false && MesasActuales < maxClientes)
        {
            tieneCliente = true;
            MesasActuales++;
            Debug.Log("hay un cliente");
        }
        else if (tieneCliente == true /* && se ha servido el plato == true*/)
        {
            //falta hacer aleatorio el tipo de mesa y cuando aparece
            tipoDeMesa = 0;
            //StartCoroutine(ClienteSeVa());
            generadorFactory.CrearPlato(tipoDeMesa);
            transform.gameObject.tag = tipoDeMesa.ToString();
        }
    }

    void OnTriggerEnter2D(Collider2D mesa)
    {
        if (mesa.gameObject.tag == "Player") // Si el jugador toca la mesa
        {
            controlador.IntentarSentarCliente();
        }

    }

    IEnumerator ClienteSeVa()
    {
        yield return new WaitForSeconds(10f);
        tieneCliente = false;
        MesasActuales--;
        Debug.Log("el cliente se fue");
    }



}
