using UnityEngine;
using System.Collections;

public class Mesa : MonoBehaviour
{
    public GENERADOR_PLATOS generadorFactory;
    public Controlador_mesa controlador;
    public SpriteRenderer image;

    public bool isFree;
    
    int tipoDeMesa;
    public GameObject mesa;
    bool platoServido;
    private Coroutine corutinaActual;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.listaMesasLibres.Add(this.gameObject); // Añade la mesa a la lista de mesas libres del gameManager
        }
        setTableStatus(true); // La mesa empieza libre
    }

    public void setTableStatus (bool isFree)
    {
        this.isFree = isFree;            
        if (isFree)         //Si la mesa está vacía
        {
            image.color = Color.yellow;     //La mesa va a estar amarilla
        }
        else
        {
            image.color = Color.red;        //Si está ocupada, la mesa se pondrá rojaç
        }
    }
    
    public void setPlato (PLATO plato)
    {
        image.color = plato.GetComponent<SpriteRenderer>().color;
    }

    public void platoEntregado()
    {
        platoServido = true;
        StartCoroutine("ClienteSatisfecho");
    }
  


    IEnumerator ClienteSeVa()
    {
        yield return new WaitForSeconds(10f);
        if(!platoServido)
        {
            setTableStatus(true);
            GameManager.Instance.MesasLibres(this.gameObject);
            Debug.Log("el cliente se fue");
            GameManager.Instance.ClientesPerdidos();

        }
        platoServido = false;
    }
    IEnumerator ClienteSatisfecho()
    {
        yield return new WaitForSeconds(4f);
        setTableStatus(true);
        GameManager.Instance.MesasLibres(this.gameObject);
        Debug.Log("cliente feliz");
        GameManager.Instance.PlatoEntregado();
    }
    
     
}
