using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RequestToBlockChainAssetsManager : MonoBehaviour
{
    public static RequestToBlockChainAssetsManager instance;
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

    public GameObject sendAssetsPanel;
    public GameObject Popup;
    public GameObject SaveWalletPopup;
    public Text requiredDXGToSendText;
    public Text OnRetrievelDXGToSendText;
    public double d_dxgInOneUSD;
//    public DXGCOST[] dXGCosts;

    public InputField TxnHash;
   

    public void Next()
  {
        bool tickTest = false;
        foreach (RequestItem  requestItem in RequestItemCreator.instance.requestItems)
        {
            if (requestItem.toggle.isOn)
            {
                tickTest = true;
            }
        }
        if (tickTest)
        {
            foreach (RequestItem requestItem in RequestItemCreator.instance.requestItems)
            {
                if (requestItem.toggle.isOn)
                {
                    if (requestItem.walletAddress.text.Length<5)
                    {
                        ConsoleManager.instance.ShowMessage("Enter wallet address for all selected items");
                        return;
                    }
                }
            }

            sendAssetsPanel.SetActive(true);
            SendCryptoItemCreator.instance.CreateList();
        }
  }
    public void ClearNumberOfDxgToSend()
    {
        SendCryptoItemCreator.instance.NumberOfDxgToSend = 0;
    }
    private void Start()
    {

        SaveWalletPopup.SetActive(false);
        Popup.SetActive(false);
        GetAllAvailableCryptoToRetrieve();
        StartCoroutine(GetDXGPrice());
        
    }
    public void SaveWalletPopupManager(bool value)
    {
        SaveWalletPopup.SetActive(value);
    }
    public void SaveWalletAdressManager()
    {
        SaveWalletPopupManager(false);
    }
    public IEnumerator GetDXGPrice()
    {
        string requestName = "https://api.coingecko.com/api/v3/simple/price?ids=dexigas&vs_currencies=usd";

        using (UnityWebRequest www = UnityWebRequest.Get(requestName))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                ConsoleManager.instance.ShowMessage("Network Error!");
                Debug.Log(www.error);
            }
            else
            {
                //DXGPrice dXGPrice = JsonUtility.FromJson<DXGPrice>(www.downloadHandler.text);
                //Debug.Log(" DXG: " +dXGPrice.dexigas.usd);
                //CalculteDXGPerUSD(dXGPrice.dexigas.usd.ToString());
            }
        }
    }

    void CalculteDXGPerUSD(string DxgPriceInUSD)
    {
        double dxgInOneUSD = 1 / double.Parse(DxgPriceInUSD);
        d_dxgInOneUSD = Math.Round(dxgInOneUSD,0);
        Debug.Log(dxgInOneUSD + "DXG in One USD");
        //requiredDXGToSendText.text = "" + dxgInOneUSD;
    }

    

    public void GetAllAvailableCryptoToRetrieve()
    {
        LoadingManager.instance.loading.SetActive(true);
        StartCoroutine(GetAllAvailableCryptoToRetrieveRequest());
    }

    IEnumerator GetAllAvailableCryptoToRetrieveRequest()
    {
        WWWForm form = new WWWForm();
        form.AddField("","");
       

        string requestName = "api/v1/locations/consumed_bounties";
        using (UnityWebRequest www = UnityWebRequest.Post(AuthManager.BASE_URL + requestName, form))
        {
            www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
            yield return www.SendWebRequest();

            if ( www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                
                Debug.Log(www.downloadHandler.text);
                Debug.Log(www.error);
                LoadingManager.instance.loading.SetActive(false);
                Debug.Log("No Crypto for Retrieve");
            }
            else
            {
                LoadingManager.instance.loading.SetActive(false);
                //BountiesToRetrieve bountiesToRetrieve = JsonUtility.FromJson<BountiesToRetrieve>(www.downloadHandler.text);
                //Debug.Log(www.downloadHandler.text);
                //RequestItemCreator.instance.CreateList(bountiesToRetrieve);
            }
        }
    }

    int currentIndex = 0;
    public void Complete()
    {
        if (TxnHash.text.Length<1)
        {
            ConsoleManager.instance.ShowMessage("TXN Hash empty");
        }
        else
        {
            if (currentIndex<SendCryptoItemCreator.instance.sendCryptoItems.Count)
            {
                LoadingManager.instance.loading.SetActive(true);
                StartCoroutine(RequestAssetRequest(TxnHash.text, (SendCryptoItemCreator.instance.sendCryptoItems[currentIndex].dollarValue *  d_dxgInOneUSD).ToString(), SendCryptoItemCreator.instance.sendCryptoItems[currentIndex].wallet, SendCryptoItemCreator.instance.sendCryptoItems[currentIndex].id.ToString(),SendCryptoItemCreator.instance.sendCryptoItems[currentIndex].use_in_future.ToString()));
            }
            else
            {
                Popup.SetActive(true);
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            
        }
    }
    public void LoadSceneAfterRetrievel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator RequestAssetRequest(string transaction_hash,string dxg_amount,string walle_adresse,string location_id,string use_in_future)
    {
        WWWForm form = new WWWForm();
        form.AddField("location_id", location_id);
        form.AddField("transaction_hash", transaction_hash);
        form.AddField("dxg_amount", dxg_amount);
        form.AddField("walle_adress", walle_adresse);
        form.AddField("use_in_future", use_in_future); // this field is used to show wallet address in Consume location api when it's value is true.
        Debug.Log(dxg_amount);
        Debug.Log(location_id);

        string requestName = "api/v1/locations/redeem_bounties";
        using (UnityWebRequest www = UnityWebRequest.Post(AuthManager.BASE_URL + requestName, form))
        {
            www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
            yield return www.SendWebRequest();
            Debug.Log("RequestAssetRequest location_id " + location_id);
            Debug.Log("RequestAssetRequest walle_adresse " + walle_adresse);
            Debug.Log("RequestAssetRequest use_in_future " + use_in_future);
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {

                Debug.Log(www.downloadHandler.text);
                Debug.Log(www.error);
                LoadingManager.instance.loading.SetActive(false);
                Debug.Log("Error");
            }
            else
            {
                LoadingManager.instance.loading.SetActive(false);
                Debug.Log(www.downloadHandler.text);
                currentIndex++;
                Complete();
            }
        }
    }


}
