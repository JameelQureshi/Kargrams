using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObjectsByDelay : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] GameObject[] actors;
    [SerializeField] int index = 0;

    void Start()
    {
        InvokeRepeating("ActiveNextElement", time, time);
    }

    private void ActiveNextElement()
    {
        actors[index].SetActive(false);
        index++;
        actors[index].SetActive(true);
    }
}
