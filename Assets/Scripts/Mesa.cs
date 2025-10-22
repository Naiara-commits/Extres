using UnityEngine;
using System.Collections;

public class Mesa : MonoBehaviour
{
    public bool tieneCliente = false;
    int maxClientes = 2;
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
        if (tieneCliente == false )
        {
            tieneCliente = true;
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



    IEnumerator ClienteSeVa()
    {
        yield return new WaitForSeconds(10f);
        tieneCliente = false;
        Debug.Log("el cliente se fue");
    }



}
