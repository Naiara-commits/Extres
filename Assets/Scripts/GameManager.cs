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
            Debug.Log("Hay más de un GameManager");
        }
    }


}
