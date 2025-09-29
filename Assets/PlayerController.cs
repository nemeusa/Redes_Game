using Fusion;
using Fusion.Addons.Physics;
using UnityEngine;

[RequireComponent(typeof(NetworkCharacterController))]
public class PlayerController : NetworkBehaviour
{
    public float speed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;
    [SerializeField] float _rotationSpeed = 10f;

    private NetworkCharacterController controller;
    private Vector3 velocity;

    public override void Spawned()
    {
        if (HasStateAuthority)
        {
            controller = GetComponent<NetworkCharacterController>();
        }
    }

    public override void FixedUpdateNetwork()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Runner.DeltaTime);

        //rotacion
        if (move != Vector3.zero)
        {
            transform.forward = move * Time.deltaTime * _rotationSpeed;
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Runner.DeltaTime * _rotationSpeed);

            Vector3 euler = transform.eulerAngles;
            transform.rotation = Quaternion.Euler(0f, euler.y, 0f);
        }


        // Gravedad
        if (controller.Grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && controller.Grounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Runner.DeltaTime;
        //controller.Move(velocity * Runner.DeltaTime);
    }

    //void move()
    //{
    //    transform.right = Vector3.right * 3;

    //    _netRb.Rigidbody.velocity += Vector3.right * speed * 10 * Runner.DeltaTime;

    //    if (Mathf.Abs(_netRb.Rigidbody.velocity.x) <= speed) return;

    //    var velocity = _netRb.Rigidbody.velocity;
    //    velocity.y = 0;
    //    velocity = Vector3.ClampMagnitude(velocity, speed);
    //    velocity.y = _netRb.Rigidbody.velocity.y;
    //}
    //public void Move(float horizontal, float vertical)
    //{
    //    Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

    //    _playerRotation = Quaternion.LookRotation(direction);


    //    if (direction.magnitude >= 0.1f)
    //    {
    //        transform.rotation = Quaternion.Slerp(transform.rotation, _playerRotation, rotationSpeed * Time.deltaTime);

    //        Vector3 moveDir = transform.rotation * Vector3.forward;
    //        rb.MovePosition(rb.position + moveDir * moveSpeed * Time.deltaTime);
    //    }
    //}
}
