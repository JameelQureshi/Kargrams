using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionSequence : MonoBehaviour
{
    //public static CollectionSequence instance;

    //private Transform target;
    //private int currentIndex;


    //public CoinDetector coinDetector;

    //[Header("Dexi Sequence Data")]
    //public string[] DexiSequenceNames;
    //public GameObject[] DexiSequenceConnectedLoops;
    //public GameObject[] DexiSequence;
    //public int[] DexiSequenceItemsDelay;
    //public GameObject SequenceModel;

    //[Header("DexiCash Sequence Data")]
    //public GameObject[] DexiCashSequence;
    //public int[] DexiCashSequenceItemsDelay;

    //[Header("QRCode Sequence Data")]
    //public GameObject[] QRCodeSequence;
    //public int[] QRCodeSequenceItemsDelay;

    //[Header("NFT Sequence Data")]
    //public GameObject[] NFTSequence;
    //public int[] NFTSequenceItemsDelay;

    //[Header("Crypto Sequence Data")]
    //public GameObject[] CryptoSequence;
    //public int[] CryptoSequenceItemsDelay;

    //[Header("Partner Projects Sequence Data")]
    //public GameObject[] PartnerSequence;
    //public int[] PartnerSequenceItemsDelay;

    //[Header("GameAssets Sequence Data")]
    //public GameObject[] GameAssetsSequence;
    //public GameObject[] GameAssetsDragonSequence;
    //public int[] GameAssetsSequenceItemsDelay;

    //private GameObject[] currentObjects;
    //private int[] currentDelays;
    //private GameObject currentSequence;

    //string bounty;
    //private void Awake()
    //{
    //    if (instance != null)
    //    {
    //        Destroy(gameObject);
    //    }
    //    else
    //    {
    //        instance = this;
    //    }
    //}
    //bool isCrypto;

    //public void ShowSequence(string bountytype)
    //{
    //    currentIndex = 0;
    //    bounty = bountytype;

    //    if (bountytype.Equals(JsonClasses.BountyTypes[0]))
    //    {
    //        currentObjects = new GameObject[QRCodeSequence.Length];
    //        currentObjects = QRCodeSequence;
    //        currentDelays = new int[QRCodeSequenceItemsDelay.Length];
    //        currentDelays = QRCodeSequenceItemsDelay;

    //        isCrypto = false;
    //    }
    //    else if (bountytype.Equals(JsonClasses.BountyTypes[1]))
    //    {
    //        currentObjects = new GameObject[DexiCashSequence.Length];
    //        currentObjects = DexiCashSequence;
    //        currentDelays = new int[DexiCashSequenceItemsDelay.Length];
    //        currentDelays = DexiCashSequenceItemsDelay;
    //        isCrypto = false;
    //    }
    //    else if (bountytype.Equals(JsonClasses.BountyTypes[2]) ||
    //             bountytype.Equals(JsonClasses.BountyTypes[3]) ||
    //             bountytype.Equals(JsonClasses.BountyTypes[27]) ||
    //             bountytype.Equals(JsonClasses.BountyTypes[28]) ||
    //             bountytype.Equals(JsonClasses.BountyTypes[29]) ||
    //             bountytype.Equals(JsonClasses.BountyTypes[30]) ||
    //             bountytype.Equals(JsonClasses.BountyTypes[31]))
    //    {
    //        for (int i = 0; i < DexiSequenceNames.Length; i++)
    //        {
    //            if (bountytype.Equals(DexiSequenceNames[i]))
    //            {
    //                // pass the rockets in a sequence as the bounty type passed in the "BountiesForRocket" array. Don't forget to remember the color of rockets
    //                // according to the bounty.
    //                Debug.Log("DexiSequenceIndex array index = " + i);// pass this index to rockets array to get the rocket prefab to instantiate.
    //                                                                  // Apply the if condition (line 215) where the prefab is actualy going.
    //                SequenceModel = DexiSequenceConnectedLoops[i];
    //            }
    //        }
    //        DexiSequence[0] = SequenceModel;
    //        currentObjects = new GameObject[DexiSequence.Length];
    //        currentObjects = DexiSequence;
    //        currentDelays = new int[DexiSequenceItemsDelay.Length];
    //        currentDelays = DexiSequenceItemsDelay;

    //        isCrypto = false;
    //    }
    //    else if ( 
    //             bountytype.Equals(JsonClasses.BountyTypes[4]) ||
    //             bountytype.Equals(JsonClasses.BountyTypes[5]) ||
    //             bountytype.Equals(JsonClasses.BountyTypes[6]) ||
    //             bountytype.Equals(JsonClasses.BountyTypes[7]) ||
    //             bountytype.Equals(JsonClasses.BountyTypes[8]) ||
    //             bountytype.Equals(JsonClasses.BountyTypes[9]) ||
    //             bountytype.Equals(JsonClasses.BountyTypes[10]) ||
    //             bountytype.Equals(JsonClasses.BountyTypes[11]) ||
    //             bountytype.Equals(JsonClasses.BountyTypes[12]) ||
    //             bountytype.Equals(JsonClasses.BountyTypes[20]) ||
    //             bountytype.Equals(JsonClasses.BountyTypes[21]) ||
    //             bountytype.Equals(JsonClasses.BountyTypes[22]) ||
    //             bountytype.Equals(JsonClasses.BountyTypes[32]) ||
    //             bountytype.Equals(JsonClasses.BountyTypes[23]) )
    //    {
    //        currentObjects = new GameObject[CryptoSequence.Length];
    //        currentObjects = CryptoSequence;
    //        currentDelays = new int[CryptoSequenceItemsDelay.Length];
    //        currentDelays = CryptoSequenceItemsDelay;

    //        isCrypto = true;
    //    }

    //    else if (bountytype.Equals(JsonClasses.BountyTypes[13]) ||
    //             bountytype.Equals(JsonClasses.BountyTypes[14]) ||
    //             bountytype.Equals(JsonClasses.BountyTypes[15]) ||
    //             bountytype.Equals(JsonClasses.BountyTypes[16]) ||
    //             bountytype.Equals(JsonClasses.BountyTypes[17]) ||
    //             bountytype.Equals(JsonClasses.BountyTypes[18]) ||
    //             bountytype.Equals(JsonClasses.BountyTypes[19]))
    //    {
    //        currentObjects = new GameObject[NFTSequence.Length];
    //        currentObjects = NFTSequence;
    //        currentDelays = new int[NFTSequenceItemsDelay.Length];
    //        currentDelays = NFTSequenceItemsDelay;

    //        isCrypto = false;
    //    }
    //    else if (bountytype.Equals(JsonClasses.BountyTypes[26]))
    //    {
    //        currentObjects = new GameObject[PartnerSequence.Length];
    //        currentObjects = PartnerSequence;
    //        currentDelays = new int[PartnerSequenceItemsDelay.Length];
    //        currentDelays = PartnerSequenceItemsDelay;

    //        isCrypto = false;
    //    }
    //    else if (bountytype.Equals(JsonClasses.BountyTypes[24]) )
    //    {
    //        currentObjects = new GameObject[GameAssetsDragonSequence.Length];
    //        currentObjects = GameAssetsDragonSequence;
    //        currentDelays = new int[GameAssetsSequenceItemsDelay.Length];
    //        currentDelays = GameAssetsSequenceItemsDelay;

    //        isCrypto = false;
    //    }
    //    else if (bountytype.Equals(JsonClasses.BountyTypes[25]))
    //    {
    //        currentObjects = new GameObject[GameAssetsSequence.Length];
    //        currentObjects = GameAssetsSequence;
    //        currentDelays = new int[GameAssetsSequenceItemsDelay.Length];
    //        currentDelays = GameAssetsSequenceItemsDelay;

    //        isCrypto = false;
    //    }
    //    else
    //    {
    //        //currentObjects = new GameObject[DexiSequence.Length];
    //        //currentObjects = DexiSequence;
    //        //currentDelays = new int[DexiSequenceItemsDelay.Length];
    //        //currentDelays = DexiSequenceItemsDelay;
    //    }

    //    //currentObjects = new GameObject[CryptoSequence.Length];
    //    //currentObjects = CryptoSequence;
    //    //currentDelays = new int[CryptoSequenceItemsDelay.Length];
    //    //currentDelays = CryptoSequenceItemsDelay;

    //    InstantiateSequence();

    //}

    //private void InstantiateSequence()
    //{
    //    currentSequence = Instantiate(currentObjects[currentIndex]);
    //    currentSequence.transform.SetParent(target);
    //    currentSequence.transform.localPosition = Vector3.zero;
    //    currentSequence.transform.localRotation = Quaternion.identity;
    //    Debug.Log("Going for Wait");

    //    if (isCrypto)
    //    {
    //        try
    //        {
    //            currentSequence.GetComponentInChildren<CenterCryptoSequence>().AssignTexture(bounty);
    //        }
    //        catch
    //        {

    //        }
            
    //    }

    //    Invoke("WaitForNextSequence",currentDelays[currentIndex]);

    //}

    //void WaitForNextSequence()
    //{
    //    currentIndex++;
    //    Debug.Log("before target clear");
    //    ClearTarget();

    //    if (currentIndex < currentObjects.Length)
    //    {
    //        InstantiateSequence();
    //    }
    //    else
    //    {
    //        coinDetector.TurnOnCollectPanel();
    //    }
    //    Debug.Log("Never Come here");
    //}

    //IEnumerator WaitForSequence(GameObject[] objects, int[] delays)
    //{
    //    yield return new WaitForSeconds(delays[currentIndex]);
    //    currentIndex++;
    //    Debug.Log("before target clear");
    //    ClearTarget();

    //    if (currentIndex < objects.Length)
    //    {
    //        InstantiateSequence();
    //    }
    //    else
    //    {
    //        coinDetector.TurnOnCollectPanel();
    //    }
    //    Debug.Log("Never Come here");
    //}

    //private void ClearTarget()
    //{
    //    Destroy(currentSequence);
    //}

    //// Start is called before the first frame update
    //void Start()
    //{
    //    target = transform;
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
