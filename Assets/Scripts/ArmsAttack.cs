using Fusion;
using UnityEngine;

public class ArmsAttack : NetworkBehaviour
{
    [SerializeField] byte _damage;

    private void OnTriggerEnter(Collider other)
    {
        if (!HasStateAuthority) return;

        if (other.TryGetComponent(out PlayerLife enemyHealth))
        {
            enemyHealth.TakeDamage(_damage);
        }
    }
}
