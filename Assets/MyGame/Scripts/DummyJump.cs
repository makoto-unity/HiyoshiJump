using UnityEngine;
using System.Collections;

public class DummyJump : MonoBehaviour {

	public float power;
	public float addPower = 10.0f;
	
	void Update () {
		if ( Input.GetButtonUp("Fire1") || Input.GetKeyUp (KeyCode.Space) ) {
			//this.rigidbody.AddForce(new Vector3(0,addPower,0),ForceMode.Impulse);
			this.rigidbody.velocity = new Vector3(0,addPower,0);
		}
	}
}
