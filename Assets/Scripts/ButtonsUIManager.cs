using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonsUIManager : MonoBehaviour
{
    public static ButtonsUIManager instance;

    public GameObject ItemPrefab;
    public int ItemNumberCheck;
    public GameObject cube;


    private bool isButtonCreated = false;
    public List<GameObject> buttonItems = new List<GameObject>();
    private GameObject temp1;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        CreatButton();
    }
    public void CreatButton()
    {
        GenerateButtons(BillBoardsAPICount.fetched_Locations);
    }
   
    public void GenerateButtons(LocationRoot FetchedLocations)
    {

        foreach (Datum UserData in FetchedLocations.data)
        {
            temp1 = Instantiate(cube);
            temp1.GetComponent<ARItem>().ARuser = UserData;
        }
    }



    
}




