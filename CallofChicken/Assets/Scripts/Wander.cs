using System.Collections;
using UnityEngine;

public class Wander : MonoBehaviour{
    public float moveSpeed; 
    public Transform target;

   
    // public int damage;

    // public GameObject pcHealth;
int counting(int num1, int num2){
    int total;

    total = num1 + num2;
    
    return total;
    
}


void Wandering(){
    //  print("Wolf is Wandering!");
    // makes the animal wander
    transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);
    int randomNum = Random.Range(0,360);
	//Projects Ray in front of animal
    Vector3 fwd = transform.TransformDirection(Vector3.forward);
    RaycastHit hit;

	// Draws the physical ray
    Debug.DrawRay(transform.position,fwd*3,Color.red);
	 
	// Detects collision using raycast
    if(Physics.Raycast(transform.position,fwd,out hit,3)){

        if(hit.collider.tag == "Wall"){
            transform.Rotate(0,randomNum,0);
        }
    }

}

// void Follow(){
//      print("Wolf is Following!");
//     transform.LookAt(target);
// 	transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);
// }

void OnTriggerStay(Collider other)
	{
		if(other.gameObject.name == "Player"){
			print("Player stinks!");
			// Follow();
		}        
        else{
           
            Wandering();
        }

	}

    // void OnCollisionEnter(Collision other)
	// {		

	// 	// if(other.gameObject.name == "Player"){
    //     //     var hit = other.gameObject;
	// 	//     var health = hit.GetComponent<playerHealth>();
    //     //     print("Wolf is attacking!");

	// 	//     if(pcHealth != null){
                
	// 	// 	    // pcHealth.TakeDamage(damage);
    //     //         pcHealth.gameObject.GetComponent<playerHealth>().TakeDamage(damage);
	// 	//     }	
    //     // }
		
	// }


} 