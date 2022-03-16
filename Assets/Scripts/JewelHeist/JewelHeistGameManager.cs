using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jsch.JewelHeist
{
    public class JewelHeistGameManager : GameManager
    {
        public void TakePlaceholderTurn()
        {
            IMove move = new JewelHeistMove();
            SubmitMove(move);
        }
    }
}