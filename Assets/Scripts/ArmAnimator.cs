using Fusion;
using UnityEngine;

public class ArmAnimator : NetworkBehaviour
{
    [SerializeField] NetworkMecanimAnimator _mecAnimator;

    [SerializeField] float _attackTime = 0.4f;

    TickTimer _attackTimer;

    public override void Spawned()
    {
        _attackTimer = TickTimer.CreateFromSeconds(Runner, _attackTime);
    }

    private void Update()
    {
        if (!_attackTimer.ExpiredOrNotRunning(Runner)) return;

        if (Input.GetButtonDown("Jump"))
        AttackAnimation();
    }
    void AttackAnimation()
    {
        _mecAnimator.Animator.SetBool("IsAttack", true);
        _attackTimer = TickTimer.None;

    }
}
