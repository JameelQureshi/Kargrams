using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClipBoardController : MonoBehaviour
{
    private string walletAddress;
    private string Text;

    public void CopyAddressToClipBoard()
    {
        walletAddress = "0x5B1546af326261f3602D66E5309954687807dA09";
        walletAddress.CopyToClipboard();
        ConsoleManager.instance.ShowMessage("Address Copied!");
    }
    public void CopyTextToClipBoard(Text text)
    {
        Text = text.text.ToString();
        Text.CopyToClipboard();
        ConsoleManager.instance.ShowMessage("Amount Copied!");
    }
    public void CopyTextAndNoOfDXGToClipBoard(Text text)
    {
        Debug.Log("SendCryptoItemCreator.NumberOfDxgToSend " + SendCryptoItemCreator.instance.NumberOfDxgToSend);
        Text = "Amount : "+text.text.ToString()+",\nNumber of DXG : "+ SendCryptoItemCreator.instance.NumberOfDxgToSend;
        Text.CopyToClipboard();
        ConsoleManager.instance.ShowMessage("Amount and No. of DXG Copied!");
    }
}


public static class ClipboardExtension
{
    public static void CopyToClipboard(this string str)
    {
        GUIUtility.systemCopyBuffer = str;
    }
}
