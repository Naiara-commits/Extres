using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Controlador_mesa : MonoBehaviour
{
    List<GameObject> listaMesasOcupadas = new List<GameObject>();
    [SerializeField] List<GameObject> listaMesasLibres = new List<GameObject>();
    int mesasOcupadas = 0;
    int maxMesas = 2;
    float targetTime = 5;

    void Start()
    {
        for (int i = 0; i < listaMesasLibres.Count; i++)
        {
            listaMesasLibres[i].GetComponent<Mesa>().setTableStatus(false);
        }
    }



    public void IntentarSentarCliente()
    {
        GameObject posibleMesa = null;
        Debug.Log("listaMesasOcupadas.Count " + listaMesasOcupadas.Count);
        Debug.Log("maxMesas " + maxMesas);
        Debug.Log("listaMesasLibres.Count " + listaMesasLibres.Count);
       
        if (listaMesasOcupadas.Count >= maxMesas && listaMesasLibres.Count <= 0) // Si la cantidad de mesas ocupadas es menor a 2
        {
            return;
        }
        Debug.Log("Primer chack");
        for(int i = 0; i < listaMesasLibres.Count; i++)
        {
           if(listaMesasLibres[i].GetComponent<Mesa>().isFree)
            {
                posibleMesa = listaMesasLibres [i];
                break;
            }
        }
        Debug.Log("Segundo chick");
        if(posibleMesa != null) 
        {
            posibleMesa.GetComponent<Mesa>().setTableStatus(true);
            listaMesasLibres.Remove(posibleMesa);
            listaMesasOcupadas.Add(posibleMesa);
            Debug.Log("Tercer Chuck");
        }


    }
        // Update is called once per frame
        void Update() // Se llama contastemente para poder cambiar las mesas a ocupadas o libres
        {

        targetTime -= Time.deltaTime;
            if (targetTime < 0)
            {
            IntentarSentarCliente();
                targetTime = 5;
            }
        
          
        //Debug.Log("targetTime  " + targetTime);
        }

        IEnumerator ClienteCambia()
        {
            yield return new WaitForSeconds(10f);
        }
    
}
