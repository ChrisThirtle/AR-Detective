using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ClueHider : MonoBehaviour, ITrackableEventHandler{
	static System.Random rand = new System.Random();

	bool cluesPlaced = false;

	List<GameObject> hidingObjects = new List<GameObject>();
	List<GameObject> clueObjects = new List<GameObject>();

	
	
    private int hidingplacesPlaced;
	// Update is called once per frame
	public void placeContent()
    {
        if (hidingplacesPlaced < 4)
        {
            GameObject randHidingPlace = GameObject.Instantiate(hidingObjects[rand.Next(hidingObjects.Count - 1)]);
            HidingPlace rhp = randHidingPlace.AddComponent<HidingPlace>();
            GameObject clueMdl = Instantiate(clueObjects[rand.Next(clueObjects.Count - 1)] );
            rhp.clueModel = clueMdl.GetComponent<Clue>();
            clueMdl.transform.SetParent(randHidingPlace.transform);
            clueMdl.SetActive(false);

            GameObject planeClone = GameObject.Instantiate(this.gameObject);
            randHidingPlace.transform.SetParent(planeClone.transform);

            randHidingPlace.transform.localPosition = new Vector3(0f,-1f,0f);
            randHidingPlace.transform.localRotation = Quaternion.identity;
            hidingplacesPlaced++;
        }
    }


    protected TrackableBehaviour mTrackableBehaviour;
    protected TrackableBehaviour.Status m_PreviousStatus;
    protected TrackableBehaviour.Status m_NewStatus;


    protected virtual void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        hidingObjects.AddRange(Resources.LoadAll<GameObject>("HidingPlacePrefabs/"));
        clueObjects.AddRange(Resources.LoadAll<GameObject>("CluePrefabs/"));
    }

    protected virtual void OnDestroy()
    {
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }


    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {

        m_PreviousStatus = previousStatus;
        m_NewStatus = newStatus;
        switch (newStatus)
        {
            case TrackableBehaviour.Status.DETECTED:
                goto case TrackableBehaviour.Status.TRACKED;
            case TrackableBehaviour.Status.TRACKED:
                goto case TrackableBehaviour.Status.EXTENDED_TRACKED;
            case TrackableBehaviour.Status.EXTENDED_TRACKED:
                OnTrackingFound();
                break;
            default:
                if (previousStatus == TrackableBehaviour.Status.TRACKED)
                    OnTrackingLost();
                break;
        }

    }


    protected virtual void OnTrackingFound()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Enable rendering:
        foreach (var component in rendererComponents)
            component.enabled = true;

        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;
    }


    protected virtual void OnTrackingLost()
    {
        print("tracking lost");
    }
}
