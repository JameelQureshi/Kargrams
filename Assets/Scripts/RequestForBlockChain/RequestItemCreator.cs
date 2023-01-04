using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequestItemCreator : MonoBehaviour
{

    public static RequestItemCreator instance;

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
    public GameObject requestItemPrefab;

    public Sprite[] icons;

    

    public string[] titles;
    public List<RequestItem> requestItems;

    // Start is called before the first frame update
    void Start()
    {
        requestItems = new List<RequestItem>();
        //CreateList();
    }
    //public void CreateList(BountiesToRetrieve bountiesToRetrieve)
    //{
    //    for (int i = 0; i < bountiesToRetrieve.locations.Count; i++)
    //    {
    //        GameObject item = Instantiate(requestItemPrefab, this.transform);
    //        Sprite cryptoIcon = icons[0];
    //        double dollarValue = 0;
    //        foreach (Sprite icon in icons)
    //        {
    //            if (icon.name == bountiesToRetrieve.locations[i].location_type)
    //            {
    //                //Debug.Log("Icon Name "+icon.name);
    //                //Debug.Log("Icon Name "+icon.name);
    //                cryptoIcon = icon;
    //            }
    //        }

    //        foreach (DXGCOST dXGCOST in RequestToBlockChainAssetsManager.instance.dXGCosts)
    //        {
    //            if (dXGCOST.location_type.name == bountiesToRetrieve.locations[i].location_type)
    //            {
    //                dollarValue = dXGCOST.dollarValue;
    //            }
    //        }

    //        RequestItem requestItem = item.GetComponent<RequestItem>();
    //        requestItem.Init(cryptoIcon, bountiesToRetrieve.locations[i].location_type,dollarValue, bountiesToRetrieve.locations[i].id, bountiesToRetrieve.locations[i].old_wallet_address.ToString());
    //        requestItems.Add(requestItem);
    //    }
    //    AdjustSize();
    //}
    
    private void AdjustSize()
    {
        Vector2 cellSize = new Vector2(sizeRef.rectTransform.rect.size.x, 480);
        GetComponent<GridLayoutGroup>().cellSize = cellSize;
    }
}
