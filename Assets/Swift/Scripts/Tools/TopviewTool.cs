﻿using Photon.Pun;
using UnityEngine;
using Valve.VR;

public class TopviewTool : MonoBehaviour
{ 
    private GameObject grabbedObject;

    private bool isOnTopView = false;

    private bool isControllerInside = false;

    public GameObject VRCamera;
    public GameObject CameraRig;

    private GameObject controller;

    public delegate void OnGrabPressed(GameObject controller);
    public static event OnGrabPressed onGrabPressed;

    public delegate void OnGrabReleased(GameObject controller);
    public static event OnGrabReleased onGrabReleased;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        controller = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.transform.parent.GetComponent<PhotonView>().IsMine) return;

        if (SteamVR_Actions._default.TopView.GetStateUp(SteamVR_Input_Sources.RightHand))
        {
            if (isOnTopView)
            {
                Vector3 currentPosition = VRCamera.transform.position;
                currentPosition.y = 0f;
                VRCamera.transform.position = currentPosition;
                CameraRig.transform.position = currentPosition;
            }
            else
            {
                Vector3 currentPosition = VRCamera.transform.position;
                currentPosition.y = GameObject.Find("TopView").gameObject.transform.position.y;
                VRCamera.transform.position = currentPosition;
                CameraRig.transform.position = currentPosition;
            }
            isOnTopView = !isOnTopView;

        }
    }
}