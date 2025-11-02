using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Controlador_mesa controlador;

    public List<GameObject> listaMesasOcupadas = new List<GameObject>();
    public List<GameObject> listaMesasLibres = new List<GameObject>();
    public List<GameObject> listaMesasWaiting = new List<GameObject>();

    public int platosEntregados = 0;
    public int platosGanar = 10;
    public int clientesIdos = 0;
    public int maxClientesPerdidos = 3;

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

    void Update()
    {
        PausaPartida();
    }

    public void MesasLibres(GameObject mesa) // Método para añadir las mesas en la lista de mesas libres
    {
        if (listaMesasWaiting.Contains(mesa)) // Si la mesa  está en la lista de mesas ocuapadas
        {
            listaMesasWaiting.Remove(mesa);
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

    public void PlatoEntregado()
    {
        platosEntregados++;
        
        if(platosEntregados == platosGanar)
        {
            Victoria();
        }
    }

    public void ClientesPerdidos()
    {
        clientesIdos++;
        if (clientesIdos == maxClientesPerdidos)
        {
            Derrota();
        }
    }
    public void Victoria()
    {
        SceneManager.LoadScene("WinMenu");

    }

    public void Derrota()
    {
        SceneManager.LoadScene("LoseMenu");
    }

    public void PausaPartida()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive); // Hace que el menu pausa salga encima de la escena
            Time.timeScale = 0f; // Para el tiempo
        }
    }

}
