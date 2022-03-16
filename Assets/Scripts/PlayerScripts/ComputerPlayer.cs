using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPlayer : MonoBehaviour, IPlayer
{
    public Color color { get; set; }
    public string name { get; set; }
    
    public void TakeTurn() {}
    public void Init() {}

    public bool IsHuman() { return false; }
}
