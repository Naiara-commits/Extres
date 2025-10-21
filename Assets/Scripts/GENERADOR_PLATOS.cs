using System.Runtime.CompilerServices;
using UnityEngine;


public class GENERADOR_PLATOS : MonoBehaviour
{
    [SerializeField] 
    private GameObject platoRojoPrefab;
    [SerializeField] 
    private GameObject platoAzulPrefab;
    [SerializeField] 
    private GameObject platoNaranjaPrefab;

    [SerializeField] 
    private Transform player;

    GameObject prefab;

    public PLATO CrearPlato(int tipo)
    {
        prefab = null;

        //Se pone el prefab del
        switch (tipo)
        {
            // Caso del plato rojo  
            case 0:
                prefab = platoRojoPrefab;
                break;
            case 1:
                prefab = platoAzulPrefab;
                break;
            case 2:
                prefab = platoNaranjaPrefab;
                break;

            default:
                return null;
        }
        //Crea un objeto del caso que se haya llamado
        GameObject platoCreado = Instantiate(prefab, transform.position, Quaternion.identity);

        //se entra a la clase plato para setear el player
        PLATO plato = platoCreado.GetComponent<PLATO>();
        plato.SetPlayer(player);

        return plato;
    }
}
