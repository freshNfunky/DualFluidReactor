using UnityEngine;
using System.Collections;

public class SwitchMaterial : MonoBehaviour {

	//#pragma strict
	Material mat;
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

	private void OnTriggerEnter(Collider other) {
		GetComponent<Renderer> ().material = HighlightMaterial;
	}

	private void OnTriggerStay(Collider other)
	{
		
	}

	private void OnTriggerExit(Collider other) {
		GetComponent<Renderer>().material = mat;
	}
}
