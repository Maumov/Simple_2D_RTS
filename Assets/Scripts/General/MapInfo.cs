using UnityEngine;
using System.Collections;

public class MapInfo : MonoBehaviour {
	public float SizeX,SizeY,MapMinX, MapMinY, MapMaxX,MapMaxY;

	public static Rect MapLimits;
	GameObject theMap;
	// Use this for initialization
	void Start () {
		CreateMap();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void CreateMap(){
		theMap = GameObject.FindGameObjectWithTag("Map");
		SizeX = theMap.transform.localScale.x;
		SizeY = theMap.transform.localScale.y;
		MapMinX = 0 - (SizeX * 0.5f);
		MapMinY = 0 - (SizeY * 0.5f);
		MapMaxX = SizeX * 0.5f;
		MapMaxY = SizeY * 0.5f;
		MapLimits = new Rect(MapMinX,MapMinY,MapMaxX,MapMaxY);
		Debug.Log(MapLimits.width +" "+ MapLimits.height);
	}

}
