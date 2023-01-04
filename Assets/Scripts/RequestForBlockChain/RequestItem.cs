using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequestItem : MonoBehaviour
{
    public Image icon;
    public Text title;
    public Toggle toggle;
    public double dollarValue;
    public InputField walletAddress;
    public bool use_in_future = false;
    [HideInInspector]
    public int id; 
    public void Init(Sprite s_icon,string s_title, double d_dollarValue,int id,string Old_Wallet_Address)
    {
        icon.sprite = s_icon;
        title.text = s_title;
        dollarValue = d_dollarValue;
        walletAddress.text = Old_Wallet_Address;
        this.id = id;
    }
    public void SavewalletAddress()
    {
        Debug.Log("use_in_future " + use_in_future);
        if (walletAddress.text=="")
        {
            ConsoleManager.instance.ShowMessage("Enter Wallet Address");
        }
        else if (walletAddress.text.Length<5)
        {
            ConsoleManager.instance.ShowMessage("Length is shorter");
        }
        else
        {
            use_in_future = true;
            RequestToBlockChainAssetsManager.instance.SaveWalletPopupManager(true);
        }
    }
}
