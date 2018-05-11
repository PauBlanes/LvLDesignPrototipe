using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class godMode : MonoBehaviour {

	private float speed;
	// Use this for initialization
	void Start () {
		speed = GetComponent<PlayerController> ().speed;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.G))
			GetComponent<PlayerController> ().enabled = !GetComponent<PlayerController>().isActiveAndEnabled;

		if (!GetComponent<PlayerController> ().isActiveAndEnabled) {
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				transform.eulerAngles = new Vector3(0, 0, -90);

			}
			if (Input.GetKeyDown (KeyCode.LeftArrow))
			{
				transform.eulerAngles = new Vector3(0, 0, 90);

			}
			if (Input.GetKeyDown (KeyCode.UpArrow))
			{
				transform.eulerAngles = new Vector3(0, 0, 0);

			}
			if (Input.GetKeyDown (KeyCode.DownArrow))
			{
				transform.eulerAngles = new Vector3(0, 0, 180);

			}

			if (Input.GetKeyDown(KeyCode.Space))
			{
				Vector3 dir = new Vector3();
				if (transform.eulerAngles.z == 0 || transform.eulerAngles.z == 360)
					dir = new Vector3(0, 1, 0);
				if (transform.eulerAngles.z == 180 ||transform.eulerAngles.z == -180)
					dir = new Vector3(0, -1, 0);
				if (transform.eulerAngles.z == 90 || transform.eulerAngles.z == -270)
					dir = new Vector3(-1, 0, 0);
				if (transform.eulerAngles.z == 270 || transform.eulerAngles.z == -90)
				{                
					dir = new Vector3(1, 0, 0);
				}

				transform.position += dir*5;
			}
		}

	}

}
