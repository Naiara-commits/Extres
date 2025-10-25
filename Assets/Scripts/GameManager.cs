using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Controlador_mesa controlador;

    public List<GameObject> listaMesasOcupadas = new List<GameObject>();
    public List<GameObject> listaMesasLibres = new List<GameObject>();

    void Awake()
    {
        if (Instance == null) 
        {
            Instance = this; // Se asigna este como el único gameManafer
        }
        else
        {
            Destroy(gameObject); // Si hay otro gameManager, se borra
        }
    }

    public void MesasLibres(GameObject mesa) // Método para añadir las mesas en la lista de mesas libres
    {
        if (listaMesasOcupadas.Contains(mesa)) // Si la mesa  está en la lista de mesas ocuapadas
        {
            listaMesasOcupadas.Remove(mesa);
            listaMesasLibres.Add(mesa);
        }
    }

    public void MesasOcupadas(GameObject mesa) // Método para añadir las mesas en la lista de mesas ocupadas
    {
        if (listaMesasLibres.Contains(mesa)) // Si la mesa está en la lista de mesas libres
        {
            listaMesasLibres.Remove(mesa);
            listaMesasOcupadas.Add(mesa); 
        }
    }
}
