using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MaterialChanger : MonoBehaviour {

	public Material [] mats;
	//Dictionary<int, Material> matDict;
	public Material [] matEnums;
	string [] matNameByHeight;

	public float deltaT = 1.0f/60.0f;

	void Start()
	{
		if ( mats.Length > 0 ) {
			matEnums = new Material[ mats.Length ];
			foreach( Material mat in mats ) {
				string matIdStr = mat.name.Substring(1);
				int matId = int.Parse(matIdStr);
				if ( matId < matEnums.Length ) {
					matEnums[matId] = mat;
				} else {
					Debug.LogError( "Excess !" + matId );
				}
			}
		}

	}

	public void SetSphere( int id )
	{
//		KeioUnivRow row = KeioUniv.Instance.Rows[id];
//		if ( matDict.ContainsKey( row._NAME ) ) {
//			this.renderer.material = matDict[row._NAME];
//		} else {
//			Debug.LogError("No id:" + id);
//		}
		if ( id < matEnums.Length ) {
			this.renderer.material = matEnums[id];
		} else {
			Debug.LogError("No id:" + id);
		}

	}
	
	public Transform refTrs;

	public int jumpStartPoint = 600;
	public int loopGroundId = 0;
	public int loopGroundAdd = 1;
	public float jumpPower = 9.0f;
	public int loopPoint = 590;
	public float counterSec = 0.0f;
	
	// Update is called once per frame
	void Update () {
		int num = Mathf.FloorToInt(refTrs.position.y * jumpPower);
		int id = 0;
		num = Mathf.Max (num, 0);
		if ( num == 0 ) {
			counterSec += Time.deltaTime;
			if ( counterSec >= 1.0f/30.0f ) {
				counterSec = 0.0f;
				loopGroundId += loopGroundAdd;
				if ( loopGroundId > loopPoint ) {
					loopGroundAdd = -1;
					loopGroundId = loopPoint-1;
				} else if ( loopGroundId < 0 ) {
					loopGroundAdd = 1;
					loopGroundId = 0;
				}
			}
			id = loopGroundId;
		} else {
			id = num + jumpStartPoint;
		}
		//id = Mathf.Min (id, KeioUniv.Instance.Rows.Count-1);
		SetSphere( id );
	}
}
