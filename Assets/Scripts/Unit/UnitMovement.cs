using UnityEngine;
using System.Collections;

public class UnitMovement : MonoBehaviour {

	Vector3 Destination;
	NavMeshAgent agent;
	bool haveDestination;
	// Use this for initialization
	void Start () {
		agent = GetComponentInChildren<NavMeshAgent> ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void SetDestination(Vector3 dest){
		Destination = dest;
		haveDestination = true;
		agent.destination = Destination;
	}

}
