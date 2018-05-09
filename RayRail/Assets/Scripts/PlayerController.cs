using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Vector3 direction;
	public float speed;

	enum turnType {none, right, left, up, down};
	private turnType tT = turnType.none;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//Move player
		transform.Translate (direction * speed * Time.deltaTime);

		if (Input.GetKey (KeyCode.RightArrow) && tT == turnType.right) {
			direction = new Vector3 (1, 0, 0);
		}
        if (Input.GetKey(KeyCode.LeftArrow) && tT == turnType.left)
        {
            direction = new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow) && tT == turnType.up)
        {
            direction = new Vector3(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow) && tT == turnType.down)
        {
            direction = new Vector3(0, -1, 0);
        }
    }

	void OnTriggerEnter2D (Collider2D turnColl) {
		switch (turnColl.tag) {
		    case "turnRight":
	            tT = turnType.right;
			    break;
            case "turnUp":
                  tT = turnType.up;                
                  break;
            case "turnDown":
                 tT = turnType.down;
                 break;
            case "turnLeft":
                 tT = turnType.left;
                 break;
            default:
			    break;
		}

	}
	void OnTriggerExit2D() {
		tT = turnType.none;
	}
}
