using UnityEngine;
using System.Collections;

public class CamRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y-1f, gameObject.transform.position.z+10f);
		gameObject.transform.eulerAngles = new Vector3 (gameObject.transform.eulerAngles.x -45, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
