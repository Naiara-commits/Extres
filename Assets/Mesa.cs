using UnityEngine;
using System.Collections;

public class Mesa : MonoBehaviour
{
    int MesasActuales = 0;
    int maxClientes = 2;
    public bool tieneCliente = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cliente") && MesasActuales <= maxClientes)
        {
            tieneCliente = true;
            MesasActuales++;
            Debug.Log("hay un cliente");
        }
        else
        {
            tieneCliente = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("ya no");
        tieneCliente = false;
        MesasActuales--;
    }
}
