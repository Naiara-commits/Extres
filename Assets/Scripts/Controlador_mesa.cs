using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Controlador_mesa : MonoBehaviour
{ 
    int maxMesas = 2;
    float targetTime = 5;       //El temporizador se inicieliza a 5 por ej

    void Start()
    {
        for (int i = 0; i < GameManager.Instance.listaMesasLibres.Count; i++)            //For que recorre la lista de las mesas libres 
        {
            GameManager.Instance.listaMesasLibres[i].GetComponent<Mesa>().setTableStatus(false); // Mete desde el inicio las mesas en la lista de mesas libres y se asegura de que estén como libres
        }
    }

    public void IntentarSentarCliente()
    {
        GameObject posibleMesa = null;      //Se crea un objeto 
       
        if (GameManager.Instance.listaMesasOcupadas.Count >= maxMesas && GameManager.Instance.listaMesasLibres.Count <= 0) // Si la cantidad de mesas ocupadas es menor a 2
        {
            return;
        }

        for (int i = 0; i < GameManager.Instance.listaMesasLibres.Count; i++)     //Se recorre cada elemento dentro de la lista de mesas libres
        {
           if (GameManager.Instance.listaMesasLibres[i].GetComponent<Mesa>().isFree)  
           {
                int mesaAleatoria = Random.Range(0, GameManager.Instance.listaMesasLibres.Count); // Int para que se coja una mesa aleatoria de la lista y no se pongan en el mismo orden
                posibleMesa = GameManager.Instance.listaMesasLibres [mesaAleatoria];     //La posible mesa que será la mesa que se vaya a usar es la que se ha encontrado en la lista
                break;
           }
        }
        
        if (posibleMesa != null)         
        {
            posibleMesa.GetComponent<Mesa>().setTableStatus(true);      //Se cambia el status a ocupada
            GameManager.Instance.MesasOcupadas(posibleMesa);     //La mesa que hemos seleccionado se mete en la lista de mesas ocupadas
        }
    }

    void Update() // Se llama contastemente para poder cambiar las mesas a ocupadas o libres
    {
        targetTime -= Time.deltaTime;      //Se va reduciendo el tiempo
        
        if (targetTime < 0)         //Cuando el contador llegue a 0
        {
            IntentarSentarCliente();        //Se llama a la función para que arranque
            targetTime = 5;     //Se vuelve a pponer a 5 el temporizador
        }
    }

    IEnumerator ClienteCambia()
    {
        yield return new WaitForSeconds(10f);
    }
}
