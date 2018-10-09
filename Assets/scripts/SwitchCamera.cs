using UnityEngine;
using System.Collections;

public class SwitchCamera : MonoBehaviour {

	//public int index;
	public GameObject cameraController;

	private void OnEnable()
	{
		
	}

	public void updateCamera(int index) {
		MonoBehaviour component = cameraController.GetComponent<MonoBehaviour> ();
		if (component.GetType().IsAssignableFrom(typeof(CameraController))){
			((CameraController)component).updateCamera(index);
		}
	}
}
