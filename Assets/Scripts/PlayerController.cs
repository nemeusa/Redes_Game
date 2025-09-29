using Fusion;
using UnityEngine;

[RequireComponent(typeof(NetworkCharacterController))]
public class PlayerController : NetworkBehaviour
{
    public float speed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;
    [SerializeField] float _rotationSpeed = 10f;
    public Transform cameraTransform;

    private NetworkCharacterController controller;
    private Vector3 velocity;
    private float verticalVelocity;

    public override void Spawned()
    {
        if (HasStateAuthority)
        {
            controller = GetComponent<NetworkCharacterController>();
        }
    }

    public override void FixedUpdateNetwork()
    {
        Move();
       
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (move.magnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Runner.DeltaTime * _rotationSpeed);

            Vector3 euler = transform.eulerAngles;
            transform.rotation = Quaternion.Euler(0f, euler.y, 0f);
        }
        controller.Move(move * speed * Runner.DeltaTime);


        if (controller.Grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && controller.Grounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Runner.DeltaTime;
    }
}

