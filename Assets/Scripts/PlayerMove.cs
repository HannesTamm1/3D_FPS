using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float crouchSpeed = 2.5f;

    public float jumpForce = 5f;
    public float gravity = -9.81f;

    private float standingHeight = 2f;
    private float crouchingHeight = 1f;
    public float heighChangeSpeed = 5f;

    CharacterController cc;
    Vector3 velocity;
    bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        cc=gameObject.AddComponent<CharacterController>();
        cc.height = standingHeight;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = cc.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        float cunnretSpeed = walkSpeed;

        if(Input.GetKey(KeyCode.LeftShift)&&!Input.GetKey(KeyCode.LeftControl))
        {
            cunnretSpeed = runSpeed;
        }
        else if(Input.GetKey(KeyCode.LeftControl))
        {
            cunnretSpeed = crouchSpeed;
        }
        cc.Move(move * cunnretSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);


        float targetHeight = Input.GetKey(KeyCode.LeftControl) ? crouchingHeight : standingHeight;
        cc.height = Mathf.Lerp(cc.height, targetHeight, heighChangeSpeed * Time.deltaTime);
    }

}
