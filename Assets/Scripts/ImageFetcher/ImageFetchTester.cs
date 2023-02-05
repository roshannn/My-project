using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFetchTester : MonoBehaviour
{
	[SerializeField]private string url;
	[SerializeField] private Image image;
	private async void Start()
	{
		Texture2D tex = await ImageFetcher.GetTexture(url);
		image.sprite = ImageFetcher.ConvertTexture2DToSprite(tex);
	}

	private void Update()
	{
	
	}
}
