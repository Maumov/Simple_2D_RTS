using UnityEngine;
using System.Collections;

public class LeftClickControl : MonoBehaviour {
	public GameObject TargetPosition;
	PlayerUnitControl unitControl;
	// Use this for initialization
	void Start () {
		unitControl = GetComponent<PlayerUnitControl>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonUp(1)){
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray,out hit)){
				Debug.Log("Right click at: "+ hit.point);
				TargetPosition.transform.position = new Vector3(hit.point.x,TargetPosition.transform.position.y,hit.point.z);
				unitControl.SetDestinationToSelected(new Vector3(hit.point.x,TargetPosition.transform.position.y,hit.point.z));
			}
		}
	}
}
