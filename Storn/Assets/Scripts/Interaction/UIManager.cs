using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

	public static UIManager m_Instance;

	public TMP_Text captionsText;

	public GameObject handCursor;
	public GameObject backImage;

	public Image interactionImage;

	public GameObject inventoryImage;
	public TMP_Text[] inventoryItens;
	public TMP_Text infoText;

	

	private void Awake()
	{
		m_Instance = this;
		DontDestroyOnLoad(gameObject);
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.I))
		{
			ShowInventory();
		}
    }

	public void ShowInventory()
    {
		inventoryImage.SetActive(!inventoryImage.activeInHierarchy);
	}

	public void SetCaptions(string text)
	{
		captionsText.text = text;
	}

	public void SetHandCursor(bool state)
	{
		handCursor.SetActive(state);
	}

	public void SetBackImage(bool state)
	{
		backImage.SetActive(state);

		if (!state)
		{
			interactionImage.enabled = false;
		}
	}

	public void SetImage(Sprite sprite)
	{
		interactionImage.sprite = sprite;
		interactionImage.enabled = true;
	}

	public void SetItems(Item item, int index)
	{
		inventoryItens[index].text = item.collectMessage;
		infoText.text = item.collectMessage;
		StartCoroutine(FadingText());
	}

	IEnumerator FadingText()
	{
		Color newColor = infoText.color;
		while (newColor.a < 1)
		{
			newColor.a += Time.deltaTime;
			infoText.color = newColor;
			yield return null;
		}

		yield return new WaitForSeconds(2f);

		while (newColor.a > 0)
		{
			newColor.a -= Time.deltaTime;
			infoText.color = newColor;
			yield return null;
		}
	}
}
