using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class FigureBase : MonoBehaviour
    {
        public int posX, posY, color;
        public bool firstMove = true;
        public virtual void chengeFigPosition(Vector2 newPos, int newX, int newY)
        {
            transform.position = newPos;
            posX = newX;
            posY = newY;
        }

        public virtual List<PositionToMove> getPositionsToMove(String[,] chessBoard)
        {
            //TODO: Return to null
            PositionToMove pos = new PositionToMove();
            pos.posX = 1;
            pos.posY = 1;
            return new List<PositionToMove>(){pos};
        }
    }
}