using UnityEngine;
using System.Collections;
using Pvr_UnitySDKAPI;

public class TargetSlicer : MonoBehaviour
{
	//private Quaternion startRotation;
	//private Quaternion nextRotation;

	void Start ()
	{
		//startRotation = Controller.UPvr_GetControllerQUA ();
	}

	void Update ()
	{
		//TrackPositionOfController ();
		TrackCollisionWithController ();
	}

//	private void TrackPositionOfController ()
//	{
//		nextRotation = Controller.UPvr_GetControllerQUA ();
//
//		if ((Mathf.Abs (nextRotation.eulerAngles.x - startRotation.eulerAngles.x) > 5f) && (Mathf.Abs (nextRotation.eulerAngles.y - startRotation.eulerAngles.y) > 5f))
//		{
//			//displayGuiText.text	= "I am moving the controller";
//			startRotation = nextRotation;
//		}
//		else
//		{
//			//displayGuiText.text	= "I am just holding the controller";
//		}
//	}

	private void TrackCollisionWithController ()
	{
		int layerMask = 1 << 8;
		layerMask = ~layerMask;

		RaycastHit hit;

		if (Physics.Raycast (GameObject.Find ("dot").transform.position, GameObject.Find ("dot").transform.TransformDirection (Vector3.forward), out hit, Mathf.Infinity, layerMask))
		{
			if (hit.collider.name == "Apple(Clone)" || hit.collider.name == "Banana(Clone)" || hit.collider.name == "Orange(Clone)" || hit.collider.name == "Strawberry(Clone)" || hit.collider.name == "Watermelon(Clone)")
			{
				if (gameObject.name == hit.collider.gameObject.name)
				{
					TurboSlice.instance.shatter (gameObject, 1);
				}
			}
		}
	}
}
