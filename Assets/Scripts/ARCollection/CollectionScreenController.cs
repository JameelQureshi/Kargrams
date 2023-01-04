using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionScreenController : MonoBehaviour
{
    public static CollectionScreenController instance;
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

    public GameObject educationScreenPanel;
    public Image educationScreen;
    public Sprite[] educationScreens;
    public string[] education_urls;

    [HideInInspector]
    public int currentindex;

    public void ShowEducationScreen()
    {
        educationScreenPanel.SetActive(true);
        educationScreen.sprite = educationScreens[currentindex];
    }

    public void Moreinfo()
    {
        Application.OpenURL(education_urls[currentindex]);
    }

    public void Continue()
    {
        educationScreenPanel.SetActive(false);
        CoinDetector.canCollect = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
