using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRankManagerOnState : OnAnimatorState {

	protected override void actionOnState(){
		RankManager.Instance.maybeRunAnimations ();
	}
}
