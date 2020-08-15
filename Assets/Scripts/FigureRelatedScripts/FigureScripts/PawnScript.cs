using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace DefaultNamespace.BlackFigureScripts
{
    public class PawnScript : FigureBase
    {
        
        public override List<PositionToMove> getPositionsToMove(String[,] chessBoard)
        {
            List<PositionToMove> result = new List<PositionToMove>();
            result = MoveCheck.pownMove(chessBoard, posX, posY, color, firstMove);
            return result;
        }

        public override void chengeFigPosition(Vector2 newPos, int newX, int newY)
        {
            base.chengeFigPosition(newPos, newX, newY);
            firstMove = false;
        }
    }
}