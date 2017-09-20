using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetControll: ApplicationElement {
	
	private Transform cameraTransform;
	private LayerMask mask;
	private Collider targetColider;
	private Vector3 targetNormal;
	private Vector3 lastBasePosition;

	void Awake () {
		mask = LayerMask.GetMask ("SofaModule", "Base");
		cameraTransform = GetComponentInChildren<Camera> ().GetComponent<Transform> ();
	}

	void FixedUpdate () {

		Vector3 forward = cameraTransform.TransformDirection (Vector3.forward);
		RaycastHit hit;

		if (Physics.Raycast (cameraTransform.position, forward, out hit, 7f, mask)) {

			if (hit.collider.tag == "Base" && lastBasePosition != hit.point) {
				targetColider = hit.collider;
				lastBasePosition = hit.point;

				app.Notify (Notification.Target_NewBasePosition, this, new object[] {hit.point});

				return;
			}

			if (hit.normal.y != 0) return;

			if (targetColider != hit.collider) {
				targetColider = hit.collider;
				targetNormal = hit.normal;

				app.Notify (Notification.Target_Capture, this, new object[] {hit.collider.GetComponent<SofaModuleView>().model, hit.normal});

				return;
			}

			if (targetNormal != hit.normal) {
				targetNormal = hit.normal;

				app.Notify (Notification.Target_NewNormal, this, new object[] {hit.normal});

				return;
			}

		} else if (targetColider != null){

			targetColider = null;

			app.Notify (Notification.Target_Lost, this);
			return;
		}
	}
}
