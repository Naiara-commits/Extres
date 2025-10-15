using UnityEngine;
using System.Collections;

public class Mesa : MonoBehaviour
{
    public bool tieneCliente = false;
    int maxClientes = 2;
    int MesasActuales = 0;
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
            StartCoroutine(ClienteSeVa());
        }
    }

    void GenerarCliente()
    {
        tieneCliente = true;
    }

    IEnumerator ClienteSeVa()
    {
        yield return new WaitForSeconds(10f);
        tieneCliente = false;
        MesasActuales--;
        Debug.Log("el cliente se fue");
    }



}
