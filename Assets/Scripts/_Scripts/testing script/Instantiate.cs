using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameObject cube;
    void Start()
    {
        Instantiate(cube);
    }
}
