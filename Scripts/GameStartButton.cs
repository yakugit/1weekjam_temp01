using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC;

public class GameStartButton : MonoBehaviour {

	public PlayMakerFSM fsm;
	public Interaction CameraMove;

	void Awake ()
	{
		fsm = GetComponent<PlayMakerFSM> ();
	}

	public void GameStart() {
		fsm.SendEvent ("Start");
		CameraMove.RunFromIndex (0);
	}
}
