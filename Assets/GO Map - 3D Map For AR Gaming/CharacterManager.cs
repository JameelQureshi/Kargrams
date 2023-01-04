using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public Animator animator; 
    public GameObject[] characters;
    public MoveAvatar moveAvatar;
    


    private void Start()
    {
        moveAvatar.OnAnimationStateChanged.AddListener(OnAnimationEventChanged);
    }
    private int SelectedCharacter
    {
        set
        {
            PlayerPrefs.SetInt("SelectedCharacter", value);
        }
        get
        {
            return PlayerPrefs.GetInt("SelectedCharacter", 0);
        }
    }

  
  

    public void OnAnimationEventChanged(MoveAvatar.AvatarAnimationState avatarAnimationState)
    {
        if (avatarAnimationState.Equals(MoveAvatar.AvatarAnimationState.Idle))
        {
            animator.Play("Idle");
        }
        else
        {
            animator.Play("Walk");
        }
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
    
}
