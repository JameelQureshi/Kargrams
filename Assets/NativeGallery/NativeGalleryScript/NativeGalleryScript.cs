using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NativeGallery;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;
using UnityEngine.SceneManagement;

public class NativeGalleryScript : MonoBehaviour
{

	public static NativeGalleryScript instance;
	public GameObject showimgpanel;
	public GameObject selectImgpanel;
	private string Imgpath;
	public Texture2D texture;
	private Sprite mySprite;
	private SpriteRenderer sr;
	public Image GetImage;

	private void Awake()
	{
		if (instance != null)
		{
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			instance = this;
		}
	}
	public void PickImage(int maxSize)
	{
		Permission permission = NativeGallery.GetImageFromGallery((path) =>
			{
				Imgpath = path;
				Debug.Log("Image path: " + path);
				if (path != null)
				{
				// Create Texture from selected image
				texture = LoadImageAtPath(path, maxSize);
					if (texture == null)
					{
						Debug.Log("Couldn't load texture from " + path);
						return;
					}

					sr = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
					sr.color = new Color(0.9f, 0.9f, 0.9f, 1.0f);
					transform.position = new Vector3(2f, 2f, 0.0f);
					mySprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
			     	GetImage.sprite = mySprite;
					GetImage.preserveAspect = true;
					GetImage.transform.rotation = Quaternion.Euler(0, 0, 0);

					showimgpanel.SetActive(true);
					selectImgpanel.SetActive(false);
				}
			});
		Debug.Log("Permission result: " + permission);
	}
	public void TakePicture()
	{
		NativeCamera.Permission permission = NativeCamera.TakePicture((path) =>
		{
			Imgpath = path;
			Debug.Log("Image path: " + path);
			if (path != null)
			{
				// Create Texture from selected image
				texture = LoadImageAtPath(path);
				if (texture == null)
				{
					Debug.Log("Couldn't load texture from " + path);
					return;
				}

				sr = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
				sr.color = new Color(0.9f, 0.9f, 0.9f, 1.0f);
				transform.position = new Vector3(2f, 2f, 0.0f);
				mySprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
				GetImage.sprite = mySprite;
				GetImage.preserveAspect = true;
				GetImage.transform.rotation = Quaternion.Euler(0, 0, 0);

				showimgpanel.SetActive(true);
				selectImgpanel.SetActive(false);
			}
		});
		Debug.Log("Permission result: " + permission);
	}

	public void CancelBtn()
	{
		SceneManager.LoadScene(0);
	}

	public void UploadImg()
	{
		StartCoroutine(UploadimageUsingFormData());
	}

	IEnumerator CreateImgRequestUsingMultipartFormData()
	{
		List<IMultipartFormSection> formData = new List<IMultipartFormSection>();

		byte[] img = texture.GetRawTextureData();
		Debug.Log(img);

		formData.Add(new MultipartFormDataSection("lat", "47.1"));
		formData.Add(new MultipartFormDataSection("lng", "36.2"));
		formData.Add(new MultipartFormDataSection("radius", "60"));
		formData.Add(new MultipartFormDataSection("name", "Saba"));
		formData.Add(new MultipartFormDataSection("location_type", "cycle"));
		formData.Add(new MultipartFormFileSection("Image", img));


		using (UnityWebRequest www = UnityWebRequest.Post("http://ec2-3-93-231-128.compute-1.amazonaws.com/api/v1/locations", formData))
		{
			www.SetRequestHeader("Authorization", "Bearer " + "eyJhbGciOiJIUzI1NiJ9.eyJzdWIiOiIxMiIsInNjcCI6InVzZXIiLCJhdWQiOm51bGwsImlhdCI6MTY3NTY5NDY3OCwiZXhwIjoxNjc2OTkwNjc4LCJqdGkiOiI3ODQ3MzFlYi04Nzk2LTQ5M2ItYmRhZi02ZjQwMjhjNmY5MDgifQ.jhWmk8eq-YLIK8nrTc0v2f2tAC-QPPjsSOoFzPUVcmk");
			yield return www.SendWebRequest();

			if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
			{
				Debug.Log(www.error);
			}

			else
			{
				Debug.Log("Img upload complete!");
				SceneManager.LoadScene(0);

			}
		}
	}
	//test
	IEnumerator UploadimageUsingFormData()
	{
		//texture = DuplicateTexture(texture);
		byte[] img = texture.EncodeToJPG();

		WWWForm formrequest = new WWWForm();
		Debug.Log("image "+img.Length);
		formrequest.AddField("lat", "47.1");
		formrequest.AddField("lng", "36.2");
		formrequest.AddField("radius", "60");
		formrequest.AddField("name", "Saba");
		formrequest.AddField("location_type", "cycle");
		Debug.Log("Before getting Img");
		formrequest.AddBinaryData("image", img);
		using (UnityWebRequest www = UnityWebRequest.Post("http://ec2-3-93-231-128.compute-1.amazonaws.com/api/v1/locations", formrequest))
		{
			www.SetRequestHeader("Authorization", "Bearer " + "eyJhbGciOiJIUzI1NiJ9.eyJzdWIiOiIxMiIsInNjcCI6InVzZXIiLCJhdWQiOm51bGwsImlhdCI6MTY3NTY5NDY3OCwiZXhwIjoxNjc2OTkwNjc4LCJqdGkiOiI3ODQ3MzFlYi04Nzk2LTQ5M2ItYmRhZi02ZjQwMjhjNmY5MDgifQ.jhWmk8eq-YLIK8nrTc0v2f2tAC-QPPjsSOoFzPUVcmk");
			yield return www.SendWebRequest();

			if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
			{
				Debug.Log(www.error);
			}

			else
			{
				Debug.Log("Img upload complete!");
				SceneManager.LoadScene(0);

			}
		}
	}

	




}
