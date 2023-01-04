using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabNameCheck : MonoBehaviour
{
    public GameObject[] Prefab;
    void Start()
    {
        if (Prefab[2].GetComponent<Rocket>())
        {
            Debug.Log("Rocket");
        }
        Debug.Log("Name "+Prefab[2].name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
