using UnityEngine;
using System.Collections;

public class SwitchMaterial : MonoBehaviour {

	//#pragma strict
	protected Material mat;
	public Material HighlightMaterial;
	public bool change;

	// Use this for initialization
	void Start () {
		mat = GetComponent<Renderer> ().material;
	}
	
	// Update is called once per frame
	void Update () {
		//if (change) {
		//	GetComponent<Renderer> ().material = HighlightMaterial;
		//} else {
		//	GetComponent<Renderer>().material = mat;
		//}	
	
	}

	public void OnTriggerEnter(Collider other) {
		recursiveSetMaterial (this.gameObject, HighlightMaterial);
		//mat = HighlightMaterial;
	}

	public void OnTriggerStay(Collider other)
	{
		
	}

	public void OnTriggerExit(Collider other) {
		//GetComponent<Renderer>().material = mat;
		recursiveSetMaterial (this.gameObject, mat);
	}

	protected void recursiveSetMaterial(GameObject obj, Material mat)
	{
		Renderer meshrender = GetComponent<Renderer>();
		if (meshrender != null) {
			meshrender.material = mat; 

			// List gs = new List();
			// Transform[] ts = gameObject.GetComponentsInChildren<Transform>();
			// if (ts == null)
			// 	return;
			foreach (Transform t in obj.transform) {
				recursiveSetMaterial(t.gameObject, mat);
			}
		}
	}
}
