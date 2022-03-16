using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
    public Color color { get; set; }
    public string name { get; set; }
    
    public void TakeTurn();
    public void Init();
    public bool IsHuman();
}
