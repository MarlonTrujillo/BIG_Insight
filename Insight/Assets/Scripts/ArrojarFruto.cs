using UnityEngine;
using System.Collections;

public class ArrojarFruto : MonoBehaviour
{

    // Inicializo variables

    public GameObject ball; // referencia al prefab ball (fruto)
    private Vector3 throwSpeed; // Es la velocidad a la que disparará
	public Vector3 ballPos; // Posición inicial del fruto
	private bool lanzado = false; // Si la bola ha sido lanzada, previene que sean lanzada más de una
	public GameObject ballClone; // Para uno usar el prefab original
	private Rigidbody rb; // Variable para usar el RigidBody
	private int frutosDisponibles = 3; // Cantidad de frutos disponibles en el nivel
	new Camera camera;

	public void SetLanzado(bool lanzado) // Constructor para acceder
	{
		this.lanzado = lanzado;
	}

	// Use this for initialization
	void Start ()
    {
		camera = GetComponent<Camera> ();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Arrojar();
            





        }

        void Arrojar()
    {
        Vector3 screenPos = camera.WorldToScreenPoint(GameObject.Find("personaje").transform.position);
        throwSpeed.x = Input.mousePosition.x - screenPos.x;
        throwSpeed.y = (Input.mousePosition.y - screenPos.y) * 2;
        Debug.Log(throwSpeed);
        if (Input.GetMouseButtonDown(0) && !lanzado && frutosDisponibles > 0) // MouseIzq, no ha lanzado, y quedan frutos
        {
            Debug.Log("lanzado");
            lanzado = true; // Ya se lanzó
            frutosDisponibles--; // Resta a la cantidad de frutos

            // Crea una instancia del prefab ball desde la posición del personaje y anade rotación
            ballClone = Instantiate(ball, GameObject.Find("personaje").transform.position, transform.rotation) as GameObject;

            rb = ballClone.GetComponent<Rigidbody>(); // Obtiene el RigidBody del prefab
            rb.AddForce(throwSpeed / 100, ForceMode.Impulse); // Añade el impulso
        }
    }
}
