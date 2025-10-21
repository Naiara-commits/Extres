using UnityEngine;
using System.Collections.Generic;

public class Controlador_mesa : MonoBehaviour
{
    List<GameObject> listaMesasOcupadas = new List<GameObject>();
    [SerializeField] List<GameObject> listaMesasLibres = new List<GameObject>();
    int mesasOcupadas = 0;

    void Start()
    {
        
    }

  

    public void IntentarSentarCliente()
    {
        if (mesasOcupadas < 2 && listaMesasLibres.Count > 0) // Si la cantidad de mesas ocupadas es menor a 2
        {
            { 
                GameObject mesa = listaMesasLibres[0]; // Coge la primera mesa libre de la lista
                mesasOcupadas++; // Aumenta la cantidad de mesas ocupadas
                listaMesasOcupadas.Add(mesa); // Agrega la mesa a la lista de mesas ocupadas
                listaMesasLibres.Remove(mesa); // Quita la mesa de la lista de mesas libres


            }
        }
    }
    // Update is called once per frame
    void Update() // Se llama contastemente para poder cambiar las mesas a ocupadas o libres
    {
        var numero = Random.Range(0,100); // Genera un número aleatorio entre 0 y 100
        if (numero > 70) // Si el número es mayor a 70
        {
            IntentarSentarCliente();
        }
    }
}
