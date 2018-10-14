using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform[] views;
	public float transitionSpeed;
	public GameObject CameraAnimation;
	public GameObject PanelAnimation;
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
			float transitionState = Time.deltaTime * transitionSpeed;
			transform.position = Vector3.Lerp (transform.position, currentView.position, transitionState);
			Vector3 currentAngle = new Vector3 (
				Mathf.LerpAngle (transform.rotation.eulerAngles.x, currentView.rotation.eulerAngles.x, transitionState),
				Mathf.LerpAngle (transform.rotation.eulerAngles.y, currentView.rotation.eulerAngles.y, transitionState),
				Mathf.LerpAngle (transform.rotation.eulerAngles.z, currentView.rotation.eulerAngles.z, transitionState));
			transform.eulerAngles = currentAngle;

			float delta = Vector3.Magnitude (transform.position - currentView.position);

			if (delta < 1) {
				showPanel (true);
			} else {
				showPanel (false);
			}
		}
	}

	public void updateCamera(int index){
		
		currentView = views[Mathf.Clamp(index,0,views.Length)];
	
	
	}

	protected void showPanel(bool show){
		AnimationHandler component = PanelAnimation.GetComponent<AnimationHandler> ();
		if (component.GetType().IsAssignableFrom(typeof(AnimationHandler))){
			((AnimationHandler)component).setPanelState(show);
		}
	}
}
