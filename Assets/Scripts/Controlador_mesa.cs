using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Controlador_mesa : MonoBehaviour
{
    [SerializeField] List<GameObject> listaMesasLibres = new List<GameObject>();

    [SerializeField] List<GameObject> listaMesasOcupadas = new List<GameObject>();
    int maxMesas = 2;
    float targetTime = 5;       //El temporizador se inicieliza a 5 por ej

    void Start()
    {
        for (int i = 0; i < listaMesasLibres.Count; i++)            //For que recorre la lista de las mesas libres 
        {
            listaMesasLibres[i].GetComponent<Mesa>().setTableStatus(false);     
        }
    }



    public void IntentarSentarCliente()
    {
        GameObject posibleMesa = null;      //Se crea un objeto 
       
        if (listaMesasOcupadas.Count >= maxMesas && listaMesasLibres.Count <= 0) // Si la cantidad de mesas ocupadas es menor a 2
        {
            return;
        }
        for(int i = 0; i < listaMesasLibres.Count; i++)     //Se recorre cada elemento dentro de la lista de mesas libres
        {
           if(listaMesasLibres[i].GetComponent<Mesa>().isFree)  
            {
                posibleMesa = listaMesasLibres [i];     //La posible mesa que será la mesa que se vaya a usar es la que se ha encontrado en la lista
                break;
            }
        }
        if(posibleMesa != null)         
        {
            posibleMesa.GetComponent<Mesa>().setTableStatus(true);      //Se cambia el status a ocupada
            listaMesasLibres.Remove(posibleMesa);       //Se borra la mesa de la lista de mesas libres
            listaMesasOcupadas.Add(posibleMesa);        //La mesa que hemos seleccionado se mete en la lista de mesas ocupadas
        }


    }
        // Update is called once per frame
        void Update() // Se llama contastemente para poder cambiar las mesas a ocupadas o libres
        {

            targetTime -= Time.deltaTime;      //Se va reduciendo el tiemo
            if (targetTime < 0)         //Cuendo el contador llegue a 0
            {
            IntentarSentarCliente();        //Se llama a la función para que arranque
                targetTime = 5;     //Se vuelve a pponer a 5 el temporuizador
            }
        }

        IEnumerator ClienteCambia()
        {
            yield return new WaitForSeconds(10f);
        }
    
}
