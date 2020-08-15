using System.Collections.Generic;

namespace DefaultNamespace
{
    public class MoveRecorder
    {

        public GameManager gameManager;
        public BoardScript boardScript;
        private List<MoveRecord> moveRecordList = new List<MoveRecord>();

        public MoveRecorder(GameManager gameManager, BoardScript boardScript)
        {
            this.gameManager = gameManager;
            this.boardScript = boardScript;
        }
        public void recordMove(int posXtoMove, int posYtoMove)
        {
            MoveRecord moveRecord = new MoveRecord(gameManager.cureentSelect.posX, gameManager.cureentSelect.posY,
                posXtoMove, posYtoMove,
                boardScript.chessBoardString[gameManager.cureentSelect.posX, gameManager.cureentSelect.posY],
                boardScript.chessBoardString[posXtoMove, posYtoMove], gameManager.cureentSelect.firstMove);
            moveRecordList.Add(moveRecord);
            //moveRecordList.Add(new MoveRecord(gameManager.cureentSelect.posX, gameManager.cureentSelect.posY,posXtoMove, posYtoMove,
            //    chessBoardString[gameManager.cureentSelect.posX,gameManager.cureentSelect.posY],chessBoardString[posXtoMove,posYtoMove], gameManager.cureentSelect.firstMove));
        }

        public void deleteLastRecord()
        {
            moveRecordList.RemoveAt(moveRecordList.Count - 1);
        }

        public MoveRecord getLastRecord()
        {
            return moveRecordList[moveRecordList.Count - 1];
        }

        public List<MoveRecord> GetRecordList()
        {
            return moveRecordList;
        }

        public void addInRange(List<MoveRecord> moveRecords)
        {
            moveRecordList.AddRange(moveRecords);
        }
    }
}