using UnityEngine;
using System.Collections;

public class OculusJump : MonoBehaviour {

	public GameObject RiftCam;
	float x = 0 ;
	float y = 0;
	float z = 0;

	public float limitGravY = 1.0f;
	public float addPower = 10.0f;
	public float maxPower = 30.0f;
	private float [] lastGravY;
	private int gravCnt = 0;

	void Start() {
		lastGravY = new float[5];
		for( int i=0 ; i<lastGravY.Length ; i++ ) {
			lastGravY[i] = 0.0f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if ( OVRDevice.IsHMDPresent() == false ) return;

		OVRDevice.GetAcceleration(0, ref x, ref y, ref z);
		Vector3 rowAcc = new Vector3(-x, -y, z);

		Vector3 grav = RiftCam.transform.localToWorldMatrix.MultiplyPoint(rowAcc);
		//Debug.Log(grav.x + "	" + grav.y + "	" + grav.z );

		lastGravY[gravCnt] = grav.y;
		float ave = 0.0f;
		for( int i=0 ; i<lastGravY.Length ; i++ ) {
			ave += lastGravY[i];
		}
		ave /= (lastGravY.Length * 1.0f);
		gravCnt++;
		if ( gravCnt >= lastGravY.Length ) gravCnt = 0;

		print ( grav.y + "	" + ave );

		if ( ave < limitGravY && isGround ) {
			float upPow = addPower *  Mathf.Abs(ave - limitGravY);
			upPow = Mathf.Min (maxPower, upPow);
			//print ("power:" + upPow);
			this.rigidbody.velocity = new Vector3(0,upPow,0);
		}
	}

	public bool isGround = false;
	public GameObject textObj;

	void OnCollisionEnter(Collision collisionInfo) {
		isGround = true;
		if ( textObj ) textObj.SetActive(true);
	}

	void OnCollisionExit(Collision collisionInfo) {
		isGround = false;
		if ( textObj ) textObj.SetActive(false);
	}
}
