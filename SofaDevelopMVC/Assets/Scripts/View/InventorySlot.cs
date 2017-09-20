using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

	public GameObject module;
	public Image img;
	private Color32 defaultColor = new Color32 (255, 255, 255, 100);
	private Color32 selectColor= new Color32 (255, 0, 0, 100);


	void Awake()
	{
		img = GetComponent<Image>();
	}		

	public void ToSelectState()
	{
		img.color = selectColor;
	}

	public void ToDefaultState()
	{
		img.color = defaultColor;
	}
}