using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryView : ApplicationElement {

	private InventorySlot[] slots;
	private int currentSlot = 0;

	void Start()
	{
		slots = GetComponentsInChildren<InventorySlot> ();
		slots [currentSlot].ToSelectState();
		app.Notify (Notification.Inventory_SlotInitialize, this, new object[] {slots[currentSlot].module.GetComponent<SofaModuleView>()});
	}

	void SelectSlot(int id)
	{
		slots [currentSlot].ToDefaultState();

		if (id < 0)
			currentSlot = slots.Length - 1;
		else if (id >= slots.Length)
			currentSlot = 0;
		else
			currentSlot = id;

		slots [currentSlot].ToSelectState();

		app.Notify (Notification.Inventory_SlotChanged, this, new object[] {slots[currentSlot].module.GetComponent<SofaModuleView>()});
	}

	public void NextSlot(bool inverse = false)
	{
		if (inverse) {
			SelectSlot (currentSlot - 1);
		} else {
			SelectSlot (currentSlot + 1);
		}
	}
}
