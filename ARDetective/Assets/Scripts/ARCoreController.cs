using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

/// <summary>
/// Handles ARCore session state tracking, and user interaction with AR scene.
/// CodelabUtils is a Google-provided script that takes care of showing system popups on Android 
/// </summary>
public class ARCoreController : MonoBehaviour {

    //this method from Google's ARCore tutorial
    void QuitOnConnectionErrors()
    {
        if (Session.Status == SessionStatus.ErrorPermissionNotGranted)
        {
            print("ARCore requires you give permission to use the camera.");
            StartCoroutine(CodelabUtils.ToastAndExit(
                "Camera permission is needed to run this application.", 5));
        }
        else if (Session.Status.IsError())
        {
            // This covers a variety of errors.  See reference for details
            // https://developers.google.com/ar/reference/unity/namespace/GoogleARCore
            StartCoroutine(CodelabUtils.ToastAndExit(
                "ARCore encountered a problem connecting. Please restart the app.", 5));
            print("ARCore error:"+Session.Status.ToString());
        }
    }

    // Use this for initialization
    void Start () {
        QuitOnConnectionErrors();
	}
	
	// Update is called once per frame (code from Google's ARCore tutorial)
	void Update () {
        // The session status must be Tracking in order to access the Frame.
        if (Session.Status != SessionStatus.Tracking)
        {
            int lostTrackingSleepTimeout = 15;
            Screen.sleepTimeout = lostTrackingSleepTimeout;
            return;
        }
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}
