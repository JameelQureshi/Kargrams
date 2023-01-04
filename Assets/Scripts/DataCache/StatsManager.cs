using System.Collections;
using System.Collections.Generic;
using PedometerU.Tests;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    public static StatsManager instance;

    public Text weekly_bounty_count_Text;
    public Text monthly_bounty_count_Text;
    public Text weekly_bounty_count_2_Text;
    public Text monthly_bounty_count_2_Text;
    public Text qr_all_count_Text;
    public Text qr_available_count_Text;
    public Text dexicash_all_count_Text;
    public Text dexicash_available_count_Text;

    //public Text dexicash_available_count_2_Text;
    public Text qr_available_count_2_Text;


    [Header("Crypto Text")]
    public Text BTC;
    public Text ETH;
    public Text SOL;
    public Text DOT;
    public Text TRX;
    public Text VET;
    public Text MATIC;
    public Text BNB;
    public Text LINK;
    public Text ONE;
    public Text ATOM;
    public Text FTM;
    public Text Avax;

    //public Text DXG;
    public Text DEXI;

    public Text BSL;

    [Header("New Crypto Text")]
    public Text BTC_Collected;
    public Text BTC_Redeemed;
    public Text ETH_Collected;
    public Text ETH_Redeemed;
    public Text SOL_Collected;
    public Text SOL_Redeemed;
    public Text DOT_Collected;
    public Text DOT_Redeemed;
    public Text TRX_Collected;
    public Text TRX_Redeemed;
    public Text VET_Collected;
    public Text VET_Redeemed;
    public Text MATIC_Collected;
    public Text MATIC_Redeemed;
    public Text ONE_Collected;
    public Text ONE_Redeemed;
    public Text ATOM_Collected;
    public Text ATOM_Redeemed;
    public Text FTM_Collected;
    public Text FTM_Redeemed;
    public Text Avax_Collected;
    public Text Avax_Redeemed;
    //public Text ADA_Collected;
    //public Text ADA_Redeemed;
    public Text CRO_Collected;
    public Text CRO_Redeemed;
    public Text BNB_Collected;
    public Text BNB_Redeemed;

    //public Text DXG;
    //public Text DEXI_Collected;
    //public Text DEXI_Redeemed;

    [Header("NFTs Text")]
    public Text DEXINFT;
    public Text BakerySwapNFT;
    public Text SOLNFT;
    public Text EnjinNFT;
    public Text DXGNFT;
    public Text OpenSeaNFT;
    public Text ElrondNFT;

    [Header("GameAssets Text")]
    public Text DexiKnightsCollected;
    public Text DexiDragonsCollected;

    [Header("New GameAssets Text")]
    public Text DexiCreatorHub_Collected;
    public Text DexiGameVault_Collected;
    public Text DexiCreatorHub_Redeemed;
    public Text DexiGameVault_Redeemed;

    [Header("DEXI Assets Text")]
    public Text DEXI_Consumed_Legendary;
    public Text DEXI_Consumed_Epic;
    public Text DEXI_Consumed_Rare;
    public Text DEXI_Consumed_Uncommon;
    public Text DEXI_Consumed_Common;

    public Text DEXI_Redeemed_Legendary;
    public Text DEXI_Redeemed_Epic;
    public Text DEXI_Redeemed_Rare;
    public Text DEXI_Redeemed_Uncommon;
    public Text DEXI_Redeemed_Common;
    // Start is called before the first frame update

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

    void Start()
    {
        //StartCoroutine(GetBountiesCollected());
        //GetStatsData();
        //StartCoroutine(GetPartnersStats());
    }

    //public void GetStatsData()
    //{
    //    StartCoroutine(GetNFTStats());
    //    StartCoroutine(GetCryptoStats());
    //    StartCoroutine(GetGameAssetsStats());
    //    StartCoroutine(GetDEXIStats());
    //}
    //public IEnumerator GetBountiesCollected()
    //{
    //    string requestName = "api/v1/stats/dexicash_stats";
        
    //    using (UnityWebRequest www = UnityWebRequest.Get(AuthManager.BASE_URL + requestName))
    //    {
    //        www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
    //        yield return www.SendWebRequest();

    //        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
    //        {
    //            ConsoleManager.instance.ShowMessage("Network Error!");
    //            Debug.Log(www.error);
    //        }
    //        else
    //        {
    //            HomeStats homeStats = JsonUtility.FromJson<HomeStats>(www.downloadHandler.text);
    //            DisplayData(homeStats);
    //        }
    //    }
    //}
    

    //public IEnumerator GetNFTStats()
    //{
    //    //string requestName = "api/v1/stats/nft_stats";
    //    string requestName = "api/v1/stats/individual_bounty_stats?bounty_group=DEXI_NFTs";

    //    using (UnityWebRequest www = UnityWebRequest.Get(AuthManager.BASE_URL + requestName))
    //    {
    //        www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
    //        yield return www.SendWebRequest();

    //        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
    //        {
    //            ConsoleManager.instance.ShowMessage("Network Error!");
    //            Debug.Log(www.error);
    //        }
    //        else
    //        {
    //            NFT_StatsRoot nFTStats = JsonUtility.FromJson<NFT_StatsRoot>(www.downloadHandler.text);
    //            //NFTStats nFTStats = JsonUtility.FromJson<NFTStats>(www.downloadHandler.text);
    //            //DisplayNFTStats(nFTStats);
    //            Debug.Log("NFT "+www.downloadHandler.text);
    //            NFTStatsManager(nFTStats);
    //        }
    //    }
    //}
    //public IEnumerator GetDEXIStats()
    //{
    //    //string requestName = "api/v1/stats/crypto_stats";
    //    string requestName = "api/v1/stats/individual_bounty_stats?bounty_group=DEXI";

    //    using (UnityWebRequest www = UnityWebRequest.Get(AuthManager.BASE_URL + requestName))
    //    {
    //        www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
    //        yield return www.SendWebRequest();

    //        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
    //        {
    //            ConsoleManager.instance.ShowMessage("Network Error!");
    //            Debug.Log(www.error);
    //        }
    //        else
    //        {
    //            //CryptoStats cryptoStats = JsonUtility.FromJson<CryptoStats>(www.downloadHandler.text);
    //            //Debug.Log("cryptoStats " + www.downloadHandler.text);
    //            //DisplayCryptoStats(cryptoStats);
    //            DEXI_StatsRoot DEXI_Stats = JsonUtility.FromJson<DEXI_StatsRoot>(www.downloadHandler.text);
    //            Debug.Log("DEXI " + www.downloadHandler.text);
    //            if (DEXI_Stats.success)
    //            {
    //                Debug.Log("ATOM " + DEXI_Stats.consumed_DEXI_bounties.Common);
    //                DEXI_StatsManager(DEXI_Stats);
    //            }
    //            else
    //            {
    //                ConsoleManager.instance.ShowMessage("Crypto Stats Error!");
    //            }
    //        }
    //    }
    //}
    //public IEnumerator GetCryptoStats()
    //{
    //    //string requestName = "api/v1/stats/crypto_stats";
    //    string requestName = "api/v1/stats/individual_bounty_stats?bounty_group=Crypto";

    //    using (UnityWebRequest www = UnityWebRequest.Get(AuthManager.BASE_URL + requestName))
    //    {
    //        www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
    //        yield return www.SendWebRequest();

    //        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
    //        {
    //            ConsoleManager.instance.ShowMessage("Network Error!");
    //            Debug.Log(www.error);
    //        }
    //        else
    //        {
    //            //CryptoStats cryptoStats = JsonUtility.FromJson<CryptoStats>(www.downloadHandler.text);
    //            //Debug.Log("cryptoStats " + www.downloadHandler.text);
    //            //DisplayCryptoStats(cryptoStats);
    //            CryptoStatRoot cryptoStats = JsonUtility.FromJson<CryptoStatRoot>(www.downloadHandler.text);
    //            Debug.Log("Crypto " + www.downloadHandler.text);
    //            if (cryptoStats.success)
    //            {
    //                Debug.Log("ATOM "+cryptoStats.consumed_Crypto_bounties.ATOM);
    //                CryptoStatsManager(cryptoStats);
    //            }
    //            else
    //            {
    //                ConsoleManager.instance.ShowMessage("Crypto Stats Error!");
    //            }
    //        }
    //    }
    //}

    //public IEnumerator GetPartnersStats()
    //{
    //    string requestName = "api/v1/stats/bsl_stats";

    //    using (UnityWebRequest www = UnityWebRequest.Get(AuthManager.BASE_URL + requestName))
    //    {
    //        www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
    //        yield return www.SendWebRequest();

    //        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
    //        {
    //            ConsoleManager.instance.ShowMessage("Network Error!");
    //            Debug.Log(www.error);
    //        }
    //        else
    //        {
    //            PartnerStats partnerStats = JsonUtility.FromJson<PartnerStats>(www.downloadHandler.text);
    //            BSL.text = partnerStats.BSL.ToString();
    //        }
    //    }
    //}


    //public IEnumerator GetGameAssetsStats()
    //{
    //    string requestName = "api/v1/stats/individual_bounty_stats?bounty_group=Game_Assets";

    //    using (UnityWebRequest www = UnityWebRequest.Get(AuthManager.BASE_URL + requestName))
    //    {
    //        www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
    //        yield return www.SendWebRequest();

    //        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
    //        {
    //            ConsoleManager.instance.ShowMessage("Network Error!");
    //            Debug.Log(www.error);
    //        }
    //        else
    //        {
    //            //Debug.Log("Game Assets: "+www.downloadHandler.text);
    //            GameAssetsRoot GameAssetsStats = JsonUtility.FromJson<GameAssetsRoot>(www.downloadHandler.text);
                
    //            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
    //            {
    //                ConsoleManager.instance.ShowMessage("Network Error!");
    //                Debug.Log(www.error);
    //            }
    //            else
    //            {
    //                Debug.Log("DexiDragons "+ GameAssetsStats.consumed_Game_Assets_bounties.DexiDragons);
    //                DisplayGameAssetsStats(GameAssetsStats);
    //            }
    //        }
    //    }
    //}

    //private void DEXI_StatsManager(DEXI_StatsRoot DEXI_Stats)
    //{
    //    DEXI_Consumed_Legendary.text = "$"+(25.00*(DEXI_Stats.consumed_DEXI_bounties.Legendary));
    //    DEXI_Consumed_Common.text = "$" + (1.00 * (DEXI_Stats.consumed_DEXI_bounties.Common));
    //    DEXI_Consumed_Uncommon.text = "$" + (2.50 * (DEXI_Stats.consumed_DEXI_bounties.Uncommon));
    //    DEXI_Consumed_Rare.text = "$" + (5.00 * (DEXI_Stats.consumed_DEXI_bounties.Rare));
    //    DEXI_Consumed_Epic.text = "$" + (10.00 * (DEXI_Stats.consumed_DEXI_bounties.Epic));

    //    DEXI_Redeemed_Legendary.text = "$" + (25.00 * (DEXI_Stats.redeemed_DEXI_bounties.Legendary));
    //    DEXI_Redeemed_Common.text = "$" + (1.00 * (DEXI_Stats.redeemed_DEXI_bounties.Common));
    //    DEXI_Redeemed_Uncommon.text = "$" + (2.50 * (DEXI_Stats.redeemed_DEXI_bounties.Uncommon));
    //    DEXI_Redeemed_Rare.text = "$" + (5.00 * (DEXI_Stats.redeemed_DEXI_bounties.Rare));
    //    DEXI_Redeemed_Epic.text = "$" + (10.00 * (DEXI_Stats.redeemed_DEXI_bounties.Epic));
    //}
    //void DisplayGameAssetsStats(GameAssetsRoot GameAssetsStats)
    //{
    //    //DexiKnights.text = gameAssetsStats.Knights.ToString();
    //    //DexiDragons.text = gameAssetsStats.Dragons.ToString();
        
    //    DexiKnightsCollected.text = ""+ GameAssetsStats.consumed_Game_Assets_bounties.DexiKnights.ToString();
    //    DexiDragonsCollected.text = "" + GameAssetsStats.consumed_Game_Assets_bounties.DexiDragons.ToString();
    //}


    //void DisplayData(HomeStats homeStats)
    //{
    //    weekly_bounty_count_Text.text = homeStats.monthly_bounty_count+"";//
    //    monthly_bounty_count_Text.text = homeStats.life_time_bounty_count + "";
    //    weekly_bounty_count_2_Text.text = homeStats.monthly_bounty_count + "";//
    //    monthly_bounty_count_2_Text.text = homeStats.life_time_bounty_count + "";

    //    //DistanceManager.FeetWalkedWeekly = homeStats.weekly_steps_count;
    //    //DistanceManager.FeetWalkedMonthly = homeStats.monthly_steps_count;
    //    Debug.Log("FeetWalkedWeekly "+ DistanceManager.FeetWalkedWeekly);
    //    Debug.Log("FeetWalkedMonthly " + DistanceManager.FeetWalkedMonthly);
    //    //StepCounter.instance.DisplayData();
    //}

    //void DisplayNFTStats(NFTStats nFTStats)
    //{
    //    //DEXINFT.text=nFTStats.DEXINFT.ToString();
    //    //BakerySwapNFT.text = nFTStats.BakerySwapNFT.ToString();
    //    //SOLNFT.text = nFTStats.SOLNFT.ToString();
    //    //EnjinNFT.text = nFTStats.EnjinNFT.ToString();
    //    //DXGNFT.text = nFTStats.DXGNFT.ToString();
    //    //OpenSeaNFT.text = nFTStats.OpenSeaNFT.ToString();
    //    //ElrondNFT.text = nFTStats.ElrondNFT.ToString();

    //    DEXINFT.text = nFTStats.DEXINFT.ToString();
    //    BakerySwapNFT.text = nFTStats.BakerySwapNFT.ToString();
    //    SOLNFT.text = nFTStats.SOLNFT.ToString();
    //    EnjinNFT.text = nFTStats.EnjinNFT.ToString();
    //    DXGNFT.text = nFTStats.DXGNFT.ToString();
    //    OpenSeaNFT.text = nFTStats.OpenSeaNFT.ToString();
    //    ElrondNFT.text = nFTStats.ElrondNFT.ToString();
    //}

    //void DisplayCryptoStats(CryptoStats cryptoStats)
    //{
    //    //BTC.text=cryptoStats.BTC.ToString();
    //    //ETH.text = cryptoStats.ETH.ToString();
    //    //SOL.text = cryptoStats.SOL.ToString();
    //    //DOT.text = cryptoStats.DOT.ToString();
    //    //TRX.text = cryptoStats.TRX.ToString();
    //    //MATIC.text = cryptoStats.MATIC.ToString();
    //    //BNB.text = cryptoStats.BNB.ToString();
    //    //LINK.text = cryptoStats.LINK.ToString();
    //    //ONE.text = cryptoStats.ONE.ToString();
    //    //ATOM.text = cryptoStats.ATOM.ToString();
    //    //FTM.text = cryptoStats.FTM.ToString();
    //    //Avax.text = cryptoStats.AVAX.ToString();
    //    //VET.text = cryptoStats.VET.ToString();

    //    //DXG.text = cryptoStats.DXG.ToString();
    //    //DEXI.text = cryptoStats.DEXI.ToString();

    //    BTC.text="$"+(100* cryptoStats.BTC);
    //    ETH.text = "$" + (50 * cryptoStats.ETH);
    //    LINK.text = "$" + (50 * cryptoStats.LINK);
    //    SOL.text = "$" + (25 * cryptoStats.SOL);
    //    ATOM.text = "$" + (10 * cryptoStats.ATOM);
    //    Avax.text = "$" + (10 * cryptoStats.AVAX);
    //    VET.text = "$" + (5 * cryptoStats.VET);
    //    MATIC.text = "$" + (5 * cryptoStats.MATIC);
    //    DOT.text = "$" + (5 * cryptoStats.DOT);
    //    BNB.text = "$" + (2.50 * cryptoStats.CRO); // BNB has been replaced with CRO
    //    ONE.text = "$" + (2.50 * cryptoStats.ONE);
    //    FTM.text = "$" + (2.50 * cryptoStats.FTM);
    //    TRX.text = "$" + (2.50 * cryptoStats.TRX);


    //    //DXG.text = "$" + (2 * cryptoStats.DXG);
    //    DEXI.text = "$" + (2 * cryptoStats.DEXI);
    //}

    //private void CryptoStatsManager(CryptoStatRoot CryptoStats)
    //{
    //    Debug.Log("atom "+CryptoStats.consumed_Crypto_bounties.ATOM);
    //    BTC_Collected.text = "$"+(25.00*(CryptoStats.consumed_Crypto_bounties.BTC)) +"";
    //    BTC_Redeemed.text = "$" + (25.00 * (CryptoStats.redeemed_Crypto_bounties.BTC)) + "";
    //    ETH_Collected.text = "$" + (10.00 * (CryptoStats.consumed_Crypto_bounties.ETH)) + "";
    //    ETH_Redeemed.text = "$" + (10.00 * (CryptoStats.redeemed_Crypto_bounties.ETH)) + "";
    //    SOL_Collected.text = "$" + (5.00 * (CryptoStats.consumed_Crypto_bounties.SOL)) + "";
    //    SOL_Redeemed.text = "$" + (5.00 * (CryptoStats.redeemed_Crypto_bounties.SOL)) + "";
    //    DOT_Collected.text = "$" + (5.00 * (CryptoStats.consumed_Crypto_bounties.DOT)) + "";
    //    DOT_Redeemed.text = "$" + (5.00 * (CryptoStats.redeemed_Crypto_bounties.DOT)) + "";
    //    TRX_Collected.text = "$" + (2.50 * (CryptoStats.consumed_Crypto_bounties.TRX)) + "";
    //    TRX_Redeemed.text = "$" + (2.50 * (CryptoStats.redeemed_Crypto_bounties.TRX)) + "";
    //    VET_Collected.text = "$" + (5.00 * (CryptoStats.consumed_Crypto_bounties.VET)) + "";
    //    VET_Redeemed.text = "$" + (5.00 * (CryptoStats.redeemed_Crypto_bounties.VET)) + "";
    //    MATIC_Collected.text = "$" + (1.00 * (CryptoStats.consumed_Crypto_bounties.MATIC)) + "";
    //    MATIC_Redeemed.text = "$" + (1.00 * (CryptoStats.redeemed_Crypto_bounties.MATIC)) + "";
    //    ONE_Collected.text = "$" + (2.50 * (CryptoStats.consumed_Crypto_bounties.ONE)) + "";
    //    ONE_Redeemed.text = "$" + (2.50 * (CryptoStats.redeemed_Crypto_bounties.ONE)) + "";
    //    ATOM_Collected.text = "$" + (10.00 * (CryptoStats.consumed_Crypto_bounties.ATOM)) + "";
    //    ATOM_Redeemed.text = "$" + (10.00 * (CryptoStats.redeemed_Crypto_bounties.ATOM)) + "";
    //    FTM_Collected.text = "$" + (2.50 * (CryptoStats.consumed_Crypto_bounties.FTM)) + "";
    //    FTM_Redeemed.text = "$" + (2.50 * (CryptoStats.redeemed_Crypto_bounties.FTM)) + "";
    //    Avax_Collected.text = "$" + (1.00 * (CryptoStats.consumed_Crypto_bounties.AVAX)) + "";
    //    Avax_Redeemed.text = "$" + (1.00 * (CryptoStats.redeemed_Crypto_bounties.AVAX)) + "";
    //    //ADA_Collected.text = "0"; // Not giving in API
    //    //ADA_Redeemed.text = "0"; // Not giving in API
    //    CRO_Collected.text = "$" + (1.00 * (CryptoStats.consumed_Crypto_bounties.CRO)) + "";
    //    CRO_Redeemed.text = "$" + (1.00 * (CryptoStats.redeemed_Crypto_bounties.CRO)) + "";

    //    BNB_Collected.text = "$" + (1.00 * (CryptoStats.consumed_Crypto_bounties.BNB)) + "";
    //    BNB_Redeemed.text = "$" + (1.00 * (CryptoStats.redeemed_Crypto_bounties.BNB)) + "";

    //    //DEXI_Collected.text = CryptoStats.consumed_crypto_bounties.DEXI+"";
    //    //DEXI_Redeemed.text = CryptoStats.redeemed_crypto_bounties.DEXI + "";
    //}
    //private void NFTStatsManager(NFT_StatsRoot nFTStats)
    //{
    //    //Debug.Log("nFTStats.consumed_bounties.DEXI "+ nFTStats.consumed_nft_bounties.DexiCreatorHub);
    //    DexiCreatorHub_Collected.text = ""+nFTStats.consumed_DEXI_NFTs_bounties.CreatorHub;
    //    DexiGameVault_Collected.text = ""+nFTStats.consumed_DEXI_NFTs_bounties.GameVault;
    //    DexiCreatorHub_Redeemed.text = ""+nFTStats.redeemed_DEXI_NFTs_bounties.CreatorHub;
    //    DexiGameVault_Redeemed.text = ""+nFTStats.redeemed_DEXI_NFTs_bounties.GameVault;
    //}
}
