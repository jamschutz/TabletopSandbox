using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace jsch.JewelHeist
{
    public class TurnManager : MonoBehaviour
    {
        public TMP_Text buttonText;


        public void BeginPlayerTurn(IPlayer player)
        {
            buttonText.text = player.name;
        }
    }
}

