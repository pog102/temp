using UnityEngine;

public class CubeTriggerObject : ARIteractabbleObjects
{
    private Animator _animator;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
    }

    // protected override void SetState(State state)
    // {
    //     base.SetState(state);
    //     switch (state)
    //     {
    //         case State.Idle:
    //             _animator.SetBool("isPushup", false);
    //             break;
    //         case State.Pushup:
    //             _animator.SetBool("isPushup", true);
    //             break;
    //         default:
    //             break;
    //     }
    // }
}
