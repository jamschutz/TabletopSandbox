using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPlayer : MonoBehaviour, IPlayer
{
    public Color color { get; set; }
    public string name { get; set; }

    public void TakeTurn() 
    {
        // GameManager.instance.SubmitMove(new jsch.JewelHeist.JewelHeistMove());

    }

    public void Init() 
    {

    }

    public bool IsHuman() { return true; }
}
