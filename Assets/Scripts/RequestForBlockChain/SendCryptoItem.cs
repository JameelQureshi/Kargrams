using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendCryptoItem : MonoBehaviour
{
    public Image icon;
    public Text title;
    public double dollarValue;
    [HideInInspector]
    public int id;
    [HideInInspector]
    public string wallet;
    public bool use_in_future;
    public void Init(Sprite s_icon, string s_title,int id,string wallet,double s_dollarValue,bool use_in_future)
    {
        icon.sprite = s_icon;
        title.text = s_title;
        this.id = id;
        this.wallet = wallet;
        this.use_in_future = use_in_future;
        dollarValue = s_dollarValue;

    }
}
