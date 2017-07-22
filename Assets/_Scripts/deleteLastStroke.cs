using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteLastStroke : MonoBehaviour {

    public NewtonVR.NVRButton Button;
    public GameObject lineHolder;

    private void Update()
    {
        if (Button.ButtonDown)
        {
            deleteLastChild();
        }
    }

    void deleteLastChild(){
        int numberOfChildren = lineHolder.transform.childCount;

        if (numberOfChildren > 0)
        {
            Destroy(lineHolder.transform.GetChild(numberOfChildren - 1).gameObject);       // destroy last child
        }
    }
}
