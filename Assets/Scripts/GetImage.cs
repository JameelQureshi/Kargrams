using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class GetImage : MonoBehaviour
{

	public static GetImage instance;

	public GameObject ImagePanel;
	private Sprite DownloadedImage;
	public Sprite Defualt_Image;
	public Image SelectedImage;
	public Image ProfileImage;
	public Image StatsProfileImage;
	//public Image SettingUserImage;
	//public Image LinksUserImage;
	public Texture2D CroppedImage;
	private Texture2D FinalImage;

	[Header("Edit SCREEN")]
	public Image EditPanelProfileImage;
	public InputField Edited_FirstName;
	public InputField Edited_LastName;
	public InputField Username;
	public InputField Password;
	public InputField ConfirmPassword;

	[Header("CROP SCREEN")]
	public RawImage croppedImageHolder;
	public Text croppedImageSize;
	public Toggle ovalSelectionInput, autoZoomInput;
	public InputField minAspectRatioInput, maxAspectRatioInput;
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
		EditPanelData();
		ImagePanel.SetActive(false);

		//Debug.Log("Before url " + AuthManager.prfile_image_url);
		
	}
	
	//public Text Imageresponce;

	private void Start()
	{
		LoadingManager.instance.loading.SetActive(true);
		StartCoroutine(GetImageURL());
		//Imageresponce.text = "";
	}
	IEnumerator GetImageURL()
	{

		string requestName = "/api/v1/users/get_profile_image";
		using (UnityWebRequest www = UnityWebRequest.Get(AuthManager.BASE_URL + requestName))
		{
			www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
			yield return www.SendWebRequest();

			if (www.isNetworkError || www.isHttpError)
			{
				ConsoleManager.instance.ShowMessage("Network Error");
				Debug.Log(www.error);
				LoadingManager.instance.loading.SetActive(false);
			}
			else
			{
//				ImageRoot ImageLink = JsonUtility.FromJson<ImageRoot>(www.downloadHandler.text);
				//if (ImageLink.user.prfile_image_url=="")
				//{
				//	ConsoleManager.instance.ShowMessage("Image not found");
				//	LoadingManager.instance.loading.SetActive(false);
				//}
				//else
				//{
				//	LoadingManager.instance.loading.SetActive(true);
				//	StartCoroutine(GetThumbnail(ImageLink.user.prfile_image_url));
				//}
				// User is Created
			}
		}
	}
	public void PickImage()
	{
        //byte[] imageBytes = testImage.EncodeToJPG();
        //StartCoroutine(Upload(imageBytes));
        PickImage(512);
	}

	[System.Obsolete]
	private void PickImage(int maxSize)
	{
		NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
		{
			Debug.Log("Image path: " + path);
			if (path != null)
			{
				// Create Texture from selected image
				Texture2D texture = NativeGallery.LoadImageAtPath(path, maxSize);
				if (texture == null)
				{
					Debug.Log("Couldn't load texture from " + path);
					return;
				}
				//texture
				ImagePanel.SetActive(true);
				SelectedImage.sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
				//ProfileImage.sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
				SelectedImage.preserveAspect=true;
				//Invoke(nameof(Crop), 1);
				//Crop(texture);
				StartCoroutine(CropCoroutine(texture));
			}
		});

		Debug.Log("Permission result: " + permission);
	}
	IEnumerator CropCoroutine(Texture2D CropTexture)
	{
		yield return new WaitForSeconds(1);
		Crop(CropTexture);
	}
	/*IEnumerator Upload(byte[] imageBytes)
	{
		WWWForm form = new WWWForm();
		form.AddBinaryData("profile_image", imageBytes, "profile.png");
		form.AddField("first_name", AuthManager.First_Name);
		form.AddField("last_name", AuthManager.Last_Name);
		//form.AddField("userName", AuthManager.Last_Name);
		//form.AddField("password", );

		string requestName = "api/v1/users";
		using (UnityWebRequest www = UnityWebRequest.Post(AuthManager.BASE_URL + requestName, form))
		{
			www.SetRequestHeader("Authorization", "Bearer " + AuthManager.Token);
			yield return www.SendWebRequest();

			if (www.isNetworkError || www.isHttpError)
			{
				ConsoleManager.instance.ShowMessage("Image not uploaded");
				LoadingManager.instance.loading.SetActive(false);
				Debug.Log(www.error);
			}
			else
			{
				Debug.Log("image uploaded");
				//Root ReturnedImageUrl = JsonUtility.FromJson<Root>(www.downloadHandler.text);
				
				//Imageresponce.text = "Image Uploaded";
			}
		}
	}*/
	IEnumerator GetThumbnail(string uri)
	{
		Debug.Log(uri);
		UnityWebRequest www = UnityWebRequestTexture.GetTexture(uri);
		www.SetRequestHeader("Content-type", "application/json");
		//www.SetRequestHeader("Authorization", "Bearer " + AuthManager.Token);
		yield return www.SendWebRequest();

		if (www.isNetworkError || www.isHttpError)
		{
			LoadingManager.instance.loading.SetActive(false);
			Debug.Log(www.responseCode);
		}
		else
		{
			Texture2D texture = DownloadHandlerTexture.GetContent(www);
			Debug.Log("Image Downloaded!");
			Sprite thumbnail = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f));
			DownloadedImage = thumbnail;
			EditPanelProfileImage.sprite = thumbnail;
			ProfileImage.sprite = thumbnail;
			StatsProfileImage.sprite = thumbnail;
			LoadingManager.instance.loading.SetActive(false);
		}
	}

	Texture2D duplicateTexture(Texture2D source)
	{
		RenderTexture renderTex = RenderTexture.GetTemporary(
					source.width,
					source.height,
					0,
					RenderTextureFormat.Default,
					RenderTextureReadWrite.Linear);

		Graphics.Blit(source, renderTex);
		RenderTexture previous = RenderTexture.active;
		RenderTexture.active = renderTex;
		Texture2D readableText = new Texture2D(source.width, source.height);
		readableText.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
		readableText.Apply();
		RenderTexture.active = previous;
		RenderTexture.ReleaseTemporary(renderTex);
		return readableText;
	}

	public void Crop(Texture2D SelectedTexture)
	{
		// If image cropper is already open, do nothing
		if (ImageCropper.Instance.IsOpen)
			return;

		StartCoroutine(TakeScreenshotAndCrop(SelectedTexture));
	}

	private IEnumerator TakeScreenshotAndCrop(Texture2D SelectedTexture)
	{
		yield return new WaitForEndOfFrame();

		bool ovalSelection = ovalSelectionInput.isOn = false;
		bool autoZoom = autoZoomInput.isOn;

		
		float minAspectRatio, maxAspectRatio;
		if (!float.TryParse(minAspectRatioInput.text, out minAspectRatio))
			minAspectRatio = 0f;
		if (!float.TryParse(maxAspectRatioInput.text, out maxAspectRatio))
			maxAspectRatio = 0f;
		ImageCropper.Instance.Show(SelectedTexture, (bool result, Texture originalImage, Texture2D croppedImage) =>
		{
			if (result)
			{
				croppedImageHolder.enabled = true;
				croppedImageHolder.texture = croppedImage;

				Vector2 size = croppedImageHolder.rectTransform.sizeDelta;
				if (croppedImage.height <= croppedImage.width)
					size = new Vector2(400f, 400f * (croppedImage.height / (float)croppedImage.width));
				else
					size = new Vector2(400f * (croppedImage.width / (float)croppedImage.height), 400f);
				croppedImageHolder.rectTransform.sizeDelta = size;

				Texture2D dest = new Texture2D(croppedImageHolder.texture.width, croppedImageHolder.texture.height, TextureFormat.RGBA32, false);
				dest.Apply(false);
				Graphics.CopyTexture(croppedImageHolder.texture, dest);

				FinalImage = dest;
				croppedImageSize.enabled = true;
			}
			else
			{
				croppedImageHolder.enabled = false;
				croppedImageSize.enabled = false;
			}
		},


		settings: new ImageCropper.Settings()
		{
			ovalSelection = ovalSelection,
			autoZoomEnabled = autoZoom,
			imageBackground = Color.clear, // transparent background
			selectionMinAspectRatio = minAspectRatio,
			selectionMaxAspectRatio = maxAspectRatio

		},
		croppedImageResizePolicy: (ref int width, ref int height) =>
		{
				//uncomment lines below to save cropped image at half resolution
				width /= 2;
			height /= 2;
		}
		);
		
		
	}
	private void Update()
	{
		if (ImageCropper.Instance.counter == 1)
		{
			ImagePanel.SetActive(false);
			FinalImage = duplicateTexture(FinalImage);
			EditPanelProfileImage.sprite = Sprite.Create(FinalImage, new Rect(0.0f, 0.0f, FinalImage.width, FinalImage.height), new Vector2(0.5f, 0.5f), 100.0f);
			UpdateProfile();
		}
	}
    public void UpdateProfile()
	{
	//	LoadingManager.instance.loading.SetActive(true);
	//	if (ImageCropper.Instance.counter == 1)
	//	{
	//		//Imageresponce.text = "Readable = " + texture.isReadable;
	//		byte[] imageBytes = FinalImage.EncodeToPNG();
	//		StartCoroutine(Upload_data(imageBytes));
	//		ImageCropper.Instance.counter = 0;
 //       }
 //       //else
 //       //{
 //       //	StartCoroutine(Upload_Text_data());
 //       //}
 //   }
	//public IEnumerator Upload_data(byte[] imageBytes)
	//{
	//	WWWForm form = new WWWForm();
	//	form.AddBinaryData("profile_image", imageBytes, "profile.png");

	//	string requestName = "/api/v1/users/update_profile_image?";
	//	using (UnityWebRequest www = UnityWebRequest.Post(AuthManager.BASE_URL + requestName, form))
	//	{
	//		www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
	//		yield return www.SendWebRequest();

	//		if (www.isNetworkError || www.isHttpError)
	//		{
	//			ConsoleManager.instance.ShowMessage("Data not uploaded");
	//			LoadingManager.instance.loading.SetActive(false);
	//			Debug.Log(www.error);
	//		}
	//		else
	//		{
	//			ConsoleManager.instance.ShowMessage("Profile updated");
	//			Debug.Log("Data uploaded");
	//			Debug.Log("Returned Data : "+www.downloadHandler.text);
	//			//Root ReturnedUserData = JsonUtility.FromJson<Root>(www.downloadHandler.text);
	//			Debug.Log("returned "+ReturnedUserData.user.prfile_image_url);
	//			if (ReturnedUserData.user.prfile_image_url == "" || ReturnedUserData.user.prfile_image_url == null)
	//			{
	//				Debug.Log("DownloadedImage = Defualt_Image");
	//				SceneController.LoadScene(1);
	//			}
	//			else
	//			{
	//				Debug.Log(ReturnedUserData.user.prfile_image_url);
	//				StartCoroutine(AuthManager.GetThumbnail(ReturnedUserData.user.prfile_image_url));
	//			}
	//		}
	//	}
	}
	//public IEnumerator Upload_Text_data()
	//{
		//WWWForm form = new WWWForm();

		//form.AddField("first_name", Edited_FirstName.text);
		//form.AddField("last_name", Edited_LastName.text);
		//form.AddField("username", Username.text);
		////form.AddField("password", );
		//string requestName = "/api/v1/users";
	//using (UnityWebRequest www = UnityWebRequest.Post(AuthManager.BASE_URL + requestName, form))
 //       {
 //           www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
	//yield return www.SendWebRequest();

		//	if (www.isNetworkError || www.isHttpError)
		//	{
		//		ConsoleManager.instance.ShowMessage("Data not uploaded");
		//		LoadingManager.instance.loading.SetActive(false);
		//		Debug.Log(www.error);
		//	}
		//	else
		//	{
		//		ConsoleManager.instance.ShowMessage("Profile updated");
		//		Debug.Log("Data uploaded");
		//		Debug.Log(www.downloadHandler.text);

		//		Root ReturnedUserTextData = JsonUtility.FromJson<Root>(www.downloadHandler.text);
		//		Debug.Log("Returned Data : " + www.downloadHandler.text);
		//		Debug.Log("Text coroutine = " + ReturnedUserTextData.user.id);
		//		AuthManager.Name = ReturnedUserTextData.user.first_name.ToString() + " " + ReturnedUserTextData.user.last_name.ToString();
		//		AuthManager.First_Name = ReturnedUserTextData.user.first_name;
		//		AuthManager.Last_Name = ReturnedUserTextData.user.last_name;
		//		AuthManager.Username = ReturnedUserTextData.user.username;

				
		//		if (ReturnedUserTextData.user.prfile_image_url == "" || ReturnedUserTextData.user.prfile_image_url == null)
		//		{
		//			Debug.Log("DownloadedImage = Defualt_Image");
		//			SceneController.LoadScene(1);
		//		}
		//		else
		//		{
		//			Debug.Log(ReturnedUserTextData.user.prfile_image_url);
		//			StartCoroutine(AuthManager.GetThumbnail(ReturnedUserTextData.user.prfile_image_url));
		//		}

				
		//	}
//	}
//	}
private void EditPanelData()
{
	//	if (AuthManager.First_Name == "Default_Name" || AuthManager.First_Name.ToLower() == "defualt_name ")
	//	{
	//		Edited_FirstName.text = "";
	//	}
	//	else
	//	{
	//		Edited_FirstName.text = AuthManager.First_Name;
	//	}
	//	Edited_LastName.text = AuthManager.Last_Name;
	//	Username.text = AuthManager.Username;
	//	Password.text = "";
	//	ConfirmPassword.text = "";
	//}
	//public void DiscardEditing()
	//{
	//	ImageCropper.Instance.counter = 0;
	//	EditPanelData();
	//	ProfileManager.instance.Initialize_User_Info();
}
}
