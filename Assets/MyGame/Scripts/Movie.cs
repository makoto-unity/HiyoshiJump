using UnityEngine;
using System.Collections;

public class Movie : MonoBehaviour {

	public MovieTexture movTexture;
	void Start() {
		renderer.material.mainTexture = movTexture;
		movTexture.Play();
	}
}
