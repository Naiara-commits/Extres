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
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Cliente") && MesasActuales < maxClientes)
        {
            tieneCliente = true;
            MesasActuales++;
            Debug.Log("hay un cliente");
        }
        else if (other.gameObject.CompareTag("Cliente") && MesasActuales == maxClientes)
        {
            tieneCliente = false;
            Debug.Log("maximo superado");
        }
  
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("ya no");
        tieneCliente = false;
        MesasActuales--;
    }
}
