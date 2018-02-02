using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	public Rigidbody projectile;
	public Transform shootPoint;
	public int shootSpeed;

	void Update () {
		if(Input.GetButtonDown("Fire1")){
			
			Rigidbody clone;

			clone = (Rigidbody)Instantiate(projectile, shootPoint.position, projectile.rotation);

			clone.velocity = shootPoint.TransformDirection (Vector3.forward*shootSpeed*Time.deltaTime);
		}
	}
}
