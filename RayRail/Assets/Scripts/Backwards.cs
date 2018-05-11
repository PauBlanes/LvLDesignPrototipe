using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backwards : MonoBehaviour {


	public enum bacwardsDirection {none, right, left, down, up, up_right, up_left, down_right, down_left};
	public bacwardsDirection bDir;

	private PlayerController pC;

	Vector3 newRot = new Vector3();
	bool readyBackwards;

	// Use this for initialization
	void Start () {
		pC = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (pC.transform.position, transform.position) < 0.5) {
			if (readyBackwards) {
				pC.transform.eulerAngles = newRot;
				readyBackwards = false;
			}
			if (pC.ready && !pC.backwards) {
				pC.transform.eulerAngles = pC.newRot;
				pC.ready = false;
			}
		}
	}
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "Player") {
			if (pC.backwards) {
				switch (bDir) {
				case bacwardsDirection.right:
					newRot = new Vector3 (0, 0, 270);
					readyBackwards = true;
					break;
				case bacwardsDirection.left:
					newRot = new Vector3 (0, 0, 90);
					readyBackwards = true;
					break;
				case bacwardsDirection.up:
					newRot = new Vector3 (0, 0, 0);
					readyBackwards = true;
					break;
				case bacwardsDirection.down:
					newRot = new Vector3 (0, 0, 180);
					readyBackwards = true;
					break;
				case bacwardsDirection.up_left:
					newRot = new Vector3 (0, 0, 45);
					readyBackwards = true;
					break;
				case bacwardsDirection.up_right:
					newRot = new Vector3 (0, 0, -45);
					readyBackwards = true;
					break;
				case bacwardsDirection.down_left:
					newRot = new Vector3 (0, 0, 135);
					readyBackwards = true;
					break;
				case bacwardsDirection.down_right:
					newRot = new Vector3 (0, 0, -135);
					readyBackwards = true;
					break;
				}
			}
		}
	}


}
