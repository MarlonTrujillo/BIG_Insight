using UnityEngine;
using System.Collections;

public class Movimiento : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += new Vector3(2*Time.deltaTime,0, 0);
        }
    }
}
