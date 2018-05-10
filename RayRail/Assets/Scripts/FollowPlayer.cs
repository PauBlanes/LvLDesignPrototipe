using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    Vector3 offset;
    public Transform player;

	// Use this for initialization
	void Start () {
        	
	}
	
	// Update is called once per frame
	void Update () {
        offset = player.position - transform.position;
        offset.z = 0;

        transform.position += offset;
    }
}
