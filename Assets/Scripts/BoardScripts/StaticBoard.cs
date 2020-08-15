using System.Collections.Generic;

namespace DefaultNamespace
{
    public static class StaticBoard
    {
        public static string[,] chessBoardString = 
        {
            {"#", "#",  "#",  "#",  "#",  "#",  "#",  "#",  "#",  "#"},
            {"#", "BR", "BH", "BB", "BK", "BQ", "BB", "BH", "BR", "#"},
            {"#", "BP", "BP", "BP", "BP", "BP", "BP", "BP", "BP", "#"},
            {"#", " ",  " ",  " ",  " ",  " ",  " ",  " ",  " ",  "#"},
            {"#", " ",  " ",  " ",  " ",  " ",  " ",  " ",  " ",  "#"},
            {"#", " ",  " ",  " ",  " ",  " ",  " ",  " ",  " ",  "#"},
            {"#", " ",  " ",  " ",  " ",  " ",  " ",  " ",  " ",  "#"},
            {"#", "WP", "WP", "WP", "WP", "WP", "WP", "WP", "WP", "#"},
            {"#", "WR", "WH", "WB", "WK", "WQ", "WB", "WH", "WR", "#"},
            {"#", "#",  "#",  "#",  "#",  "#",  "#",  "#",  "#",  "#"}        
        };

        public static int nowTurn = 1;

        public static List<MoveRecord> MoveRecords = new List<MoveRecord>();
    }
}