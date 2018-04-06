using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavWolfAI : MonoBehaviour {

	// Public 
	public Transform player;
	public float speed;
	// Wander 
	public float wanderRadius;
    public float wanderTimer;
	//Detection 
	public float alertDist;
	public float attackDist;
	// Private 
	private Animator state;
	private Vector3 direction;
	private Transform target;
	private UnityEngine.AI.NavMeshAgent agent;
	private float timer;
	private float distance;

	void OnEnable () {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
        timer = wanderTimer;
    }
	// Use this for initialization
	void Start () {
		state = GetComponent<Animator>();
		distance = Vector3.Distance(player.position, transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance(player.position, transform.position);
		
		// Alert
		if(distance < alertDist && distance > attackDist){
			print("Wolf sees player");
			state.SetBool("isFollowing",true);
			state.SetBool("isWandering",false);
			state.SetBool("isAttacking",false);

		}
		//Attacking
		else if(distance <=  alertDist){
			print("Wolf is following!");
			direction = player.position - transform.position;
			direction.y = 0;

			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),0.09f*Time.deltaTime);

			// transform.Translate(Vector3.forward*speed*Time.deltaTime);
			transform.Translate(0,0,speed*Time.deltaTime);

			state.SetBool("isFollowing",true);
			state.SetBool("isAttacking",false);
			state.SetBool("isWandering",false);

			if(direction.magnitude <= attackDist){
				print("wolf is attacking!");
				state.SetBool("isFollowing",false);
				state.SetBool("isAttacking",true);
				state.SetBool("isWandering",false);
			}
		}
		
		//Wandering
		else if(distance > alertDist){
			 timer += Time.deltaTime;

			 	state.SetBool("isFollowing",false);
				state.SetBool("isAttacking",false);
				state.SetBool("isWandering",true);

			if (timer >= wanderTimer) {
			Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
			agent.SetDestination(newPos);
			timer = 0;
			}


		}

		
	}

	public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
        Vector3 randDirection = Random.insideUnitSphere * dist;
 
        randDirection += origin;
 
        UnityEngine.AI.NavMeshHit navHit;
 
        UnityEngine.AI.NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);
 
        return navHit.position;
    }
}