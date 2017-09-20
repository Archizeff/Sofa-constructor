using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SofaModuleView : ApplicationElement {

	public SofaModuleModel model;
	public SofaModulePrewiewModel pmodel;
	public JunctionView [] junctions;

	void Awake () {
		junctions = transform.GetComponentsInChildren<JunctionView> ();
	}

	public void ControlledUpdate(){
		transform.rotation = Quaternion.Euler (pmodel.GetRotation());
		transform.position = pmodel.GetPosition ();
	}

	public void ToParent(){
		transform.position = transform.parent.position;
	}
}
