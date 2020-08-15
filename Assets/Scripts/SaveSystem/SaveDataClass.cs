using System;
using System.Collections.Generic;

namespace DefaultNamespace
{
    [System.Serializable]
    public class SaveDataClass
    {
        public string[,] chessBoard;
        public int nowMove;
        public List<MoveRecord> moveRecords = new List<MoveRecord>();

        /*public SaveDataClass(string[,] chessBoard, int nowMove, List<MoveRecord> moveRecords)
        {
            this.chessBoard = chessBoard;
            this.nowMove = nowMove;
            MoveRecords = moveRecords;
        }
        */
        public SaveDataClass(string[,] chessBoard, int nowMove, List<MoveRecord> moveRecords)
        {
            this.chessBoard = chessBoard;
            this.nowMove = nowMove;
            this.moveRecords.AddRange(moveRecords);
        }
    }
}