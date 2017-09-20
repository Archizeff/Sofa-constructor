using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationElement : MonoBehaviour {

	private Application application;

	public Application app { get { return application ?? Init(); } }

	private Application Init(){
		application = GameObject.FindObjectOfType<Application> ();
		return application;
	}
}

public sealed class Application : MonoBehaviour {

	public Model model;
	public Controller controller;
	public View view;

	public void Notify(Notification type, MonoBehaviour sender, params object[] data) {
		controller.Notify (type, sender, data);
	}
}
