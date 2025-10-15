using UnityEngine;

public class PLATO_ROJO : PLATO
{
    protected override void EntregarPlato()
    {
        //La mesa donde hay que entregarlo pasa al estado donde esta entregada
        base.EntregarPlato();
    }
}
