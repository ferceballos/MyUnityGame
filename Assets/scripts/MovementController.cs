using UnityEngine;
using System.Collections;

//Player Movment Script
public class MovementController : MonoBehaviour
{
    public float Speed = 5.0f;
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
        print(IsGrounded());

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Vector3 up = transform.TransformDirection(Vector3.up);
            characterRigidbody.AddForce(up * 5, ForceMode.Impulse);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            transform.Translate(Vector3.forward * Speed * Input.GetAxis("Vertical") * Time.deltaTime);
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            transform.Translate(Vector3.back * Speed * -Input.GetAxis("Vertical") * Time.deltaTime);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Translate(Vector3.left * Speed * -Input.GetAxis("Horizontal") * Time.deltaTime);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Translate(Vector3.right * Speed * Input.GetAxis("Horizontal") * Time.deltaTime);
        }
    }

    bool IsGrounded()
    {
        //return Physics.CheckCapsule(myCollider.bounds.center, new Vector3(myCollider.bounds.center.x, myCollider.bounds.min.y - 0.1f, myCollider.bounds.center.z), 0.18f);

        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.20f);
    }
}