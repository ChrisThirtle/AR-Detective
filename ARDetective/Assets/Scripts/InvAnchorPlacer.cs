using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class InvAnchorPlacer : MonoBehaviour {
	static System.Random rand = new System.Random();

	bool cluesPlaced = false;
	List<DetectedPlane> planes = new List<DetectedPlane>();
	// Use this for initialization
	List<GameObject> hidingObjects = new List<GameObject>();
	List<GameObject> clueObjects = new List<GameObject>();

	GameObject prefabTest = Resources.Load("Assets/GoogleARCore/Examples/Common/Prefabs/AndyBlue.prefab") as GameObject;

	void Start () {
		hidingObjects.AddRange(Resources.LoadAll<GameObject>("HidingPrefabs/"));
		clueObjects.AddRange(Resources.LoadAll<GameObject>("CluePrefabs/"));
	}

	
	

	// Update is called once per frame
	void Update () {
		if (!cluesPlaced)
		{
			Session.GetTrackables<DetectedPlane>(planes);
			//Remove any subplanes within the list
			foreach (DetectedPlane plane in planes)
			{
				if (null != plane.SubsumedBy)
					planes.Remove(plane);
			}
			//Only do more work if there's at least 4 planes left.
			if (planes.Count >= 4)
			{
				int index = rand.Next(planes.Count-1);

				//Find a random point on the plane
				List<Vector3> polygon = new List<Vector3>();
				float x = planes[index].ExtentX*2 / (float)rand.Next(1,int.MaxValue) - planes[index].ExtentX;
				float z = planes[index].ExtentZ * 2 / (float)rand.Next(1, int.MaxValue) - planes[index].ExtentZ;

				//Create a position and rotation so a pose can be made
				Vector3 position = new Vector3(x,0,z);
				Quaternion rotation = new Quaternion(0,0,0,0);
				Pose pose = new Pose(position, rotation);

				//Create anchor with pose
				Anchor anchor = planes[index].CreateAnchor(pose);

				//Instantiate and place a gameobject
				GameObject instance = Instantiate(prefabTest);
				instance.transform.SetParent(anchor.transform,false);

				cluesPlaced = true;
			}
		}
	}
}
