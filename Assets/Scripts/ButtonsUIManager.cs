using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsUIManager : MonoBehaviour
{
    public GameObject ButtonPrefab;
    public GameObject ParentPanel;
    public int ButtonsLength;
    void Start()
    {
        GameObject temp;
        for (int i = 0; i < ButtonsLength; i++)
        {
            temp = Instantiate(ButtonPrefab, ParentPanel.transform);
            //temp.GetComponent<ButtonItem>().ButtonId.id = i;
            temp.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Button = "+(i+1);
        }
        //Destroy(gameObject);
        Destroy(ButtonPrefab);
    }

}
