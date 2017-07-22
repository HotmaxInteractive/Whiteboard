using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class markerHandle2 : MonoBehaviour
{

    public RenderTexture canvasTexture;

    public GameObject lineHolder;
    public GameObject tip;

    public GameObject whiteBoard;
    private NewtonVR.NVRHand hand;

    private bool whiteBoardHit;
    public getMaterialColor raycastScript;

    private int tipCounter;

    // Use this for initialization
    void Start()
    {
        whiteBoardHit = false;
    }

    void Update()
    {
        //get last hand and store in memory
        if (GetComponent<NewtonVR.NVRInteractable>().AttachedHand != null)
        {
            hand = GetComponent<NewtonVR.NVRInteractable>().AttachedHand;
        }


        //start linerenderer and freeze marker on z axis
        if (transform.position.z >= whiteBoard.transform.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, whiteBoard.transform.position.z);
            if (!whiteBoardHit)
            {
                whiteBoardHit = true;
                onWhiteBoardHit();
            }
        } else
        {
            if (whiteBoardHit)
            {
                onWhiteBoardExit();
            }
            whiteBoardHit = false;
        }

    }


    void onWhiteBoardHit()
    {
        //get the amount of tips already in lineHolder
        tipCounter = lineHolder.transform.childCount;
        
        //give initial haptic pulse to tell us when we hit the board
        hand.InputDevice.TriggerHapticPulse(1000); //make sure you make InputDevice a public variable on NVRHand -- because their public haptic methods suck

        //enable the renderer
        var tipClone = (GameObject)Instantiate(tip, transform.position, transform.rotation, gameObject.transform);
        tipClone.transform.localPosition = new Vector3(0, 0, 0.534f);

        tipClone.name = "tip";

        Color rayColor = raycastScript.raycastHitColor;
        tipClone.GetComponent<Renderer>().material.color = rayColor;
        tipClone.GetComponent<Renderer>().material.renderQueue += tipCounter;
    }

    void onWhiteBoardExit()
    {
        //disable the line renderer
        //SaveTexture();

        //create a clone and parent it somewhere in the scene
        Transform tip = gameObject.transform.FindChild("tip").transform;
        tip.parent = lineHolder.transform;
    }

}
