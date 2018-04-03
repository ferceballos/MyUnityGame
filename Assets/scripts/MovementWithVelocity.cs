using UnityEngine;
using System.Collections;

//Player Movment Script
public class MovementWithVelocity : MonoBehaviour
{
    public float speed = 5.0f;
    public Rigidbody characterRigidbody;
    public bool isGrounded;
    private float distToGround;
    public float jumpSpeed = 1f;
    public Collider characterCollider;

    void Start()
    {
        // get the distance to ground
        distToGround = characterCollider.bounds.extents.y;
    }


    void FixedUpdate()
    {
        print(characterRigidbody.velocity);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {/* 
            Vector3 up = transform.TransformDirection(Vector3.up);
            characterRigidbody.AddForce(up * 5, ForceMode.Impulse); */
            characterRigidbody.velocity += new Vector3(0.0f, jumpSpeed, 0.0f);
        }

        if (IsGrounded() && Input.GetAxis("Vertical") > 0)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            characterRigidbody.AddForce(forward * speed * Input.GetAxis("Vertical") * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (IsGrounded() && Input.GetAxis("Vertical") < 0)
        {
            Vector3 back = transform.TransformDirection(Vector3.back);
            characterRigidbody.AddForce(back * speed * -Input.GetAxis("Vertical") * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (IsGrounded() && Input.GetAxis("Horizontal") < 0)
        {
            Vector3 left = transform.TransformDirection(Vector3.left);
            characterRigidbody.AddForce(left * speed * -Input.GetAxis("Horizontal") * Time.deltaTime, ForceMode.VelocityChange);

        }
        if (IsGrounded() && Input.GetAxis("Horizontal") > 0)
        {
            Vector3 right = transform.TransformDirection(Vector3.right);
            characterRigidbody.AddForce(right * speed * Input.GetAxis("Horizontal") * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 && IsGrounded())
        {
            characterRigidbody.velocity = characterRigidbody.velocity * 0.8f;
        }
    }

    bool IsGrounded()
    {
        //return Physics.CheckCapsule(myCollider.bounds.center, new Vector3(myCollider.bounds.center.x, myCollider.bounds.min.y - 0.1f, myCollider.bounds.center.z), 0.18f);

        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.20f);
    }
}