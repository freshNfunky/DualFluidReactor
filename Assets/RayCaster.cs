using System;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class RayCaster : MonoBehaviour {

	public Text text;
	Camera cam;

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
				//StartCoroutine(ScaleMe(hit.transform));
				if (hit.collider.isTrigger) {
					text.text = "You selected the " + hit.transform.name;
					Debug.Log (text.text); // ensure you picked right object

				}
				Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
			}
		//}
	
	}
}
