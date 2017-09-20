using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewController : ApplicationElement {

	private SofaModulePrewiewModel preview;

	public void OnNotification(Notification type, MonoBehaviour sender, params object[] data){

		switch (type) {
		case Notification.Target_Capture:
			OnTargetCapture (data);
			break;

		case Notification.Target_NewNormal:
			OnNewNormal (data);
			break;

		case Notification.Target_NewBasePosition:
			OnNewBasePosition (data);
			break;

		case Notification.Target_Lost:
			OnTargetLost (data);
			break;

		case Notification.Inventory_SlotChanged:
			OnSlotChanged (data);
			break;

		case Notification.Input_NewSide:
			OnNewSide (data);
			break;

		case Notification.Input_CreateSofaModule:
			OnCreateSofaModule (data);
			break;

		case Notification.Inventory_SlotInitialize:
			OnSlotInitialize (data);
			break;
		}

		preview.view.ControlledUpdate ();
	}

	void OnTargetCapture(object [] data) {
		preview.connect = (SofaModuleModel) data [0];
		preview.align = preview.connect.GetNearJunction ((Vector3)data [1]);
		//Debug.Log ("TaregetCapture!");
	}

	void OnNewNormal(object [] data) {
		preview.align = preview.connect.GetNearJunction ((Vector3)data [0]);
		//Debug.Log ("NewNormal!");
	}

	void OnNewBasePosition(object [] data) {
		preview.position = (Vector3)data [0];
		preview.connect = null;
		preview.align = null;
		//Debug.Log ("BasePosition!");
	}

	void OnTargetLost(object [] data){
		preview.position = null;
		preview.connect = null;
		preview.align = null;
		//Debug.Log ("TargetLost");
	}

	void OnSlotChanged(object [] data){
		preview.view.ToParent ();
		preview.view = (SofaModuleView)data [0];
		preview.view.pmodel = preview;
	}

	void OnNewSide(object [] data){
		preview.NextJunction ();
	}

	void OnCreateSofaModule(object [] data){
		preview.Duplicate ();
	}

	void OnSlotInitialize(object [] data){
		preview = new SofaModulePrewiewModel ();
		app.model.previewModule = preview;
		SofaModuleView view = (SofaModuleView)data [0];;
		view.pmodel = preview;
		preview.view = view;
	}
}
