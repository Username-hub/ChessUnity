using System.Collections.Generic;

namespace DefaultNamespace.BlackFigureScripts
{
    public class BishopScript : FigureBase
    {
        public override List<PositionToMove> getPositionsToMove(string[,] chessBoard)
        {
            List<PositionToMove> result = new List<PositionToMove>();
            result.AddRange(MoveCheck.lineCheck(chessBoard, posX, posY, 1, 1));
            result.AddRange(MoveCheck.lineCheck(chessBoard, posX, posY, -1, -1));
            result.AddRange(MoveCheck.lineCheck(chessBoard, posX, posY, -1, 1));
            result.AddRange(MoveCheck.lineCheck(chessBoard, posX, posY, 1, -1));
            return result;
        }
    }
}