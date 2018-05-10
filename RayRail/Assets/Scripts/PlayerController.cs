using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Vector3 direction;
	public float speed;
    
	enum turnType {none, right, left, up, down};
	private turnType tT = turnType.none;

    //To go backwards
    List<Vector3> oldDirections = new List<Vector3>();
    bool backwards;

    public bool canTp;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//Move player
		transform.Translate (direction * speed * Time.deltaTime);

		if (Input.GetKeyDown (KeyCode.RightArrow) && tT == turnType.right) {
            //direction = new Vector3 (1, 0, 0);           
            oldDirections.Add(transform.eulerAngles - new Vector3(0,0,180));
            if (!backwards)
                transform.eulerAngles = new Vector3(0, 0, -90);
            
        }
        if (Input.GetKeyDown (KeyCode.LeftArrow) && tT == turnType.left)
        {
            //direction = new Vector3(-1, 0, 0);
            oldDirections.Add(transform.eulerAngles - new Vector3(0, 0, 180));
            if (!backwards)
                transform.eulerAngles = new Vector3(0, 0, 90);
            
        }
        if (Input.GetKeyDown (KeyCode.UpArrow) && tT == turnType.up)
        {
            // direction = new Vector3(0, 1, 0);
            oldDirections.Add(transform.eulerAngles - new Vector3(0, 0, 180));
            if (!backwards)
                transform.eulerAngles = new Vector3(0, 0, 0);
           
        }
        if (Input.GetKeyDown (KeyCode.DownArrow) && tT == turnType.down)
        {
            //direction = new Vector3(0, -1, 0);
            oldDirections.Add(transform.eulerAngles - new Vector3(0, 0, 180));
            if (!backwards)
                transform.eulerAngles = new Vector3(0, 0, 180);
            
        }

        if (Input.GetKeyDown(KeyCode.Space) && !backwards && canTp)
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

            canTp = false;
        }
        
    }

	void OnTriggerEnter2D (Collider2D turnColl) {
		switch (turnColl.tag) {
		    case "turnRight":
                if (backwards)
                {
                    transform.eulerAngles = oldDirections[oldDirections.Count - 1];
                    oldDirections.RemoveAt(oldDirections.Count - 1);
                }
                else
	                tT = turnType.right;
			    break;
            case "turnUp":
                if (backwards)
                {
                    transform.eulerAngles = oldDirections[oldDirections.Count - 1];
                    oldDirections.RemoveAt(oldDirections.Count - 1);
                }
                else
                    tT = turnType.up;                
                  break;
            case "turnDown":
                if (backwards)
                {
                    transform.eulerAngles = oldDirections[oldDirections.Count - 1];
                    oldDirections.RemoveAt(oldDirections.Count - 1);
                }
                else
                    tT = turnType.down;
                 break;
            case "turnLeft":
                if (backwards)
                {
                    transform.eulerAngles = oldDirections[oldDirections.Count - 1];
                    oldDirections.RemoveAt(oldDirections.Count - 1);
                }
                else
                    tT = turnType.left;
                 break;
            case "bounce":
                if (!backwards)
                {
                    transform.eulerAngles -= new Vector3(0, 0, 180);
                    backwards = true;
                }                
                break;
            case "checkpoint":
                if (backwards)
                    StartCoroutine(Restart());
                break;
            default:
			    break;
		}

	}
	void OnTriggerExit2D() {
		tT = turnType.none;
	}

    IEnumerator Restart ()
    {
        speed = 0;
        yield return new WaitForSeconds(1f);
        transform.eulerAngles -= new Vector3(0, 0, 180);        
        backwards = false;
        speed = 4;
       
    }
}
