namespace DefaultNamespace
{
    [System.Serializable]
    public class MoveRecord
    {
        public int fromX, fromY;
        public int toX, toY;
        public string moveFrom, moveTo;
        public bool firstMove;
        public MoveRecord(int fromX, int fromY, int x, int y, string moveFrom, string moveTo, bool firstMove)
        {
            this.fromX = fromX;
            this.fromY = fromY;
            toX = x;
            toY = y;
            this.moveFrom = moveFrom;
            this.moveTo = moveTo;
            this.firstMove = firstMove;
        }
    }
}