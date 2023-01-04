using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARItemAnimation : MonoBehaviour
{
    public Animator[] animators;
    public ParticleSystem[] particleSystems;
    // Start is called before the first frame update
    public void PlayAnimation()
    {
        foreach (Animator animator in animators)
        {
            animator.SetTrigger("Open");
        }
        foreach (ParticleSystem particleSystem in particleSystems)
        {
            particleSystem.Play();
        }
    }
}
