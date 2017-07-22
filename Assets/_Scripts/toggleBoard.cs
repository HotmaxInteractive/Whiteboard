using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleBoard : MonoBehaviour {

    public NewtonVR.NVRButton Button;
    public GameObject board;

    private bool boardIsVisible;

    private void Start()
    {
        boardIsVisible = false;
    }

    private void Update()
    {
        if (Button.ButtonDown)
        {
            animateBoard();
        }
    }

    private void animateBoard()
    {
        boardIsVisible = !boardIsVisible;
        if (boardIsVisible)
        {
            board.GetComponent<Animator>().SetTrigger("moveDown");
        }
        if (!boardIsVisible)
        {
            board.GetComponent<Animator>().SetTrigger("moveUp");
        }
    }
}
