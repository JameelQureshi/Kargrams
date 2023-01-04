using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControl : MonoBehaviour
{
    public Animator[] animators;

    public void OnRocketOpen()
    {
        foreach (Animator animator in animators )
        {
            animator.enabled = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
