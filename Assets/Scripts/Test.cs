using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    //public InputField input;
    //public Text Text;
    //private float n = 0;

    //public void Check()
    //{
    //    n = float.Parse(input.text);
    //    Text.text = n.ToString("0.00#");
    //}
    public Animator Animator;
    public void PlayAnimation_1()
    {
        Animator.Play("animate");
    }
}
