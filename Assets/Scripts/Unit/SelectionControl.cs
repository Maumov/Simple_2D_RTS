using UnityEngine;
using System.Collections;


public class SelectionControl: MonoBehaviour
{
	public bool selected;
	public bool highlighted;
	PlayerUnitControl unitControl;
    void Start()
    {
		unitControl = GameObject.FindObjectOfType<PlayerUnitControl>();
    }
    // Update is called once per frame
    void Update()
    {
		Vector3 camPos = Camera.main.WorldToScreenPoint(transform.position);
		camPos.y = MouseSelection.InvertMouseY(camPos.y);
		if (Input.GetMouseButtonUp(0))
		{
			selected = MouseSelection.selection.Contains(camPos);
			if (selected)
			{
				Selected();
			}
			else {
				Deselected();
			}


		}
		else if (Input.GetMouseButton(0))
		{
			highlighted = MouseSelection.selection.Contains(camPos);
			if (highlighted)
			{
				Highlight();
			}

		}
    }
	void Selected(){
		unitControl.Add(gameObject);
		Debug.Log (name + " got selected ");
	}
	void Highlight(){
		Debug.Log (name + " got highlighted ");
	}
	void Deselected(){
		Debug.Log (name + " got deselected ");
	}
}