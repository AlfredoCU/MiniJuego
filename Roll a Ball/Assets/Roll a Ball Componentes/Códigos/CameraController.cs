using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    // Almacena una referencia pública al objeto del juegador, por lo que podemos referirnos a su Transform.
    public GameObject player;
    // Almacena un Vector3 offset del jugador (una distancia para colocar la cámara del jugador en todo momento).
    private Vector3 offset;

    // Al inicio del juego.
    private void Start ()
	{
        //  Crea un desplazamiento restando la posición de la cámara de la posición del jugador.
        offset = transform.position - player.transform.position;
	}

    // Después de que se ejecute el bucle 'Update ()' estándar, y justo antes de que se renderice cada cuadro.
    private void LateUpdate ()
	{
        // Establecer la posición de la cámara (el objeto del juego al que se adjunta este script)
        // a la posición del jugador, más la cantidad de compensación.
        transform.position = player.transform.position + offset;
	}
}