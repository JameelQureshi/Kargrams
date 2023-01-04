
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JsonClasses : MonoBehaviour
{
    //    public static string[] BountyTypes = { "QR", "DexiCash_Common","DEXI", "DXG",
    //                                           "BTC", "ETH", "SOL" , "DOT", "TRX", "MATIC", "LINK", "CRO" , "ATOM",
    //                                           "CreatorHub", "GameVault", "BakerySwapNFT", "SOLNFT", "EnjinNFT", "OpenSeaNFT", "ElrondNFT",
    //                                            "AVAX","VET","ONE","FTM","DexiDragons","DexiKnights","BSL","Legendary","Epic","Rare","Uncommon","Common","BNB"
    //                                         };



    //public static int GetBountyIndex(string bounty)
    //    {
    //        for (int i = 0; i<BountyTypes.Length;i++)
    //        {
    //            if (BountyTypes[i].Equals(bounty))
    //            {
    //                return i;
    //            }
    //        }
    //        return 0;
    //    }

}








[Serializable]
public class Data
{
    public int id;
    public string email;
    public string created_at;
    public string updated_at;
    public string location_type;
}

//[Serializable]
//public class Meta
//{
//    public string token;
//}

[Serializable]
public class Root
{
    public string message;
    public Data data;
    public string token;
 
 

}
[Serializable]
public class User
{
    public int id;
    public string email;
    public string created_at;
    public string updated_at;
}





/// <summary>
/// 
/// </summary>
 [Serializable]
public class Datum
{
    public int id;
    public double lat;
    public double lng;
    public int user_id;
    public string name;
    public string created_at;
    public string updated_at;
    public string radius;
    public string location_type;
}
[Serializable]
public class LocationRoot
{
    public bool success;
    public List<Datum> data;
}

/// <summary>
/// place location json
/// </summary>
//public class PlaceLoc
//{
//    public int id ;
//    public double lat ;
//    public double lng ;
//    public object @string ;
//    public int user_id ;
//    public string name ;
//    public string created_at ;
//    public string updated_at ;
//    public string radius ;
//}

//public class PlaceLocRoot
//{
//    public bool success ;
//    public Data data ;
//}
//public class Datum
//{
//    public int id ;
//    public double lat ;
//    public double lng ;
//    public object @string ;
//    public int user_id ;
//    public string name ;
//    public DateTime created_at ;
//    public DateTime updated_at ;
//    public string radius ;
//}

//public class Root
//{
//    public bool success ;
//    public List<Datum> data ;
//}



//[Serializable]
//public class LocalLocstionList
//{
//    public List<LocalLocation> locations;
//}
//[Serializable]
//public class CryptoStats
//{
//    public int Ethereum;
//    public int Solana;
//    public int Redcube;
//    public int Bitcoin;
//    public int Dxg;
//    public int Polka;
//    public int BTC;
//    public int SOL;
//    public int ETH;
//    public int DXG;
//    public int DOT;
//    public int MATIC;
//    public int LINK;
//    public int ATOM;
//    public int DEXI;
//    public int AVAX;
//    public int VET;
//    public int ONE;
//    public int FTM;
//    public int TRX;
//    public int CRO;
//}

///// <summary>
//[Serializable]
//public class ConsumedCryptoBounties
//{
//    public int ATOM;
//    public int AVAX;
//    public int BNB;
//    public int BTC;
//    public int CRO;
//    public int DOT;
//    public int ETH;
//    public int FTM;
//    public int MATIC;
//    public int ONE;
//    public int SOL;
//    public int TRX;
//    public int VET;
//}
//[Serializable]
//public class RedeemedCryptoBounties
//{
//    public int ATOM;
//    public int AVAX;
//    public int BNB;
//    public int BTC;
//    public int CRO;
//    public int DOT;
//    public int ETH;
//    public int FTM;
//    public int MATIC;
//    public int ONE;
//    public int SOL;
//    public int TRX;
//    public int VET;
//}
//[Serializable]
//public class CryptoStatRoot
//{
//    public bool success;
//    public ConsumedCryptoBounties consumed_Crypto_bounties;
//    public RedeemedCryptoBounties redeemed_Crypto_bounties;
//}
//[Serializable]
//public class ConsumedDEXIBounties
//{
//    public int Legendary;
//    public int Epic;
//    public int Rare;
//    public int Uncommon;
//    public int Common;
//}
//[Serializable]
//public class RedeemedDEXIBounties
//{
//    public int Legendary;
//    public int Epic;
//    public int Rare;
//    public int Uncommon;
//    public int Common;
//}
//[Serializable]
//public class DEXI_StatsRoot
//{
//    public bool success;
//    public ConsumedDEXIBounties consumed_DEXI_bounties;
//    public RedeemedDEXIBounties redeemed_DEXI_bounties;
//}
///// </summary>
//[Serializable]
//public class PartnerStats
//{
//    public int BSL;
//}

//[Serializable]
//public class NFTStats
//{
//    public int DEXINFT;
//    public int BakerySwapNFT;
//    public int SOLNFT;
//    public int EnjinNFT;
//    public int DXGNFT;
//    public int OpenSeaNFT;
//    public int ElrondNFT;
//}






















//////////////////////////////////
//[Serializable]
//public class Link
//{
//    public int id;
//    public string name;
//    public string link;
//}
//[Serializable]
//public class LinksRoot
//{
//    public List<Link> links;
//}

//[Serializable]
//public class UserData
//{
//    public double latitude;
//    public double longitude;
//    public User user;
//}
//[Serializable]
//public class LocationUserRoot
//{
//    public List<UserData> user_locations;
//}
///////////////////////////////////////
/////DexiHunter Data
/////
////[Serializable]
////public class MapData
////{
////    public int id;
////    public double lng;
////    public double lat;
////    public DateTime created_at;
////    public DateTime updated_at;
////    public bool visited;
////    public string location_type;
////}
////[Serializable]
////public class MapRoot
////{
//// public bool success;
//// public List<MapData> data;
////}






//[Serializable]
//public class BountyLocationsData
//{
//    public List<BountyLocations> locations;
//}
//[Serializable]
//public class BountyLocations
//{
//    public int id;
//    public double lat;
//    public double lng;
//    public string location_type;
//    public int updated_at;
//}

//[Serializable]
//public class DistanceData
//{
//    public bool success;
//    public string data;
//}
//[Serializable]
//public class SearchedUserResult
//{
//    public User user;
//}

//[Serializable]
//public class PendingRequests
//{
//    public List<User> users;
//}

//[Serializable]
//public class FriendsList
//{
//    public List<User> users;
//}

//[Serializable]
//public class PostLoginMsg
//{
//    public bool sucess;
//    public string message;
//}

//[Serializable]
//public class Date
//{
//    public int dexiCash;
//    public int QR;
//    public int Crypto;
//    public int NFTs;
//}
//[Serializable]
//public class ConsumedLocationsRoot
//{
//    public bool success;
//    public string msg;
//    public Date date;
//}
//[Serializable]
//public class TopUser
//{
//    public int id;
//    public string first_name;
//    public string last_name;
//    public string email;
//    public string prfile_image_url;
//    public string username;
//    public int bounty_count;
//    public int week_steps_count;
//    public int month_steps_count;
//    public string notification_id;
//}
//[Serializable]
//public class TopHunters
//{
//    public List<TopUser> users;
//}
//[Serializable]
//public class LastTransectionsLocation
//{
//    public int id;
//    public string location_type;
//    public string updated_at;
//    //public string updated_at;

//}
//[Serializable]
//public class LastTransectionsRoot
//{
//    public List<LastTransectionsLocation> locations;
//}

//[Serializable]
//public class HomeStats
//{
//    public int monthly_bounty_count;
//    public int life_time_bounty_count;
//    public int weekly_steps_count;
//    public int monthly_steps_count;
//}

//[Serializable]
//public class Dexigas
//{
//    public double usd;
//}
//[Serializable]
//public class DXGPrice
//{
//    public Dexigas dexigas;
//}

//[Serializable]
//public class CryptoBountiesavailable
//{
//    public int id;
//    public double lat;
//    public double lng;
//    public string location_type;
//    public int updated_at;
//    public string old_wallet_address;
//}


//[Serializable]
//public class BountiesToRetrieve
//{
//    public List<CryptoBountiesavailable> locations;
//}

//[Serializable]
//public class DXGCOST
//{
//    public Sprite location_type;
//    public double dollarValue;
//}

//public class GameAssetsStats
//{
//    public int Dragons;
//    public int Knights;
//}

//[Serializable]
//public class UsernameStatus
//{
//    public bool username_exists;
//    public string msg;
//    public string data;
//}
//[Serializable]
public class StepsRoot
{
    public bool success;
    public string msg;
    public int data;
}
//[Serializable]
//public class NumberOfCollectedBounties
//{
//    public bool success;
//    public int data;
//}

//[Serializable]
//public class ImageRoot
//{
//    public User user;
//}

//[Serializable]
//public class UnFriendResponceRoot
//{
//    public bool success;
//    public string msg;
//}

//// Chat Class
//[Serializable]
//public class Datum
//{
//    public int id;
//    public int sender_id;
//    public int receiver_id;
//    public string message;
//    public DateTime created_at;
//    public DateTime updated_at;
//}
//// Chat Class
//[Serializable]
//public class RetrieveRoot
//{
//    public bool success;
//    public List<Datum> data;
//}

//[Serializable]
//public class GetUserIDRoot
//{
//    public bool user_exists;
//    public int data;
//}
//[Serializable]
//public class GetTokenRoot
//{
//    public bool success;
//    public string data;
//}
//[Serializable]
//public class ConsumedDEXINFTsBounties
//{
//    public int CreatorHub;
//    public int GameVault;
//}
//[Serializable]
//public class RedeemedDEXINFTsBounties
//{
//    public int CreatorHub;
//    public int GameVault;
//}
//[Serializable]
//public class NFT_StatsRoot
//{
//    public bool success;
//    public ConsumedDEXINFTsBounties consumed_DEXI_NFTs_bounties;
//    public RedeemedDEXINFTsBounties redeemed_DEXI_NFTs_bounties;
//}

//// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
//[Serializable]
//public class ATOM
//{
//    public int id;
//    public int available_bounty_count;
//    public object address;
//}
//[Serializable]
//public class AVAX
//{
//    public int id;
//    public int available_bounty_count;
//    public object address;
//}
//[Serializable]
//public class BNB
//{
//    public int id;
//    public int available_bounty_count;
//    public object address;
//}
//[Serializable]
//public class BTC
//{
//    public int id;
//    public int available_bounty_count;
//    public object address;
//}
//[Serializable]
//public class CRO
//{
//    public int id;
//    public int available_bounty_count;
//    public object address;
//}
//[Serializable]
//public class Data
//{
//    public ATOM ATOM;
//    public AVAX AVAX;
//    public BNB BNB;
//    public BTC BTC;
//    public CRO CRO;
//    public DOT DOT;
//    public ETH ETH;
//    public FTM FTM;
//    public MATIC MATIC;
//    public ONE ONE;
//    public SOL SOL;
//    public TRX TRX;
//    public VET VET;
//}
//[Serializable]
//public class DOT
//{
//    public int id;
//    public int available_bounty_count;
//    public object address;
//}
//[Serializable]
//public class ETH
//{
//    public int id;
//    public int available_bounty_count;
//    public object address;
//}
//[Serializable]
//public class FTM
//{
//    public int id;
//    public int available_bounty_count;
//    public object address;
//}
//[Serializable]
//public class MATIC
//{
//    public int id;
//    public int available_bounty_count;
//    public object address;
//}
//[Serializable]
//public class ONE
//{
//    public int id;
//    public int available_bounty_count;
//    public object address;
//}
//[Serializable]
//public class AvailabeRedeemableBountyRoot
//{
//    public bool success;
//    public Data data;
//}
//[Serializable]
//public class SOL
//{
//    public int id;
//    public int available_bounty_count;
//    public object address;
//}
//[Serializable]
//public class TRX
//{
//    public int id;
//    public int available_bounty_count;
//    public object address;
//}
//[Serializable]
//public class VET
//{
//    public int id;
//    public int available_bounty_count;
//    public object address;
//}



////
//[Serializable]
//public class BountyPackageRoot
//{
//    public bool success;
//    public int count;
//    public string package;
//}
//[Serializable]
//public class PackageResponceRoot
//{
//    public bool success;
//    public string message;
//}
//[Serializable]
//public class DEXI_Bounties
//{
//    public Button[] DEXI_Common;
//    public Button[] DEXI_UnCommon;
//    public Button[] DEXI_Rare;
//    public Button[] DEXI_EPIC;
//    public Button[] DEXI_Legendary;
//}

//[Serializable]
//public class ConsumedGameAssetsBounties
//{
//    public int DexiCarnival;
//    public int DexiDragons;
//    public int DexiKnights;
//    public int DexiRacer;
//    public int LotD;
//}
//[Serializable]
//public class RedeemedGameAssetsBounties
//{
//    public int DexiCarnival;
//    public int DexiDragons;
//    public int DexiKnights;
//    public int DexiRacer;
//    public int LotD;
//}
//[Serializable]
//public class GameAssetsRoot
//{
//    public bool success;
//    public ConsumedGameAssetsBounties consumed_Game_Assets_bounties;
//    public RedeemedGameAssetsBounties redeemed_Game_Assets_bounties;
//}

//namespace DEXI_Data
//{
//    [Serializable]
//    public class Common
//    {
//        public int id;
//        public int available_bounty_count;
//        public object address;
//    }
//    [Serializable]
//    public class Data
//    {
//        public Legendary Legendary;
//        public Epic Epic;
//        public Rare Rare;
//        public Uncommon Uncommon;
//        public Common Common;
//    }
//    [Serializable]
//    public class Epic
//    {
//        public int id;
//        public int available_bounty_count;
//        public object address;
//    }
//    [Serializable]
//    public class Legendary
//    {
//        public int id;
//        public int available_bounty_count;
//        public object address;
//    }
//    [Serializable]
//    public class Rare
//    {
//        public int id;
//        public int available_bounty_count;
//        public object address;
//    }
//    [Serializable]
//    public class Root
//    {
//        public bool success;
//        public Data data;
//    }
//    [Serializable]
//    public class Uncommon
//    {
//        public int id;
//        public int available_bounty_count;
//        public object address;
//    }
//}
//namespace DEXI_NFTs_RedeemableData
//{
//    [Serializable]
//    public class CreatorHub
//    {
//        public int id;
//        public int available_bounty_count;
//        public object address;
//    }
//    [Serializable]
//    public class Data
//    {
//        public CreatorHub CreatorHub;
//        public GameVault GameVault;
//    }
//    [Serializable]
//    public class GameVault
//    {
//        public int id;
//        public int available_bounty_count;
//        public object address;
//    }
//    [Serializable]
//    public class Root
//    {
//        public bool success;
//        public Data data;
//    }
//}
//[Serializable]
//public class WalletAddressRoot
//{
//    public string wallets;
//    public bool wallets_available;
//}
//[Serializable]
//public class WalletDetails
//{
//    public string id;
//    public string platform;
//    public string address;
//    public string type;
//}
//[Serializable]
//public class Balance
//{
//    public string balance;
//}
//[Serializable]
//public class RR_And_DexicashRoot
//{
//    public Balance Balance;
//    public string BankId;
//    public int Status;
//    public string UserId;
//}


