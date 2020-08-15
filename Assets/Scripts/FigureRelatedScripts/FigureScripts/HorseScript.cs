using System.Collections.Generic;

namespace DefaultNamespace.BlackFigureScripts
{
    public class HorseScript : FigureBase
    {
        public override List<PositionToMove> getPositionsToMove(string[,] chessBoard)
        {
            return MoveCheck.getHorseMove(chessBoard, posX, posY);
        }
    }
}