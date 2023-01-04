using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCoinSelector : MonoBehaviour
{
    public GameObject Dragons;
    public GameObject Knights;


    public void LoadObject(string type)
    {
        if (type == "DexiDragons")
        {
            Destroy(Knights);
        }
        if (type == "DexiKnights")
        {
            Destroy(Dragons);
        }
    }
}
