using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnlySpawn : MonoBehaviour
{
    public GameObject[] Prefabs;
    public GameObject Shield;
    public Button NextButton;
    private int counter;
    private int Shieldcounter;
    void Start()
    {
        foreach (var i in Prefabs)
        {
            i.SetActive(false);
        }
        Shield.SetActive(false);
        Shieldcounter = 0;
        NextButton.interactable = true;
        counter = 0;
        Prefabs[counter].SetActive(true);
    }
    public void Next()
    {
        if (Shieldcounter == 1)
        {
            Shield.SetActive(false);
            //DestroyImmediate(Shield, true);
            Shieldcounter = 0;
        }
        if (counter < Prefabs.Length-1)
        {
            Debug.Log("Next counter = "+counter);
            Debug.Log("Shield counter = " + Shieldcounter);
            Shieldcounter = 0;
            Prefabs[counter].SetActive(false);
            //DestroyImmediate(Prefabs[counter], true);
            counter++;
            Prefabs[counter].SetActive(true);
        }
        else
        {
            NextButton.interactable = false;
        }
    }
    public void ShieldObject()
    {
        Shieldcounter = 1;
        Prefabs[counter].SetActive(false);
        //DestroyImmediate(Prefabs[counter++], true);
        Shield.SetActive(true);
    }
}
