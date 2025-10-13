using UnityEngine;

public class GENERADOR_PLATOS : MonoBehaviour
{

    public GameObject[] obj;
    public float tiempoMin = 1f;
    public float tiempoMax = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Generar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Generar()
    {
        Instantiate(obj[Random.Range(0,obj.Length)], transform.position, Quaternion.identity);
    }
}
