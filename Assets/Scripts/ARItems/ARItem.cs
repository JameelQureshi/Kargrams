
using ARLocation.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class ARItem : MonoBehaviour
{
    public static ARItem instance;
    public GameObject[] effects;
    public Datum ARuser;

    public BoxCollider PrefabCollider;
    public GameObject dexiLogo;
    public GameObject coinRoot;
    private GameObject coin;
    public GameObject coinPrefab;
    public GameObject chest;
    public GameObject chestDestroyEffect;
    public GameObject Coin_To_Rotate;
    public GameObject DistanceFields;
    public TMP_Text Distance_3D_Text;
    //public Text PinDistanceText;
    public int cryptoIndex;

    public CryptoTextureSelecter cryptoTextureSelecter;
    public CoinDetector coinDetector;
    public string BountyType;


    [HideInInspector]
    public bool isOpened = false;
    public bool isOpening = false;
    public bool StopRotation = false;

    LocationRoot locationRoot;

    private void Start()
    {
       StartCoroutine(GetTexture(ARuser.image));

    }
    IEnumerator GetTexture(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        Texture2D texture = new Texture2D(1, 1);
        www.LoadImageIntoTexture(texture);
        GameObject image1 = gameObject.transform.Find("Image1").gameObject;
        image1.GetComponent<Renderer>().material.mainTexture = texture;

        GameObject image2 = gameObject.transform.Find("Image2").gameObject;
        image2.GetComponent<Renderer>().material.mainTexture = texture;
    }




    private void Awake()
    {
        if (instance != null)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public void OpenChest()
    {
        isOpening = true;

        try
        {
            chest.GetComponent<ARItemAnimation>().PlayAnimation();
        }
        catch
        {
            try
            {
                chest.GetComponent<Animator>().SetTrigger("Open");
            }
            catch
            {
                chest.GetComponentInChildren<Animator>().SetTrigger("Open");
            }
        }
        Invoke(nameof(BringCoin), 3.0f);
        GetComponent<ContainerSoundController>().StartAudios();
    }

    private void BringCoin()
    {
        coin  = Instantiate(coinPrefab, Vector3.zero, Quaternion.identity);
        coin.transform.SetParent(coinRoot.transform);
        coin.transform.localPosition = Vector3.zero;
        try
        {
            coin.GetComponent<CharacterSelector>().LoadObject(BountyType);
        }
        catch
        {
            Debug.Log("No Character Script Attached!");
        }

        try
        {
            coin.GetComponent<DexiDXG_Selector>().LoadObject(BountyType);
        }
        catch
        {
            Debug.Log("No DexiDXG_Selector Script Attached!");
        }

        try
        {
            coin.GetComponent<GameCoinSelector>().LoadObject(BountyType);
        }
        catch
        {
            Debug.Log("No DexiDXG_Selector Script Attached!");
        }

        if (ARuser.lat >= 0 )
        {
            Debug.Log("Crpto Index: Getting");
            cryptoIndex = Random.Range(0, coin.GetComponentInChildren<CryptoTextureSelecter>().materials.Length);
            coin.GetComponentInChildren<CryptoTextureSelecter>().AssignType(cryptoIndex);
            Debug.Log("Crpto Index: "+ cryptoIndex);
        }
        
        Invoke(nameof(TurnOfChest), 2.0f);
    }
    private void TurnOfChest()
    {
        isOpened = true;
        Destroy(chest);
        GameObject refObj = Instantiate(chestDestroyEffect, Vector3.zero, Quaternion.identity);
        refObj.transform.SetParent(transform);
        refObj.transform.localPosition = Vector3.zero;
    }

    private void Update()
    {
        if (!StopRotation)
        {
            transform.Rotate(new Vector3(0, 50, 0) * Time.deltaTime);
            Coin_To_Rotate.transform.Rotate(new Vector3(0, 50, 0) * Time.deltaTime);
        }
    }

    public void StartLight()
    {
        Debug.Log("Start Light Start");
        GameObject refObj = Instantiate(effects[Random.Range(0, effects.Length)], Vector3.zero, Quaternion.identity);
        refObj.transform.SetParent(coin.transform);
        refObj.transform.localPosition = Vector3.zero;

        Debug.Log("Start Light Before Consume");
        Debug.Log("AR User Id " + ARuser.id);
        DoneCollection();
        LoadingManager.instance.loading.SetActive(false);
        Invoke(nameof(DoneCollection), 3.0f);
        StartCoroutine(ConsumeLocation());

    }
    IEnumerator ConsumeLocation()
    {
        WWWForm form = new WWWForm();
      //  form.AddField("id", id);
        string requestName = "api/v1/locations/consumed";
        using (UnityWebRequest www = UnityWebRequest.Post(AuthManager.BASE_URL + requestName, form))
        {
            www.SetRequestHeader("Authorization", "Bearer " + AuthManager.Token);
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
               // coinDetector.DexiLogo.SetActive(false);
                ConsoleManager.instance.ShowMessage("Kindly Try Again");
                LoadingManager.instance.loading.SetActive(false);
                CoinDetector.canCollect = true;
                Debug.Log(www.error);
            }
            else
            {
                DoneCollection();
                ConsoleManager.instance.ShowMessage("Collected");
                LoadingManager.instance.loading.SetActive(false);
            }
        }
    }
    private void DoneCollection()
    {
        coinDetector.ShowCollected();
        CoinDetector.cryptoIndex = cryptoIndex;
        Destroy(gameObject);
    }
    public void LargeDistance()
    {
        if (isOpened == false && isOpening == false)
        {
            if (chest != null)
            {
                chest.SetActive(false);
            }
           // dexiLogo.SetActive(true);
            DistanceFields.SetActive(true);
            PrefabCollider.enabled = false;
        }
    }
    public void LessDistance()
    {
        if (isOpened == false && isOpening == false)
        {
            if (chest != null)
            {
                chest.SetActive(true);
            }
         //   dexiLogo.SetActive(false);
            DistanceFields.SetActive(false);
            PrefabCollider.enabled = true;
        }
    }
    public void PinDistance(double distance)
    {
        Distance_3D_Text.text = distance.ToString("000.00"+" meters");
        //PinDistanceText.text = "" + distance;
        //Distance_3D_Text.text.Format("{0:0.00}", distance);
        //Distance_3D_Text.text = "" + distance;
    }
}

