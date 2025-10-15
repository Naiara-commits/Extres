using UnityEngine;

public class GENERADOR_PLATOS : MonoBehaviour
{
    [SerializeField] private GameObject platoRojoPrefab;

    [SerializeField] private Transform player;

    GameObject prefab;

    public PLATO CrearPlato(int tipo, Transform mesaDestino)
    {
        prefab = null;

        switch (tipo)
        {
            //Caso del plato rojo
            case 0:
                prefab = platoRojoPrefab;
                break;
            default:
                return null;

        }

        GameObject platoCreado = Instantiate(prefab, transform.position, Quaternion.identity);

        PLATO plato = platoCreado.GetComponent<PLATO>();
        plato.AsignarPlayer(player);
        plato.AsignarMesa(mesaDestino);

        return plato;
    }
}