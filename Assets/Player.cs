using Fusion;
using Fusion.Addons.Physics;
using UnityEngine;

[RequireComponent(typeof(NetworkRigidbody3D))]
public class Player : NetworkBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _jumpForce;

    NetworkRigidbody3D _netRb;

    public override void Spawned()
    {
        if (HasStateAuthority)
        {
            _netRb = GetComponent<NetworkRigidbody3D>();
        }
    }

    public override void FixedUpdateNetwork()
    {
        Move(Input.GetAxis("Horizontal"));
    }

    private void Move(float xAxi)
    {
        if (xAxi != 0)
            transform.right = Vector3.right * Mathf.Sign(xAxi);

        _netRb.Rigidbody.velocity += Vector3.right * (xAxi * _speed * 10 * Runner.DeltaTime);

        if (Mathf.Abs(_netRb.Rigidbody.velocity.x) <= _speed) return;

        var velocity = _netRb.Rigidbody.velocity;
        velocity.y = 0;
        velocity = Vector3.ClampMagnitude(velocity, _speed);
        velocity.y = _netRb.Rigidbody.velocity.y;
        _netRb.Rigidbody.velocity = velocity;
    }

}
