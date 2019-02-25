using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

    // Antes de renderizar cada cuadro.
    private void Update () 
	{
        // Gire el objeto del juego al que se adjunta esta secuencia de comandos por 15 en el eje X,
        // 30 en el eje Y y 45 en el eje Z, multiplicado por deltaTime para hacerlo por segundo
        // en lugar de por marco
        transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}
}	