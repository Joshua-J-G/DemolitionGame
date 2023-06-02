using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Atributes")]
    [SerializeField]private float Speed = 15f;
    [SerializeField] private float groundSphereCheckS = 0.2f;
    [SerializeField] private float JumpHeight = 3f;

    [Header("World Atributes")]
    [SerializeField] private float Gravity = -9.18f;

    [Header("Player Requirements")]
    [SerializeField] private GameObject GroundCheck;
    [SerializeField] private LayerMask Ground;
    [SerializeField] private CharacterController CC;
   

    private Vector3 Velocity;
    private bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x, y;
        x = Input.GetAxisRaw("Horizontal") * Speed * Time.deltaTime;
        y = Input.GetAxisRaw("Vertical") * Speed * Time.deltaTime;

        CC.Move(transform.forward * y + transform.right * x);


        isGrounded = Physics.CheckSphere(GroundCheck.transform.position, groundSphereCheckS, Ground);

     

        if (isGrounded && Velocity.y < 0)
        { 
                Velocity.y = -3f;
        }




        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            Velocity.y = Mathf.Sqrt(JumpHeight * 2f * Gravity);
        }

        Velocity.y += Gravity * -1f * Time.deltaTime;


        CC.Move(Velocity * Time.deltaTime);


    }
}
