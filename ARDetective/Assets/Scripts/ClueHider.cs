using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using UnityEngine.UI;

public class ClueHider : MonoBehaviour
{
    static System.Random rand = new System.Random();
    public Text dbug;
    bool cluesPlaced = false;
    List<DetectedPlane> planes = new List<DetectedPlane>();
    List<DetectedPlane> init_planes = new List<DetectedPlane>();

    // Use this for initialization
    List<GameObject> hidingObjects = new List<GameObject>();
    List<GameObject> clueObjects = new List<GameObject>();

    void Start()
    {
        hidingObjects.AddRange(Resources.LoadAll<GameObject>("HidingPlacePrefabs/"));
        clueObjects.AddRange(Resources.LoadAll<GameObject>("CluePrefabs/"));
    }


    // Update is called once per frame
    void Update()
    {
        if (Session.Status == SessionStatus.LostTracking)
        {
            dbug.text = "";
            cluesPlaced = false;
        }
        if (!populating && !cluesPlaced)
        {
            StartCoroutine("populatePlanes");
        }


    }

    private bool populating;
    IEnumerator populatePlanes()
    {
        populating = true;
        yield return null;
        Session.GetTrackables<DetectedPlane>(init_planes);
        planes = init_planes;
        //Remove any subplanes within the list
        if (!cluesPlaced)
        {
            foreach (DetectedPlane plane in planes)
            {
                if (null != plane.SubsumedBy)
                    planes.Remove(plane);
            }
        }

        //place a hiding spot in each plane if theres at least 4
        if (planes.Count > 3 && !cluesPlaced)
        {
            foreach (DetectedPlane p in planes)
            {
                
            }
            cluesPlaced = true;
        }
        populating = false;
    }
}
