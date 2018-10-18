using System;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class RayCaster : MonoBehaviour {

	public Text text;
	Camera cam;

	private GameObject lastObject;
	private GameObject currentObject;

	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void LateUpdate () {

		//if ( Input.GetMouseButtonDown (0)){ 
			RaycastHit hit; 
			Ray ray = cam.ScreenPointToRay(Input.mousePosition); 
			if ( Physics.Raycast (ray, out hit, 1000.0f)) {
				Debug.Log (text.text);
				text.text = "You selected the " + hit.transform.name;
				//StartCoroutine(ScaleMe(hit.transform));
				currentObject = hit.transform.gameObject;
				if (hit.collider.isTrigger) {
					
					 // ensure you picked right object
					
					if (!currentObject.Equals (lastObject)) { 
						highlight (currentObject, true);
						if (lastObject != null)
							highlight (lastObject, false);
					}
					
				}
				lastObject = currentObject;	
				Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
			}
		//}
	
	}

	void highlight(GameObject obj, bool status){

		SwitchMaterial switcher = obj.GetComponent<SwitchMaterial> ();
		if (switcher != null) {
			if (status)
				switcher.OnTriggerEnter (null);
			else
				switcher.OnTriggerExit (null);
		}	 
	}
}
