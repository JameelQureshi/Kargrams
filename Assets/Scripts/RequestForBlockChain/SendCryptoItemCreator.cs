using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendCryptoItemCreator : MonoBehaviour
{
    public static SendCryptoItemCreator instance;

    public List<SendCryptoItem> sendCryptoItems;
    public int NumberOfDxgToSend = 0;
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

    public Image sizeRef;
    public GameObject sendcryptoItemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //NumberOfDxgToSend = 0;
    }

    public void ClearAll()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        sendCryptoItems.Clear();
    } 
    public void CreateList()
    {
        ClearAll();
        double totalUSD = 0;
        foreach (RequestItem requestItem in RequestItemCreator.instance.requestItems)
        {
            if (requestItem.toggle.isOn)
            {
                NumberOfDxgToSend++;
                GameObject item = Instantiate(sendcryptoItemPrefab, this.transform);
                SendCryptoItem sendCryptoItem = item.GetComponent<SendCryptoItem>();
                sendCryptoItem.Init(requestItem.icon.sprite, " " + requestItem.title.text,requestItem.id,requestItem.walletAddress.text, requestItem.dollarValue,requestItem.use_in_future);
                totalUSD += requestItem.dollarValue;
                sendCryptoItems.Add(sendCryptoItem);
            }
        }
        Debug.Log("totalUSD " + totalUSD);
        RequestToBlockChainAssetsManager.instance.requiredDXGToSendText.text = (totalUSD * RequestToBlockChainAssetsManager.instance.d_dxgInOneUSD).ToString();
        RequestToBlockChainAssetsManager.instance.OnRetrievelDXGToSendText.text = (totalUSD * RequestToBlockChainAssetsManager.instance.d_dxgInOneUSD).ToString();
        Debug.Log("total " + totalUSD * RequestToBlockChainAssetsManager.instance.d_dxgInOneUSD);
        AdjustSize();
    }
    
    private void AdjustSize()
    {
        Vector2 cellSize = new Vector2(1700, 270);
        GetComponent<GridLayoutGroup>().cellSize = cellSize;
    }
}
