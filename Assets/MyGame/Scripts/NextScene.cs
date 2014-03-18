using UnityEngine;
using System.Collections;

public class NextScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetKeyDown(KeyCode.Return) ) {
			int sceneId = Application.loadedLevel;
			sceneId += 1;
			if ( sceneId >= Application.levelCount ) sceneId = 0;
			Application.LoadLevel(sceneId);
		}
	}
}
