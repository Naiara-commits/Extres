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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.listaMesasLibres.Add(this.gameObject);
        }

        setTableStatus(false); // La mesa empieza libre
    }

    // Update is called once per frame
    void Update()
    {

         if (isFree == true /* && se ha servido el plato == true*/)
        {

            //falta hacer aleatorio el tipo de mesa 
            tipoDeMesa = 0;

            //StartCoroutine(ClienteSeVa());


            //generadorFactory.CrearPlato(tipoDeMesa);
            transform.gameObject.tag = tipoDeMesa.ToString();
        }
    }
    public void setTableStatus (bool isOccuped)
    {
        isFree = !isOccuped;                
        if (isFree)         //Si la mesa está vacía
        {
            image.color = Color.yellow;     //La mesa va a estar amarilla
        }
        else
        {
            image.color = Color.red;        //Si está ocupada, la mesa se pondrá roja
        }
    }


    IEnumerator ClienteSeVa()
    {
        yield return new WaitForSeconds(10f);
        isFree = true;
        Debug.Log("el cliente se fue");
    }



}
