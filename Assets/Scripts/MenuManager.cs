using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public int AllowedBountiesToCollect = 5;
    public Button[] menuButtons;

    public GameObject menuPanel;
    public GameObject CollectedBountiesLimitPopup;

    public GameObject[] UIPanels;
    public static bool fromMap;
    public static bool fromHome;

    private void Start()
    {
        CollectedBountiesLimitPopup.SetActive(false);
        Debug.Log("Start Called");
        Invoke(nameof(ARFromMap), 1);
    }

    void ARFromMap()
    {
        if (fromMap)
        {
            SelectScreen(1);
        }
        if (fromHome)
        {
            SelectScreen(5);
        }
    }

    public void SelectScreen(int index)
    {
        foreach (Button button in menuButtons)
        {
            button.GetComponent<MenuButton>().DeSelectButton();
        }
        foreach (GameObject panel in UIPanels)
        {
            panel.SetActive(false);
        }
        menuButtons[index].GetComponent<MenuButton>().SelectButton();
        UIPanels[index].SetActive(true);
    }


    public void Logout()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }

    public void OpenARScene()
    {
        fromMap = false;
        fromHome = true;
        SceneManager.LoadScene(2);
        //LoadingManager.instance.loading.SetActive(true);
        //StartCoroutine(CheckCollectedBounties());
    }
    public void OpenARSceneFromMap()
    {
        fromMap = true;
        fromHome = false;
        SceneManager.LoadScene(2);
        //LoadingManager.instance.loading.SetActive(true);
        //StartCoroutine(CheckCollectedBounties());
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void OpenURL(string URL)
    {
        Application.OpenURL(URL);
    }
    IEnumerator CheckCollectedBounties()
    {

        string requestName = "/api/v1/locations/today_consumed_bounties";
        using (UnityWebRequest www = UnityWebRequest.Get(AuthManager.BASE_URL + requestName))
        {
            www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ProtocolError || www.result == UnityWebRequest.Result.ConnectionError)
            {
                ConsoleManager.instance.ShowMessage("Error in Request");
                Debug.Log(www.error);
                LoadingManager.instance.loading.SetActive(false);
            }
            else
            {
               // NumberOfCollectedBounties CollectedBounties = JsonUtility.FromJson<NumberOfCollectedBounties>(www.downloadHandler.text);
                //if (CollectedBounties.success)
                //{
                //    LoadingManager.instance.loading.SetActive(false);
                //    if (CollectedBounties.data <= AllowedBountiesToCollect)
                //    {
                //        SceneManager.LoadScene(2);
                //    }
                //    else
                //    {
                //        CollectedBountiesLimitPopup.SetActive(true);
                //        Debug.Log("You have already reached the limit");
                //    }
                //}
                
                {
                    ConsoleManager.instance.ShowMessage("Try again later");
                    LoadingManager.instance.loading.SetActive(false);
                }
            }
        }
    }
    }
