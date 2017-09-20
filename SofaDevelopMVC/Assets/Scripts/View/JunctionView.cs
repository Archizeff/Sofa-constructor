using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunctionView : ApplicationElement {

	public int ID;

	public Vector3 Forward { get { return transform.forward; }}
	public float WorldDirection { get { return transform.rotation.eulerAngles.y; }}
	public float LocalDirection { get { return transform.localRotation.eulerAngles.y; }}
	public Vector3 WorldPosition {get { return transform.position; }}
}
