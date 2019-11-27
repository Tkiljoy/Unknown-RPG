using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeRoom : MonoBehaviour
{
	public GameObject VirtualCamera;
	public bool needText;
	public string placeName;
	public GameObject text;
	public Text placeText;

	public virtual void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player") && !other.isTrigger)
		{
			VirtualCamera.SetActive(true);
			if (needText)
			{
				StartCoroutine(placeNameCo());
			}
		}
	}

	private IEnumerator placeNameCo()
	{
		text.SetActive(true);
		placeText.text = placeName;
		yield return new WaitForSeconds(4f);
		text.SetActive(false);
	}

	public virtual void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player") && !other.isTrigger)
		{
			VirtualCamera.SetActive(false);
		}
	}

}