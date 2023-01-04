using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MapSceneManagment : MonoBehaviour
{
  public void GotoARScene()
    {
        SceneManager.LoadScene("ARLocationPlaceAtLocations");
    }

}
