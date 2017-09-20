using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : ApplicationElement {


	private enum TargetState {SofaModuleLock, BaseLock, Empty}
	//private TargetState targetState = TargetState.Empty;

	void Update () {
		float scroll = Input.GetAxis ("Mouse ScrollWheel");
		if (Input.GetKeyUp ("q"))
			app.Notify (Notification.Input_NewSide, this);

		if (scroll > 0)
			app.view.inventory.NextSlot (true);
		if (scroll < 0)
			app.view.inventory.NextSlot (false);

		if (Input.GetMouseButtonUp (0)) {
			app.Notify (Notification.Input_CreateSofaModule, this);
		}
	}


	public void OnNotification(Notification type, MonoBehaviour sender, params object[] data){
	}
}
