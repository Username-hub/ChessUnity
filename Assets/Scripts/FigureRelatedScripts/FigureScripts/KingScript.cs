using System.Collections.Generic;

namespace DefaultNamespace.BlackFigureScripts
{
    public class KingScript : FigureBase
    {
        //TODO: King script;
        public override List<PositionToMove> getPositionsToMove(string[,] chessBoard)
        {
            List<PositionToMove> result = new List<PositionToMove>();
            result.AddRange(MoveCheck.getKingMove(chessBoard, posX, posY));
            return result;
        }
    }
}