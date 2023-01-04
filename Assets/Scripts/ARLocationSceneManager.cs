using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ARLocationSceneManager : MonoBehaviour
{
    public void GotoMapScene()
    {
        SceneManager.LoadScene("DexiMap");
    }

}
