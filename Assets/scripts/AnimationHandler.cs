using UnityEngine;
using System.Collections;

public class AnimationHandler : MonoBehaviour {
	
	Animator anim;
	int hiddenHash = Animator.StringToHash("Base Layer.InfoPanelHidden");
	int shownHash = Animator.StringToHash("Base Layer.infoPanel_Anim");
	int toHiddenHash = Animator.StringToHash("Hide");
	int toShowHash = Animator.StringToHash("Show");

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setPanelState(bool show){
		AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
		if (show) {
			if (stateInfo.nameHash == hiddenHash) {
				anim.SetTrigger (toShowHash);
				anim.ResetTrigger (toHiddenHash);
			}
		} else {
			if (stateInfo.nameHash == shownHash) {
				anim.SetTrigger (toHiddenHash);
				anim.ResetTrigger (toShowHash);
			}
		}

	}
}
