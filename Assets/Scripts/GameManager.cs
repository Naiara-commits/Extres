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
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Hay más de un GameManager");
        }
    }

    public void MesasLibres(GameObject mesa)
    {
        if (!listaMesasOcupadas.Contains(mesa))
        {
            listaMesasOcupadas.Remove(mesa);
            listaMesasLibres.Add(mesa);
            
        }


    }

    public void MesasOcupadas(GameObject mesa)
    {
        if (listaMesasLibres.Contains(mesa))
        {
            listaMesasLibres.Remove(mesa);
            listaMesasOcupadas.Add(mesa);
        }
    }
}
