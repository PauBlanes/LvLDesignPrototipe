using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public Vector3 direction;
	public float speed;
    
	enum turnType {none, right, left, up, down, up_right, up_left, down_right, down_left};
	private turnType tT = turnType.none;

    //To go backwards
    List<Vector3> oldDirections = new List<Vector3>();
    public bool backwards;

    public bool canTp;
	public bool special;

	int coinCount;
	public Text coinText;
	public Text winText;

	public bool ready;
	public Vector3 newRot = new Vector3();

    // Use this for initialization
    void Start () {
		SetCountText ();
	}
	
	// Update is called once per frame
	void Update () {
		
		//Move player
		transform.Translate (direction * speed * Time.deltaTime);

		//Moviments normals
		if (Input.GetKeyDown (KeyCode.RightArrow) && tT == turnType.right) {
			if (!backwards) {
				newRot = new Vector3 (0, 0, -90);
				ready = true;
			}
            
        }
        if (Input.GetKeyDown (KeyCode.LeftArrow) && tT == turnType.left)
        {
			if (!backwards) {
				newRot = new Vector3 (0, 0, 90);
				ready = true;
			}
            
        }
        if (Input.GetKeyDown (KeyCode.UpArrow) && tT == turnType.up)
        {
			
			if (!backwards) {
				newRot = new Vector3 (0, 0, 0);
				ready = true;
			}
           
        }
        if (Input.GetKeyDown (KeyCode.DownArrow) && tT == turnType.down)
        {
			if (!backwards) {
				newRot = new Vector3 (0, 0, 180);
				ready = true;
			}
        }
		//Diagonals
		if (Input.GetKeyDown (KeyCode.RightArrow) && tT == turnType.right) {
			if (!backwards) {
				newRot = new Vector3 (0, 0, -90);
				ready = true;
			}

		}
		if (Input.GetKeyDown (KeyCode.RightArrow) && Input.GetKeyDown (KeyCode.UpArrow) && tT == turnType.up_right)
		{
			if (!backwards) {
				newRot = new Vector3 (0, 0, -45);
				ready = true;
			}
		}
		if (Input.GetKeyDown (KeyCode.RightArrow) && Input.GetKeyDown (KeyCode.DownArrow) && tT == turnType.down_right)
		{
			if (!backwards) {
				newRot = new Vector3 (0, 0, -135);
				ready = true;
			}
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow) && Input.GetKeyDown (KeyCode.UpArrow) && tT == turnType.up_left)
		{
			if (!backwards) {
				newRot = new Vector3 (0, 0, 45);
				ready = true;
			}
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow) && Input.GetKeyDown (KeyCode.DownArrow) && tT == turnType.down_left)
		{
			if (!backwards) {
				newRot = new Vector3 (0, 0, 135);
				ready = true;
			}
		}

		//tp
        if (Input.GetKeyDown(KeyCode.Space) && !backwards && canTp)
        {
            Vector3 dir = new Vector3();
            if (transform.eulerAngles.z == 0)
                dir = new Vector3(0, 1, 0);
            if (transform.eulerAngles.z == 180)
                dir = new Vector3(0, -1, 0);
            if (transform.eulerAngles.z == 90)
                dir = new Vector3(-1, 0, 0);
            if (transform.eulerAngles.z == 270)                
                dir = new Vector3(1, 0, 0);
			if (transform.eulerAngles.z == 45)                
				dir = new Vector3(-1, 1, 0);
			if (transform.eulerAngles.z == 315)                
				dir = new Vector3(1, 1, 0);
			if (transform.eulerAngles.z == 135)                
				dir = new Vector3(-1, -1, 0);
			if (transform.eulerAngles.z == (360-135))                
				dir = new Vector3(1, -1, 0);
			
            transform.position += dir*5;

            canTp = false;
        }
        
    }

	void OnTriggerEnter2D (Collider2D turnColl) {


			switch (turnColl.tag) {
			case "turnRight":
				if(!backwards)		
					tT = turnType.right;
				break;
			case "turnUp":
				if(!backwards)			
					tT = turnType.up;                
				break;
			case "turnDown":
				if(!backwards)			
					tT = turnType.down;
				break;
			case "turnLeft":
				if(!backwards)			
					tT = turnType.left;
				break;
			case "up-right":
				if(!backwards)	
					tT = turnType.up_right;
				break;
			case "up-left":
				if(!backwards)	
					tT = turnType.up_left;                
				break;
			case "down-right":
				if(!backwards)	
					tT = turnType.down_right;
				break;
			case "down-left":
				if(!backwards)		
					tT = turnType.down_left;
				break;
			case "bounce":
				if (!backwards)
				{					
					transform.eulerAngles -= new Vector3(0, 0, 180);
					backwards = true;
					speed *= 3;
				}
				ready = false;
				break;
			case "checkpoint":
				if (backwards)
				StartCoroutine(Restart(speed));
				break;
			case "coin":
				coinCount++;
				SetCountText ();
				Destroy (turnColl.gameObject);
				break;
			case "win":
				winText.text = "YOU WIN!";
				Time.timeScale = 0;
				break;
			default:
				break;
			}
	}
	void OnTriggerExit2D() {
		tT = turnType.none;
		if (special)
			special = false;
	}

	IEnumerator Restart (float s)
    {
        speed = 0;
        yield return new WaitForSeconds(1f);
        transform.eulerAngles -= new Vector3(0, 0, 180);        
        backwards = false;
        speed = s/3;
       
    }

	void SetCountText () {
		coinText.text = "X " + coinCount.ToString ();
	}


}
