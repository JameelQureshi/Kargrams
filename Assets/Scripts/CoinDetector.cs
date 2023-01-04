using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class CoinDetector : MonoBehaviour
{
    public Text RayResponce;

    public GameObject collectEffect;
    public GameObject collectPanel;

    public GameObject ScanButton;
 
    public GameObject DetectedCoin;

    
    public Image cardImage;
  
    public GameObject VideoPanel;
    public static int collectedIndex;
    public static int cryptoIndex;
    public string itemType;


    public VideoPlayer cardVideoPlayer;
    public VideoClip[] cardsClips;

    public static bool canCollect;
    private void Start()
    {
        canCollect = true;
    }
    private void FixedUpdate()
    {
        if (!canCollect)
        {
            ScanButton.SetActive(false);
            return;
        }
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 150))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                RayResponce.text = hit.transform.tag;
                //Debug.Log("Did Hit" + hit.transform.tag);

                if (hit.transform.tag == "Coin")
                {
                    if (hit.transform.gameObject.GetComponent<ARItem>().isOpened)
                    {
                        ScanButton.SetActive(true);
                        DetectedCoin = hit.transform.gameObject;
                      //  itemType = hit.transform.gameObject.GetComponent<ARItem>().ARuser.location_type;
                    }
                else
                    {
                        if (!hit.transform.gameObject.GetComponent<ARItem>().isOpening)
                        {
                            hit.transform.gameObject.GetComponent<ARItem>().coinDetector = this;
                            hit.transform.gameObject.GetComponent<ARItem>().OpenChest();
                        }
                       
                    }
                    
                }
                else
                {
                    ScanButton.SetActive(false);
                    //DexiLogo.SetActive(false);
                    //DetectedCoin = null;
                }
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.yellow);
                RayResponce.text = "Did not Hit";
                //Debug.Log("Did not Hit");
                ScanButton.SetActive(false);
                //DexiLogo.SetActive(false);
                //DetectedCoin = null;
            }
        
    }

    public void CollectCoin()
    {
        if (DetectedCoin!=null)
        {
            //Stop further Detection and collection
            canCollect = false;
            //DexiLogo.SetActive(true);
            //Turn on Loading
            LoadingManager.instance.loading.SetActive(true);

//            DetectedCoin.GetComponent<ARItem>().StartLight();
            //DetectedCoin.GetComponent<ARItem>().OpenChest();
        }
        
    }

    public void ShowCollected()
    {
        // Start Sequence
        //CollectionSequence.instance.ShowSequence(itemType);

        //CollectionScreenController.instance.currentindex = JsonClasses.GetBountyIndex(itemType);
        cardVideoPlayer.clip = cardsClips[CollectionScreenController.instance.currentindex];
        cardVideoPlayer.Prepare();
        //Invoke(nameof(TurnOffDexiLogo), 2);
    }

    private void TurnOffDexiLogo()
    {
        
        collectEffect.SetActive(true);
        Invoke(nameof(TurnOffCollectedEffect), 3);


//        CollectionScreenController.instance.currentindex = JsonClasses.GetBountyIndex(itemType);

        cardVideoPlayer.clip = cardsClips[CollectionScreenController.instance.currentindex];
        cardVideoPlayer.Prepare();

    }

    void TurnOffCollectedEffect()
    {
        collectEffect.SetActive(false);
        TurnOnCollectPanel();
    }


    public void TurnOnCollectPanel()
    {
        collectPanel.SetActive(true);
        Debug.Log("We are here!");

        cardVideoPlayer.Play();
        cardImage.gameObject.SetActive(false);
        VideoPanel.SetActive(true);
        

    }
    
}
