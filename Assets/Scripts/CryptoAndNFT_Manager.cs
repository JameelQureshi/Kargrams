using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System;
using System.Text;

public class CryptoAndNFT_Manager : MonoBehaviour
{
   // public float[] BountyPrices = {10.00f,1.00f,1.00f,25.00f,1.00f,0.50f,5.00f,10.00f,2.50f,1.00f,2.50f,5.00f,2.50f,5.00f,0,0};
   // public GameObject BountyInfoPanel;
   // public GameObject DexiBountyPanel;
   // public GameObject OtherBountiesPanel;
   // public GameObject PopupPanel;
   // public GameObject RedeemedPopup;
   // public GameObject PopupImage;
   // public GameObject DexiBountiesPanel;
   // public GameObject BuyRedemptionPopup;
   // public GameObject BlockChainAssetPanel;
   // public GameObject WalletAddressPopup;
   // public Sprite DefaultButtonSprite;
   // public Sprite SelectedButtonSprite;
   // public Image InfoIconBG;
   // public Color DefaultBountyColor;
   // public Color SelectedBountyColor;
   // public Image BountyIcon;
   // public Text BountyHeadingText;
   // public TMP_Text BountyDetailText;
   // public Text RedeemableBountieText;
   // public Text SelectedBountyAmount;
   // public Text BountyAddressTitle;
   // public Text BountyAddress;
   // //public GameObject BountyPriceText;
   // public GameObject BountyPriceTextInfoPanel;
   // public Text ChooseYourBountyText;
   // public Sprite[] IconBG;
   // public Button[] CryptoAnd_NFT_Buttons;
   // public Button[] RedeemableBountiesButtons;
   // public Sprite[] IconSprites;
   // public string[] IconNames;
   // public string[] IconShortNames;
   // public string[] BountyNamesForWalletAddress;
   // public string[] IconDetailText;
    
   // //public string[] BountyPrices;
   // private string SelectedBountyName;

   // private int BoountyCounter=0;
   // private int BountyCount = 0;
   // private string SelectedBountyText;
   // private int MainBountyIndex=0;

   // private int SelectedBountyID;
   // private int SelectedBountyCount;
   // private string SelectedBountyAddress;
   // //public AvailabeRedeemableBountyRoot AvailabeRedeemableBountiesList;
   // //private List<WalletDetails> wallet_Details;
   // //public DEXI_NFTs_RedeemableData.Root DEXI_NFTs;
   // [Header("DEXI Bounties Data")]
   // public Text DEXISelectedCountText;
   // public Text DEXIAddress;
   // private int DexiCommonCounter = 0;
   // private int DexiUnCommonCounter = 0;
   // private int DexiRARE_Counter = 0;
   // private int DexiEPIC_Counter = 0;
   // private int DexiLegendaryCounter = 0;
   // private int DEXI_BountyCounter = 0;
   //// public DEXI_Bounties[] DEXIBounties;

   // private int DexiCounts = 0;
   //// public DEXI_Data.Root AvailableDexiBountiesToRedeem;
   // // Start is called before the first frame update
   // void Start()
   // {
   //     DexiCommonCounter = 0;
   //     DexiUnCommonCounter = 0;
   //     DexiRARE_Counter = 0;
   //     DexiEPIC_Counter = 0;
   //     DexiLegendaryCounter = 0;
   //     DefaultBountyColor.a = 1f;
   //     SelectedBountyColor.a = 1f;
   //     SelectedBountyName = "";
   //     BuyRedemptionPopup.SetActive(false);
   //     BlockChainAssetPanel.SetActive(false);
   //     WalletAddressPopup.SetActive(false);
   //     //SetDefaultIcon(CryptoAnd_NFT_Buttons, DefaultButtonSprite);
   //     SetDefaultIcon(RedeemableBountiesButtons, DefaultButtonSprite);
   //     BoountyCounter = 0;
   //     StartCoroutine(GetListOfBountiesToRedeem());
   //     StartCoroutine(GetListOfNFTBountiesToRedeem());
   //     StartCoroutine(GetListOfDexiBountiesToRedeem());
   //     BountyInfoPanel.SetActive(false);
   //     DexiBountyPanel.SetActive(false);
   // }
   // private IEnumerator GetListOfNFTBountiesToRedeem()
   // {
   //     string requestName = "api/v1/locations/request_to_redeem?bounty_group=DEXI_NFTs";

   //     using (UnityWebRequest www = UnityWebRequest.Get(AuthManager.BASE_URL + requestName))
   //     {
   //         www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
   //         yield return www.SendWebRequest();

   //         if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
   //         {
   //             ConsoleManager.instance.ShowMessage("Network Error!");
   //             Debug.Log(www.error);
   //         }
   //         else
   //         {
   //           //  DEXI_NFTs = JsonUtility.FromJson<DEXI_NFTs_RedeemableData.Root>(www.downloadHandler.text);
   //             Debug.Log(www.downloadHandler.text);
   //         }
   //     }
   // }
   // public IEnumerator GetListOfBountiesToRedeem()
   // {
   //     string requestName = "api/v1/locations/request_to_redeem?bounty_group=Crypto";

   //     using (UnityWebRequest www = UnityWebRequest.Get(AuthManager.BASE_URL + requestName))
   //     {
   //         www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
   //         yield return www.SendWebRequest();

   //         if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
   //         {
   //             ConsoleManager.instance.ShowMessage("Network Error!");
   //             Debug.Log(www.error);
   //         }
   //         else
   //         {
   //            // AvailabeRedeemableBountiesList = JsonUtility.FromJson<AvailabeRedeemableBountyRoot>(www.downloadHandler.text);
   //             Debug.Log(www.downloadHandler.text);
   //         }
   //     }
   // }
   // private IEnumerator GetListOfDexiBountiesToRedeem()
   // {
   //     string requestName = "api/v1/locations/request_to_redeem?bounty_group=DEXI";

   //     using (UnityWebRequest www = UnityWebRequest.Get(AuthManager.BASE_URL + requestName))
   //     {
   //         www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
   //         yield return www.SendWebRequest();

   //         if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
   //         {
   //             ConsoleManager.instance.ShowMessage("Network Error!");
   //             Debug.Log(www.error);
   //         }
   //         else
   //         {
   //             //AvailableDexiBountiesToRedeem = JsonUtility.FromJson<DEXI_Data.Root>(www.downloadHandler.text);
   //             //DexiCounts = AvailableDexiBountiesToRedeem.data.Legendary.available_bounty_count + AvailableDexiBountiesToRedeem.data.Epic.available_bounty_count + AvailableDexiBountiesToRedeem.data.Rare.available_bounty_count + AvailableDexiBountiesToRedeem.data.Uncommon.available_bounty_count + AvailableDexiBountiesToRedeem.data.Common.available_bounty_count;
   //             //Debug.Log(www.downloadHandler.text);
   //         }
   //     }
   // }
   // private IEnumerator CheckWalletAddres(string UserID)
   // {
   //     string requestName = "https://api.dexioprotocol.com:443/wallet/"+ UserID;

   //     using (UnityWebRequest www = UnityWebRequest.Get(requestName))
   //     {
   //         www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
   //         yield return www.SendWebRequest();

   //         if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
   //         {
   //             ConsoleManager.instance.ShowMessage("Network Error!");
   //             Debug.Log(www.error);
   //         }
   //         else
   //         {
   //          //   WalletAddressRoot WalletAddressData = JsonUtility.FromJson<WalletAddressRoot>(www.downloadHandler.text);
   //             //if (WalletAddressData.wallets_available)
   //             //{
   //             //    ConvertWallets(WalletAddressData.wallets);
   //             //    BlockChainAssetPanel.SetActive(true);
   //             //}
   //             //else
   //             //{
   //             //    BlockChainAssetPanel.SetActive(false);
   //             //    WalletAddressPopup.SetActive(true);
   //             //}
   //             LoadingManager.instance.loading.SetActive(false);
   //         }
   //     }
   // }
   // public void CheckWalletAddress()
   // {
   //     LoadingManager.instance.loading.SetActive(true);
   //     StartCoroutine(CheckWalletAddres(DexicashAndRR_Manager.UserID));
   // }
   // void ConvertWallets(string wallets)
   // {
   //     byte[] decodedBytes = Convert.FromBase64String(wallets);
   //     string decodedText = Encoding.UTF8.GetString(decodedBytes);

   //    // wallet_Details = Mapbox.Json.JsonConvert.DeserializeObject<List<WalletDetails>>(decodedText);

   //     //wallet_Details = JsonUtility.FromJson<List<WalletDetails>>(decodedText);
   //     //foreach (WalletDetails Wallet in wallet_Details)
   //     //{
   //     //    Debug.Log(Wallet.platform + ": "+Wallet.address);
   //     //}
   //     Debug.Log("decodedText " + decodedText);
   // }
   // public void FuncToRedeemBounties()
   // {
   //     LoadingManager.instance.loading.SetActive(true);
   //     StartCoroutine(RequestToRedeemBounties(BoountyCounter, SelectedBountyID));
   // }
   // public void FuncToRedeemDexiBounties()
   // {
   //     LoadingManager.instance.loading.SetActive(true);
   //     StartCoroutine(RequestToRedeemBounties(DEXI_BountyCounter, SelectedBountyID));
   // }
   // private IEnumerator RequestToRedeemBounties(int count,int bounty_type_id)
   // {
   //     WWWForm form = new WWWForm();
   //     form.AddField("count", count);
   //     form.AddField("bounty_type_id", bounty_type_id);

   //     //string requestName = "/api/v1/locations/redeem_bounties";
   //     string requestName = "api/v1/locations/redeem_bounties";
   //     using (UnityWebRequest www = UnityWebRequest.Post(AuthManager.BASE_URL + requestName, form))
   //     {
   //         www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
   //         yield return www.SendWebRequest();

   //         if (www.isNetworkError || www.isHttpError)
   //         {
   //             ConsoleManager.instance.ShowMessage("Redemption Error!");
   //             Debug.Log(www.error);
   //             //ResetPanels();
   //             //StatsManager.instance.GetStatsData();
   //             //StartCoroutine(GetListOfBountiesToRedeem());
   //             //StartCoroutine(GetListOfDexiBountiesToRedeem());
   //             //StartCoroutine(GetListOfNFTBountiesToRedeem());
   //             //StartCoroutine(GetRewardRedemptions(DexicashAndRR_Manager.UserID));
   //             PopupPanel.SetActive(false);
   //             RedeemedPopup.SetActive(false);
   //             LoadingManager.instance.loading.SetActive(false);
   //         }
   //         else
   //         {
   //             Debug.Log(www.downloadHandler.text);
   //             Debug.Log("ID of redeemed bounty id " + bounty_type_id);
   //             Debug.Log("ID of redeemed count " + count);
   //             UnFriendResponceRoot successResult = JsonUtility.FromJson<UnFriendResponceRoot>(www.downloadHandler.text);
   //             if (successResult.success)
   //             {
   //                 ResetPanels();
   //                 StatsManager.instance.GetStatsData();
   //                 StartCoroutine(GetListOfBountiesToRedeem());
   //                 StartCoroutine(GetListOfDexiBountiesToRedeem());
   //                 StartCoroutine(GetListOfNFTBountiesToRedeem());
   //                 StartCoroutine(GetRewardRedemptions(DexicashAndRR_Manager.UserID,false));
   //                 ConsoleManager.instance.ShowMessage("Redeemed successfully!");
   //             }
   //             else
   //             {
   //                 ResetPanels();
   //                 //ConsoleManager.instance.ShowMessage("Error to redeem!");
   //                 LoadingManager.instance.loading.SetActive(false);
   //                 BuyRedemptionPopup.SetActive(true);
   //             }
   //         }
   //     }
   // }
   // public void ResetPanels()
   // {
   //     ClearBountyButtonsData();
   //     ResetDexiPanel();
   //     RedeemedPopup.SetActive(false);
   //     PopupImage.SetActive(true);
   //     PopupPanel.SetActive(false);
   //     DexiBountiesPanel.SetActive(false);
   //     OtherBountiesPanel.SetActive(false);
   //     BountyInfoPanel.SetActive(false);
   //     LoadingManager.instance.loading.SetActive(false);
   // }
   // public void EnableBountyPanel()
   // {
   //         if (SelectedBountyName == "DEXI")
   //         {
   //             DisableDexiBounties();
   //             EnableDexiBounties();
   //             DexiBountyPanel.SetActive(true);
   //         }
   //         else
   //         {
   //             OtherBountiesPanel.SetActive(true);
   //         }
   // }
   // public void SelectButton(int Index)
   // {
        
   //     BoountyCounter = 0;
   //     MainBountyIndex = Index;
   //     SelectedBountyName = IconShortNames[Index];
   //     SetDataOfSelectedBounty(Index);
   //     Debug.Log("Index "+ Index);
   //     //SelectBountyToRedeem(Index);
   //     //SetDefaultIcon(CryptoAnd_NFT_Buttons, DefaultButtonSprite);
   //     //CryptoAnd_NFT_Buttons[Index].GetComponent<Image>().sprite = SelectedButtonSprite;
   //     BountyIcon.sprite = IconSprites[Index];
   //     //BountyHeadingText.text = "What is " + IconNames[Index] + "?";
   //     if (IconNames[Index] == "DEXI CreaterHub NFTs" || IconNames[Index] == "DEXI GameVault NFTs")
   //     {
   //         BountyHeadingText.text = "What are " + IconNames[Index] + "?";
   //     }
   //     else
   //     {
   //         BountyHeadingText.text = "What is " + IconNames[Index] + "?";
   //     }
   //     BountyDetailText.text = "" + IconDetailText[Index];
   //     SetIconToSelectedBounty(IconSprites[Index]);
   //     SetPriceOfSelectedBounty(Index);
   //     ChooseYourBountyText.text = "Choose your " + IconShortNames[Index] + " Bounties";
   //     if (SelectedBountyName == "DEXI")
   //     {
   //         RedeemableBountieText.text = "You have " + DexiCounts + " " + IconShortNames[Index] + " Bounties to Redeem";
   //     }
   //     else
   //     {
   //         RedeemableBountieText.text = "You have " + SelectedBountyCount + " " + IconShortNames[Index] + " Bounties to Redeem";
   //     }
   //     SelectedBountyAmount.text = "" + BoountyCounter + " " + SelectedBountyName;
   //     BountyAddressTitle.text = IconShortNames[Index] + " Address";
   //     BountyInfoPanel.SetActive(true);
   //     BountyAddress.text = "" + SelectedBountyAddress;
   //     InfoIconBG.sprite = IconBG[Index];
   //     GetWalletAddressOfBounty(Index, BountyAddress);
   // }
   // private void GetWalletAddressOfBounty(int Index,Text BountyAddress)
   // {
   //     Debug.Log("Wallet index "+Index);
   //     Debug.Log("Wallet Name "+ BountyNamesForWalletAddress[Index]);
   //     //foreach (WalletDetails Wallet in wallet_Details)
   //     //{
   //     //    Debug.Log(Wallet.id+": "+Wallet.address);
   //     //    if (Wallet.id== BountyNamesForWalletAddress[Index])
   //     //    {
   //     //        Debug.Log(BountyNamesForWalletAddress[Index]+" address "+ Wallet.address);
   //     //        BountyAddress.text = Wallet.address.ToString();
   //     //    }
   //     //}
   // }
   // private IEnumerator GetRewardRedemptions(string UserID,bool Popup_Panel)
   // {
   //     Debug.Log("GetRewardRedemptions");
   //     string requestName = "https://api.dexioprotocol.com/redemptions/" + UserID + "/balance?";

   //     using (UnityWebRequest www = UnityWebRequest.Get(requestName))
   //     {
   //         www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
   //         yield return www.SendWebRequest();

   //         if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
   //         {
   //             ConsoleManager.instance.ShowMessage("Network Error!");
   //             Debug.Log("Redemption Error");
   //             Debug.Log(www.error);
   //             PopupPanel.SetActive(false);
   //             RedeemedPopup.SetActive(false);
   //             PopupImage.SetActive(true);
   //         }
   //         else
   //         {
   //             Debug.Log("RewardRedemptions Data " + www.downloadHandler.text);
   //             RR_And_DexicashRoot RewardRedemptionData = JsonUtility.FromJson<RR_And_DexicashRoot>(www.downloadHandler.text);
   //             if (int.Parse(RewardRedemptionData.Balance.balance)>0)
   //             {
   //                 if (Popup_Panel)
   //                 {
   //                     PopupPanel.SetActive(true);
   //                     PopupImage.SetActive(true);
   //                 }
   //                 else
   //                 {
   //                     PopupPanel.SetActive(false);
   //                 }
   //             }
   //             else
   //             {
   //                 BuyRedemptionPopup.SetActive(true);
   //             }
   //             LoadingManager.instance.loading.SetActive(false);
   //         }
   //     }
   // }
   
   // public void EnableConfirmationPanel()
   // {
   //     Debug.Log("BoountyCounter "+ BoountyCounter);
   //     if (BoountyCounter > 0 )
   //     {
   //         LoadingManager.instance.loading.SetActive(true);
   //         StartCoroutine(GetRewardRedemptions(DexicashAndRR_Manager.UserID,true));
   //     }
   //     //if (SelectedBountyName != "DEXI" && BoountyCounter > 0)
   //     //{
   //     //    PopupPanel.SetActive(true);
   //     //}
   //     //else
   //     //{
   //     //    PopupPanel.SetActive(false);
   //     //}
   // }
   // private void SetDataOfSelectedBounty(int Index)
   // {
   //     SelectedBountyCount = 0;
   //     SelectedBountyAddress = "";
   //     Debug.Log("IconShortNames " + IconShortNames[Index]);
   //     if (IconShortNames[Index]== "BNB")
   //     {
   //         SelectedBountyID = AvailabeRedeemableBountiesList.data.BNB.id;
   //         SelectedBountyCount = AvailabeRedeemableBountiesList.data.BNB.available_bounty_count;
   //         //SelectedBountyAddress = AvailabeRedeemableBountiesList.data.ATOM.address.ToString();
   //     }
   //     else if (IconShortNames[Index] == "ATOM")
   //     {
   //         SelectedBountyID = AvailabeRedeemableBountiesList.data.ATOM.id;
   //         SelectedBountyCount = AvailabeRedeemableBountiesList.data.ATOM.available_bounty_count;
   //         //SelectedBountyAddress = AvailabeRedeemableBountiesList.data.ATOM.address.ToString();
   //     }
   //     else if (IconShortNames[Index] == "AVAX")
   //     {
   //         SelectedBountyID = AvailabeRedeemableBountiesList.data.AVAX.id;
   //         SelectedBountyCount = AvailabeRedeemableBountiesList.data.AVAX.available_bounty_count;
   //         //SelectedBountyAddress = AvailabeRedeemableBountiesList.data.AVAX.address.ToString();
   //     }
   //     else if (IconShortNames[Index] == "BTC")
   //     {
   //         SelectedBountyID = AvailabeRedeemableBountiesList.data.BTC.id;
   //         SelectedBountyCount = AvailabeRedeemableBountiesList.data.BTC.available_bounty_count;
   //         //SelectedBountyAddress = AvailabeRedeemableBountiesList.data.BTC.address.ToString();
   //     }
   //     else if (IconShortNames[Index] == "CRO")
   //     {
   //         SelectedBountyID = AvailabeRedeemableBountiesList.data.CRO.id;
   //         SelectedBountyCount = AvailabeRedeemableBountiesList.data.CRO.available_bounty_count;
   //         //SelectedBountyAddress = AvailabeRedeemableBountiesList.data.CRO.address.ToString();
   //     }
   //     else if (IconShortNames[Index] == "DOT")
   //     {
   //         SelectedBountyID = AvailabeRedeemableBountiesList.data.DOT.id;
   //         SelectedBountyCount = AvailabeRedeemableBountiesList.data.DOT.available_bounty_count;
   //         //SelectedBountyAddress = AvailabeRedeemableBountiesList.data.DOT.address.ToString();
   //     }
   //     else if (IconShortNames[Index] == "ETH")
   //     {
   //         SelectedBountyID = AvailabeRedeemableBountiesList.data.ETH.id;
   //         SelectedBountyCount = AvailabeRedeemableBountiesList.data.ETH.available_bounty_count;
   //         //SelectedBountyAddress = AvailabeRedeemableBountiesList.data.ETH.address.ToString();
   //     }
   //     else if (IconShortNames[Index] == "FTM")
   //     {
   //         SelectedBountyID = AvailabeRedeemableBountiesList.data.FTM.id;
   //         SelectedBountyCount = AvailabeRedeemableBountiesList.data.FTM.available_bounty_count;
   //         //SelectedBountyAddress = AvailabeRedeemableBountiesList.data.FTM.address.ToString();
   //     }
   //     else if (IconShortNames[Index] == "MATIC")
   //     {
   //         SelectedBountyID = AvailabeRedeemableBountiesList.data.MATIC.id;
   //         SelectedBountyCount = AvailabeRedeemableBountiesList.data.MATIC.available_bounty_count;
   //         //SelectedBountyAddress = AvailabeRedeemableBountiesList.data.MATIC.address.ToString();
   //     }
   //     else if (IconShortNames[Index] == "ONE")
   //     {
   //         SelectedBountyID = AvailabeRedeemableBountiesList.data.ONE.id;
   //         SelectedBountyCount = AvailabeRedeemableBountiesList.data.ONE.available_bounty_count;
   //         //SelectedBountyAddress = AvailabeRedeemableBountiesList.data.ONE.address.ToString();
   //     }
   //     else if (IconShortNames[Index] == "SOL")
   //     {
   //         SelectedBountyID = AvailabeRedeemableBountiesList.data.SOL.id;
   //         SelectedBountyCount = AvailabeRedeemableBountiesList.data.SOL.available_bounty_count;
   //         //SelectedBountyAddress = AvailabeRedeemableBountiesList.data.SOL.address.ToString();
   //     }
   //     else if (IconShortNames[Index] == "TRX")
   //     {
   //         SelectedBountyID = AvailabeRedeemableBountiesList.data.TRX.id;
   //         SelectedBountyCount = AvailabeRedeemableBountiesList.data.TRX.available_bounty_count;
   //         //SelectedBountyAddress = AvailabeRedeemableBountiesList.data.TRX.address.ToString();
   //     }
   //     else if (IconShortNames[Index] == "VET")
   //     {
   //         SelectedBountyID = AvailabeRedeemableBountiesList.data.VET.id;
   //         SelectedBountyCount = AvailabeRedeemableBountiesList.data.VET.available_bounty_count;
   //         //SelectedBountyAddress = AvailabeRedeemableBountiesList.data.VET.address.ToString();
   //     }
   //     else if (IconShortNames[Index] == "DEXI CreatorHub")
   //     {
   //         SelectedBountyID = DEXI_NFTs.data.CreatorHub.id;
   //         SelectedBountyCount = DEXI_NFTs.data.CreatorHub.available_bounty_count;
   //         //SelectedBountyAddress = AvailabeRedeemableBountiesList.data.TRX.address.ToString();
   //     }
   //     else if (IconShortNames[Index] == "DEXI GameVault")
   //     {
   //         SelectedBountyID = DEXI_NFTs.data.GameVault.id;
   //         SelectedBountyCount = DEXI_NFTs.data.GameVault.available_bounty_count;
   //         //SelectedBountyAddress = AvailabeRedeemableBountiesList.data.VET.address.ToString();
   //     }
   //     else
   //     {
   //         Debug.Log("Not Matched");
   //     }
   // }
   // public void SelectBountyToRedeem(int index)
   // {
   //     ClearBountyButtonsData();
   //     Debug.Log("Bounty Index "+index);
   //     DefaultBountyColor.a = 1f;
   //     SelectedBountyColor.a = 1f;
   //     //RedeemableBountiesButtons[index].interactable = false;
   //     if (RedeemableBountiesButtons[index].GetComponent<BountyItem>().BountySelected==false)
   //     {
   //         BoountyCounter++;
   //         RedeemableBountiesButtons[index].GetComponent<Image>().color = SelectedBountyColor;
   //         RedeemableBountiesButtons[index].GetComponent<BountyItem>().BountySelected = true;
   //     }
   //     else
   //     {
   //         BoountyCounter--;
   //         RedeemableBountiesButtons[index].GetComponent<Image>().color = DefaultBountyColor;
   //         RedeemableBountiesButtons[index].GetComponent<BountyItem>().BountySelected = false;
   //     }
   //     if (BoountyCounter > 0 && (BountyPrices[MainBountyIndex]) > 0)
   //     {
   //         SelectedBountyAmount.text = "" + BoountyCounter + " " + SelectedBountyName + " = $" + ((BoountyCounter * (BountyPrices[MainBountyIndex])).ToString("#0.00"));
   //     }
   //     else
   //     {
   //         SelectedBountyAmount.text = "" + BoountyCounter + " " + SelectedBountyName;
   //     }
   //     Debug.Log("BoountyCounter "+ BoountyCounter);
        
   // }
   // public void UnCommonDexiBounty(int Index)
   // {
   //     DexiCommonCounter = 0;
   //     DexiRARE_Counter = 0;
   //     DexiEPIC_Counter = 0;
   //     DexiLegendaryCounter = 0;
   //     ResetDexiPanel();
   //     DexiUnCommonCounter++;
   //     DEXI_BountyReset(DEXIBounties[0].DEXI_Common, DEXIBounties[0].DEXI_Rare, DEXIBounties[0].DEXI_EPIC, DEXIBounties[0].DEXI_Legendary);

   //     DEXI_BountyManager(DEXIBounties[0].DEXI_UnCommon,Index, 2.50f,DexiUnCommonCounter, AvailableDexiBountiesToRedeem.data.Uncommon.id);
   // }
   // public void CommonDexiBounty(int Index)
   // {
   //     DexiUnCommonCounter = 0;
   //     DexiRARE_Counter = 0;
   //     DexiEPIC_Counter = 0;
   //     DexiLegendaryCounter = 0;
   //     ResetDexiPanel();
   //     DexiCommonCounter++;
   //     DEXI_BountyReset(DEXIBounties[0].DEXI_UnCommon, DEXIBounties[0].DEXI_Rare, DEXIBounties[0].DEXI_EPIC, DEXIBounties[0].DEXI_Legendary);

   //     DEXI_BountyManager(DEXIBounties[0].DEXI_Common, Index, 1.00f,DexiCommonCounter, AvailableDexiBountiesToRedeem.data.Common.id);
   // }
   // public void RARE_DexiBounty(int Index)
   // {
   //     DexiCommonCounter = 0;
   //     DexiUnCommonCounter = 0;
   //     DexiEPIC_Counter = 0;
   //     DexiLegendaryCounter = 0;
   //     ResetDexiPanel();
   //     DexiRARE_Counter++;
   //     DEXI_BountyReset(DEXIBounties[0].DEXI_Common, DEXIBounties[0].DEXI_UnCommon, DEXIBounties[0].DEXI_EPIC, DEXIBounties[0].DEXI_Legendary);

   //     DEXI_BountyManager(DEXIBounties[0].DEXI_Rare, Index, 5.00f,DexiRARE_Counter, AvailableDexiBountiesToRedeem.data.Rare.id);
   // }
   // public void EPIC_DexiBounty(int Index)
   // {
   //     DexiCommonCounter = 0;
   //     DexiUnCommonCounter = 0;
   //     DexiRARE_Counter = 0;
   //     DexiLegendaryCounter = 0;
   //     ResetDexiPanel();
   //     DexiEPIC_Counter++;
   //     DEXI_BountyReset(DEXIBounties[0].DEXI_Common, DEXIBounties[0].DEXI_Rare, DEXIBounties[0].DEXI_UnCommon, DEXIBounties[0].DEXI_Legendary);

   //     DEXI_BountyManager(DEXIBounties[0].DEXI_EPIC, Index, 10.00f,DexiEPIC_Counter, AvailableDexiBountiesToRedeem.data.Epic.id);
   // }
   // public void LegendaryDexiBounty(int Index)
   // {
   //     DexiCommonCounter = 0;
   //     DexiUnCommonCounter = 0;
   //     DexiRARE_Counter = 0;
   //     DexiEPIC_Counter = 0;
   //     ResetDexiPanel();
   //     DexiLegendaryCounter++;
   //     DEXI_BountyReset(DEXIBounties[0].DEXI_Common, DEXIBounties[0].DEXI_Rare, DEXIBounties[0].DEXI_EPIC, DEXIBounties[0].DEXI_UnCommon);

   //     DEXI_BountyManager(DEXIBounties[0].DEXI_Legendary, Index, 25.00f,DexiLegendaryCounter, AvailableDexiBountiesToRedeem.data.Legendary.id);
   // }

   // private void DEXI_BountyManager(Button[] DEXI_BountiesArray, int ArrayIndex, float Amount,int BountyCounter,int BountyID)
   // {
   //     DEXI_BountiesArray[ArrayIndex].interactable = false;
   //     Debug.Log("Amount"+ Amount);
   //     DEXISelectedCountText.text = "" + BountyCounter + " = DEXI" + " $" + ((BountyCounter * Amount).ToString("#0.00"));
   //     BoountyCounter = BountyCounter;
   //     SelectedBountyID = BountyID;
   // }

   // private void DEXI_BountyReset(Button[] Array1, Button[] Array2, Button[] Array3, Button[] Array4)
   // {
        
   //     for (int i = 0; i < Array1.Length; i++)
   //     {
   //         Array1[i].interactable = true;
   //         Array2[i].interactable = true;
   //         Array3[i].interactable = true;
   //         Array4[i].interactable = true;
   //         Array1[i].GetComponent<BountyItem>().BountySelected = false;
   //         Array2[i].GetComponent<BountyItem>().BountySelected = false;
   //         Array3[i].GetComponent<BountyItem>().BountySelected = false;
   //         Array4[i].GetComponent<BountyItem>().BountySelected = false;

   //     }
   // }
   // public void ResetDexiPanel()
   // {
   //     DexiCommonCounter = 0;
   //     DexiUnCommonCounter = 0;
   //     DexiRARE_Counter = 0;
   //     DexiEPIC_Counter = 0;
   //     DexiLegendaryCounter = 0;
   //     BoountyCounter = 0;
   //     DEXISelectedCountText.text = "";
   //     for (int i = 0; i < DEXIBounties[0].DEXI_Common.Length; i++)
   //     {
   //         DEXIBounties[0].DEXI_Common[i].interactable = true;
   //         DEXIBounties[0].DEXI_UnCommon[i].interactable = true;
   //         DEXIBounties[0].DEXI_Rare[i].interactable = true;
   //         DEXIBounties[0].DEXI_EPIC[i].interactable = true;
   //         DEXIBounties[0].DEXI_Legendary[i].interactable = true;

   //         DEXIBounties[0].DEXI_Common[i].GetComponent<BountyItem>().BountySelected = false;
   //         DEXIBounties[0].DEXI_UnCommon[i].GetComponent<BountyItem>().BountySelected = false;
   //         DEXIBounties[0].DEXI_Rare[i].GetComponent<BountyItem>().BountySelected = false;
   //         DEXIBounties[0].DEXI_EPIC[i].GetComponent<BountyItem>().BountySelected = false;
   //         DEXIBounties[0].DEXI_Legendary[i].GetComponent<BountyItem>().BountySelected = false;
   //     }
   // }
   // private void SetDefaultIcon(Button[] Button_Array, Sprite Icon)
   // {
   //     foreach (Button Button in Button_Array)
   //     {
   //         Button.GetComponent<Image>().sprite = Icon;
   //     }
   // }
   // private void SetDefaultColor(Button[] Button_Array, Sprite Icon)
   // {
   //     foreach (Button Button in Button_Array)
   //     {
   //         Button.GetComponent<Image>().color = DefaultBountyColor;
   //     }
   // }
   // private void SetIconToSelectedBounty(Sprite Icon)
   // {
   //     Debug.Log("SetIconToSelectedBounty");
   //     foreach (Button Button in RedeemableBountiesButtons)
   //     {
   //         Button.GetComponent<Image>().sprite = DefaultButtonSprite;
   //         Button.transform.GetChild(0).GetComponent<Image>().sprite = Icon;
   //         Button.interactable = true;
   //         Button.gameObject.SetActive(false);
   //     }
   //     Debug.Log("SelectedBountyData.available_bounty_count " + SelectedBountyCount);
   //     for (int i = 0; i < SelectedBountyCount; i++)
   //     {
   //         RedeemableBountiesButtons[i].gameObject.SetActive(true);
   //     }
   // }
   // private void DisableDexiBounties()
   // {
   //     foreach (Button Button in DEXIBounties[0].DEXI_Legendary)
   //     {
   //         Button.interactable = true;
   //         Button.gameObject.SetActive(false);
   //     }
   //     foreach (Button Button in DEXIBounties[0].DEXI_EPIC)
   //     {
   //         Button.interactable = true;
   //         Button.gameObject.SetActive(false);
   //     }
   //     foreach (Button Button in DEXIBounties[0].DEXI_Rare)
   //     {
   //         Button.interactable = true;
   //         Button.gameObject.SetActive(false);
   //     }
   //     foreach (Button Button in DEXIBounties[0].DEXI_UnCommon)
   //     {
   //         Button.interactable = true;
   //         Button.gameObject.SetActive(false);
   //     }
   //     foreach (Button Button in DEXIBounties[0].DEXI_Common)
   //     {
   //         Button.interactable = true;
   //         Button.gameObject.SetActive(false);
   //     }
   // }
   // private void EnableDexiBounties()
   // {
   //     for (int i = 0; i < AvailableDexiBountiesToRedeem.data.Legendary.available_bounty_count; i++) 
   //     {
   //         DEXIBounties[0].DEXI_Legendary[i].gameObject.SetActive(true);
   //         DEXIBounties[0].DEXI_Legendary[i].interactable = true;
   //     }
   //     for (int i = 0; i < AvailableDexiBountiesToRedeem.data.Epic.available_bounty_count; i++)
   //     {
   //         DEXIBounties[0].DEXI_EPIC[i].gameObject.SetActive(true);
   //         DEXIBounties[0].DEXI_EPIC[i].interactable = true;
   //     }
   //     for (int i = 0; i < AvailableDexiBountiesToRedeem.data.Rare.available_bounty_count; i++)
   //     {
   //         DEXIBounties[0].DEXI_Rare[i].gameObject.SetActive(true);
   //         DEXIBounties[0].DEXI_Rare[i].interactable = true;
   //     }
   //     for (int i = 0; i < AvailableDexiBountiesToRedeem.data.Uncommon.available_bounty_count; i++)
   //     {
   //         DEXIBounties[0].DEXI_UnCommon[i].gameObject.SetActive(true);
   //         DEXIBounties[0].DEXI_UnCommon[i].interactable = true;
   //     }
   //     for (int i = 0; i < AvailableDexiBountiesToRedeem.data.Common.available_bounty_count; i++)
   //     {
   //         DEXIBounties[0].DEXI_Common[i].gameObject.SetActive(true);
   //         DEXIBounties[0].DEXI_Common[i].interactable = true;
   //     }
   //     GetWalletAddressOfBounty(5, DEXIAddress);
   // }
   // private void SetPriceOfSelectedBounty(int Index)
   // {
   //     if ((BountyPrices[MainBountyIndex]) > 0 )
   //     {
   //         Debug.Log("IndexIndex " + Index);
   //         BountyPriceTextInfoPanel.SetActive(true);
   //         BountyPriceTextInfoPanel.transform.GetComponentInChildren<Text>().text = "$" + (BountyPrices[Index].ToString("#0.00")) + " Per Bounty";
   //     }
   //     else
   //     {
   //         Debug.Log("else price " + BountyPrices[Index]);
   //         BountyPriceTextInfoPanel.SetActive(false);
   //     }
   // }
   // public void ClearBountyButtonsData()
   // {
   //     BoountyCounter = 0;

   //     DexiCommonCounter = 0;
   //     DexiUnCommonCounter = 0;
   //     DexiRARE_Counter = 0;
   //     DexiEPIC_Counter = 0;
   //     DexiLegendaryCounter = 0;

   //     SelectedBountyAmount.text = BoountyCounter+" "+ SelectedBountyName;
   //     foreach (Button Button in RedeemableBountiesButtons)
   //     {
   //         Button.GetComponent<BountyItem>().BountySelected = false;
   //     }
   //     SetDefaultColor(RedeemableBountiesButtons, DefaultButtonSprite);
   // }
    //private void SetBountyCountAndAddress(int Index)
    //{
    //    foreach (var item in AvailabeRedeemableBountiesList.data)
    //    {

    //    }
    //}
}
