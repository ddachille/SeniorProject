using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.transform.position = new Vector3 (gameObject.transform.position.x + 9f, gameObject.transform.position.y+7f, gameObject.transform.position.z+15f);
		gameObject.transform.eulerAngles = new Vector3 (gameObject.transform.eulerAngles.x -20, gameObject.transform.eulerAngles.y+180, gameObject.transform.eulerAngles.z+270);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
