using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SofaModuleModel {

	public SofaModuleView view;

	protected JunctionView[] junctions {get { return view.junctions; } }

	public SofaModuleModel (SofaModuleView view) {
		this.view = view;
	}		

	public JunctionView GetNearJunction (Vector3 direction) {
		return junctions.First (j => j.Forward == direction);
	}
}
