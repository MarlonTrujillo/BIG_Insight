using UnityEngine;
using System.Collections;

public class Movimiento : MonoBehaviour
{

    private CharacterController characterController;
    public bool isGrounded;
    public float gravity;
    private float fallSpeed;
    public float jumpSpeed;
    public float moveSpeed;
    public float value;

	// Use this for initialization
	void Start () {
        characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        IsGrounded();
        Fall();
        Jump();
        Move();

    }

    void Move()
    {
        float xSpeed = Input.GetAxis("Horizontal");
        if (xSpeed != 0)
        {
            characterController.Move(new Vector3(xSpeed,0,0)* moveSpeed*Time.deltaTime);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            fallSpeed = -jumpSpeed;
        }
    }

    void Fall() // Método que aplica gravedad al sujeto
    {
        if (!isGrounded)
        {
            fallSpeed += gravity * Time.deltaTime;
        }
        else
        {
            if (fallSpeed > 0)
            {
                fallSpeed = 0;
            }
        }
        characterController.Move(new Vector3(0, -fallSpeed, 0)*Time.deltaTime);
    }

    void IsGrounded() // método que detecta si el personaje está en el suelo coliionando
    {
        isGrounded = (Physics.Raycast(transform.position, -transform.up, characterController.height / value));
    }
}
