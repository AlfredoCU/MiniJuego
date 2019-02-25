// Incluir librerias para usar la interfaz de usuario de Unity.
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
    // Se Crea atributos públicos para la velocidad del jugador y para los objetos del juego Text UI.
    // Es necesario que sean publicos para ser manipulados en el entorno de Unity.
    public float speed; // Velocidad.
	public Text countText; // Contador de puntos.
	public Text winText; // Texto de juego ganado.
    
    // Se Crea referencias privadas al componente de cuerpo rígido en el reproductor, y el recuento de objetos 
    // recogidos hasta el momento.
    private Rigidbody rb;
	private int count;

    // Al inicio del juego.
    private void Start ()
    {
        // Asignar el componente Rigidbody a nuestra variable rb privada.
        rb = GetComponent<Rigidbody>();
        // Establece el conteo a cero.
        count = 0;
        // Ejecute la función SetCountText para actualizar la interfaz de usuario.
		SetCountText ();
        // Establezca la propiedad de texto de nuestra interfaz de usuario de winText en una cadena vacía.
        winText.text = "";
	}

	// Física.
	private void FixedUpdate ()
	{
        //  Establecer algunos atributos flotantes locales igual al valor de nuestras entradas horizontales y verticales.
        float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
        // Crea un objeto de la clase Vector3, y la asigna X y Z para presentar nuestros atributos de 
        // float horizontal y vertical.
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        // Se Agrega fuerza física a nuestro jugador de cuerpo rígido utilizando nuestro objeto 'movement' Vector3,
        // multiplicándolo por 'speed' que es nuestra velocidad de jugador público que aparece en el inspector.
        rb.AddForce (movement * speed);
	}

    // Cuando este objeto de juego se cruza con un colisionador 'Se activa el disparador',
    // almacena una referencia a ese colisionador en una variable llamada 'other'.
    private void OnTriggerEnter(Collider other) 
	{
		// Si el objeto del juego que insertamos tiene asignada la etiqueta.
		if (other.gameObject.CompareTag ("Pick Up"))
		{
            // Al tocarlo con el jugador hace al otro objeto (Recoger) desaparesca.
            other.gameObject.SetActive (false);
			// Y se incrementa el contador de recogidos 'count'.
			count = count + 1;
            // Ejecuta la función 'SetCountText ()'.
            SetCountText();
		}
	}

    // Cree una función independiente que pueda actualizar la interfaz de usuario 'countText' 
    // y compruebe si se ha alcanzado la cantidad necesaria para ganar.
    private void SetCountText()
	{
		// Actualiza nuestro contador de puntos.
		countText.text = "Puntos: " + count.ToString ();

		// Revisa si el contador a llegado a los puntos requeridos.
		if (count >= 21) 
		{
			// Si es así se muestra el siguente mensaje.
			winText.text = "Ganaste!";
		}
	}
}