using UnityEngine;
using System.Collections;

public class TimerFruto : MonoBehaviour {

    
    private float destroyTime = 5; // tiempo que toma en autodestruirse

    void OnTriggerEnter(Collider other) // Colisión Trigger
    {
        if (other.gameObject.tag == "ball") // Si el gameobject es un ball (tag)
        {
            Destroy(other.gameObject,destroyTime); // Lo destruye en el tiempo establecido

			Camera.main.GetComponent<ArrojarFruto>().SetLanzado(false); // En el getComponent hay que poner el script en uso
            
           /* // Con Camera.main accedo a la cámara principal
            if (GameObject.Find("ball(Clon)")==null || GameObject.Find("ball(Clon)").Equals(null))  // ***** CORREGIR ***** La condición debería ser que si el objeto se ha destruido
            {
                
            }
			*/
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
}
