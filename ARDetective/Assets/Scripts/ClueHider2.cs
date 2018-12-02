using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using UnityEngine.UI;

public class ClueHider2 : MonoBehaviour {
    static System.Random rand = new System.Random();
    public Text dbug;
    bool cluesPlaced = false;
    public Camera cam;
    List<DetectedPlane> planes = new List<DetectedPlane>();
    List<DetectedPlane> init_planes = new List<DetectedPlane>();
    public LineRenderer lr;

    // Use this for initialization
    List<GameObject> hidingObjects = new List<GameObject>();
    List<GameObject> clueObjects = new List<GameObject>();

    void Start()
    {
        cam = Camera.main;
        hidingObjects.AddRange(Resources.LoadAll<GameObject>("HidingPlacePrefabs/"));
        clueObjects.AddRange(Resources.LoadAll<GameObject>("CluePrefabs/"));
    }

    void Update()
    {
        Session.GetTrackables<DetectedPlane>(init_planes);
        if (init_planes.Count > 3 && !addingToPlane)
        {
            StartCoroutine("add_to_plane");
        }
    }

    private bool addingToPlane;
    IEnumerator add_to_plane()
    {
        addingToPlane = true;
        for (float i = 0; i < Screen.width; i+=(Screen.width*0.1f))
        {
            Ray ray = cam.ScreenPointToRay(new Vector3(i, Screen.height / 2, 0));
            Vector3[] psns = { ray.origin, ray.direction };
            lr.SetPositions(psns);
            Debug.DrawRay(ray.origin, Vector3.forward * 10, new Color(i,i*2,i*3), 10f, false);
            TrackableHit hit;
            if (Frame.Raycast(i, Screen.height / 2, TrackableHitFlags.PlaneWithinBounds, out hit) )
            {
                DetectedPlane p = hit.Trackable as DetectedPlane;
                if (p != null)
                {
                    //Create a position and rotation so a pose can be made
                    //Create anchor with pose
                    Anchor anchor = Session.CreateAnchor(p.CenterPose, p);

                    //TODO: fill out 'HidingPlace' and 'Clue' components' properties
                    //Instantiate and place a HidingPlace
                    GameObject randHidingPlace = GameObject.Instantiate(hidingObjects[rand.Next(hidingObjects.Count - 1)]);
                    HidingPlace rhp = randHidingPlace.AddComponent<HidingPlace>();
                    GameObject clueMdl = clueObjects[rand.Next(clueObjects.Count - 1)];
                    rhp.clueModel = clueMdl.AddComponent<Clue>();
                    randHidingPlace.transform.SetParent(anchor.transform);
                }
            }
            yield return new WaitForSecondsRealtime(0.05f);
        }
        addingToPlane = false;
    }
}
