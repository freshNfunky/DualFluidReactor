using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform[] views;
	public float transitionSpeed;
	public GameObject CameraAnimation;
	Transform currentView;
	Animator anim;
	int entryStateHash;
	int menueStateHash;
	int stopStateHash;

	// Use this for initialization
	void Start () {
		currentView = views[0];
		anim = CameraAnimation.GetComponent<Animator> ();
		entryStateHash = Animator.StringToHash("Base Layer.Entry");
		menueStateHash = Animator.StringToHash("Base Layer.Menue");
		stopStateHash = Animator.StringToHash("Base Layer.Stop");

	}
	
	// Update is called once per frame
	void LateUpdate () {
		AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
		//AnimationState state = CameraAnimation.GetComponent<AnimationState> ();
		if (stateInfo.nameHash == stopStateHash) {
			anim.enabled = false;
			transform.position = Vector3.Lerp (transform.position, currentView.position, Time.deltaTime * transitionSpeed);
			Vector3 currentAngle = new Vector3 (
				                       Mathf.LerpAngle (transform.rotation.eulerAngles.x, currentView.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
				                       Mathf.LerpAngle (transform.rotation.eulerAngles.y, currentView.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
				                       Mathf.LerpAngle (transform.rotation.eulerAngles.z, currentView.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed));
			transform.eulerAngles = currentAngle;
		}
	}
}
