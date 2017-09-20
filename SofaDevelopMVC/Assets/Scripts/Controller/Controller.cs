using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : ApplicationElement{

	public PreviewController preview;
	public InputController input;

	public void Notify(Notification type, MonoBehaviour sender, params object[] data) {
		
		preview.OnNotification(type, sender, data);
		input.OnNotification(type, sender, data);

	}
}
