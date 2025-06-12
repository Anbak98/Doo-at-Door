using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterRender<S> : MonoBehaviour where S: CharacterStatHandler
{
    private S status; 

    [SerializeField] Animator animator;

    public static readonly int idleHash = Animator.StringToHash("idle");
    public static readonly int runHash = Animator.StringToHash("Run");
    public static readonly int deadHash = Animator.StringToHash("Dead");

    public virtual void Init<T>(T status) where T : S 
    {
        this.status = status;
    }

    public abstract void Render();
}
