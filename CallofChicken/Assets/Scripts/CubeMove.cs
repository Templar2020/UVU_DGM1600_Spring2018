using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour {
	
	// public float transX;
	// public float transY;
	// public float transZ;

	// public float rotX;
	// public float rotY;
	// public float rotZ;

		// public Vector3 move;
		// public Vector3 rotate;

		public float moveSpeed; 

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// transform.Translate(transX,transY,transZ);
		// transform.Rotate(rotX,rotY,rotZ);
		if(Input.GetKey(KeyCode.W)){
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		}

		if(Input.GetKey(KeyCode.S)){
			transform.Translate(Vector3.back*moveSpeed*Time.deltaTime);
		}

		if(Input.GetKey(KeyCode.Q)){
			transform.Translate(Vector3.left*moveSpeed*Time.deltaTime);
		}

		if(Input.GetKey(KeyCode.E)){
			transform.Translate(Vector3.right*moveSpeed*Time.deltaTime);
		}

		// transform.Translate(move * Time.deltaTime);
		// transform.Rotate(rotate * Time.deltaTime);	

		

	}
}
