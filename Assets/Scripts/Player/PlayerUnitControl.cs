using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerUnitControl : MonoBehaviour {
	
	public List<GameObject> Selected;
	// Use this for initialization
	void Start () {
		Selected = new List<GameObject>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Add(GameObject g){
		if(!Selected.Contains(g)){
			Selected.Add(g);	
		}
	}
	public void SetDestinationToSelected(Vector3 dest){
		foreach(GameObject g in Selected){
			g.GetComponent<UnitMovement>().SetDestination(dest);
		}
	}
}
