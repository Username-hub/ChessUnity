using System.Collections.Generic;

namespace DefaultNamespace.BlackFigureScripts
{
    public class QueenScript : FigureBase
    {
        public override List<PositionToMove> getPositionsToMove(string[,] chessBoard)
        {
            List<PositionToMove> result = new List<PositionToMove>();
            result.AddRange(MoveCheck.lineCheck(chessBoard, posX, posY, 1, 1));
            result.AddRange(MoveCheck.lineCheck(chessBoard, posX, posY, -1, -1));
            result.AddRange(MoveCheck.lineCheck(chessBoard, posX, posY, -1, 1));
            result.AddRange(MoveCheck.lineCheck(chessBoard, posX, posY, 1, -1));
            result.AddRange(MoveCheck.lineCheck(chessBoard, posX, posY, 1, 0));
            result.AddRange(MoveCheck.lineCheck(chessBoard, posX, posY, -1, 0));
            result.AddRange(MoveCheck.lineCheck(chessBoard, posX, posY, 0, 1));
            result.AddRange(MoveCheck.lineCheck(chessBoard, posX, posY, 0, -1));
            return result;
        }
    }
}