using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backwards : MonoBehaviour {


	public enum bacwardsDirection {none, right, left, down, up};
	public bacwardsDirection bDir;

	private PlayerController pC;
	// Use this for initialization
	void Start () {
		pC = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "Player") {
			if (pC.backwards) {
				switch (bDir) {
				case bacwardsDirection.right:
					pC.transform.eulerAngles = new Vector3 (0, 0, 270);
					break;
				case bacwardsDirection.left:
					pC.transform.eulerAngles = new Vector3 (0, 0, 90);
					break;
				case bacwardsDirection.up:
					pC.transform.eulerAngles = new Vector3 (0, 0, 0);
					break;
				case bacwardsDirection.down:
					pC.transform.eulerAngles = new Vector3 (0, 0, 180);
					break;
				}
			}
		}
	}
}
