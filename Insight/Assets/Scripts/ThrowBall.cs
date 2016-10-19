using UnityEngine;
using System.Collections;

public class ThrowBall : MonoBehaviour
{

    // Inicializo variables

    public GameObject ball; // referencia al prefab ball (fruto)
    private Vector3 throwSpeed = new Vector3(7, 12, 0); // Es la velocidad a la que disparará
    public Vector3 ballPos; // Posición inicial del fruto
    private bool lanzado = false; // Si la bola ha sido lanzada, previene que sean lanzada más de una
    public GameObject ballClone; // Para uno usar el prefab original
    private Rigidbody rb; // Variable para usar el RigidBody
    private int frutosDisponibles = 3; // Cantidad de frutos disponibles en el nivel

   public void SetLanzado(bool lanzado) // Constructor para acceder
    {
        this.lanzado = lanzado;
    }

	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0) && !lanzado && frutosDisponibles > 0) // MouseIzq, no ha lanzado, y quedan frutos
        {
            lanzado = true; // Ya se lanzó
            frutosDisponibles--; // Resta a la cantidad de frutos
         
            // Crea una instancia del prefab ball desde la posición del personaje y anade rotación
            ballClone = Instantiate(ball, GameObject.Find("personaje").transform.position, transform.rotation) as GameObject;

            rb = ballClone.GetComponent<Rigidbody>(); // Obtiene el RigidBody del prefab
            rb.AddForce(throwSpeed, ForceMode.Impulse); // Añade el impulso

        }
    }
}
