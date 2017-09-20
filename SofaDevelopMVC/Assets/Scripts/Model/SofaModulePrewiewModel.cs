using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SofaModulePrewiewModel : SofaModuleModel {

	public SofaModuleModel connect;
	public JunctionView align;
	public Vector3? position;
	private int side = 0;

	public SofaModulePrewiewModel (SofaModuleView view = null) : base (view) {		
	}

	public void NextJunction() {
		if (++side >= junctions.Length) side = 0;
	}

	public Vector3 GetRotation(){

		JunctionView junction = junctions.First (j => j.ID == side);
		Vector3 rotation = view.transform.eulerAngles;
		rotation.y = -junction.LocalDirection;

		return rotation;
	}

	public Vector3 GetPosition(){

		if (connect != null) {
			JunctionView junction = junctions.First (j => j.Forward == -align.Forward);
			return view.transform.position + align.WorldPosition - junction.WorldPosition;
		}

		if (position != null) {
			return position.Value;
		}
		return view.transform.parent.position;
	}

	public SofaModuleModel Duplicate (){
		GameObject copyObj = GameObject.Instantiate (view.gameObject, view.transform.position, view.transform.rotation);
		copyObj.layer = LayerMask.NameToLayer ("SofaModule");

		SofaModuleView copyView = copyObj.GetComponent<SofaModuleView>();
		copyView.model = new SofaModuleModel (copyView);

		return copyView.model;
	}
}
