using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DefaultNamespace
{
    public static class MoveCheck
    {
        public static List<PositionToMove> lineCheck(string[,] chessBoard, int fromX, int fromY, int dirX, int dirY)
        {
            //String[,] chessBoardRotated = rotateBoard(chessBoard, chessBoard.GetLength(1));
            List<PositionToMove> result = new List<PositionToMove>();
            int moveX = fromX + dirX;
            int moveY = fromY + dirY;
            while (true)
            {
                if (canMoveToPos(chessBoard, moveX, moveY))
                {
                    PositionToMove newPos = new PositionToMove(moveX,moveY);
                    result.Add(newPos);
                }
                else
                {
                    if(canBeatFigure(chessBoard, fromX, fromY, moveX, moveY))
                    {
                        PositionToMove newPos = new PositionToMove(moveX,moveY);
                        result.Add(newPos);
                    }
                    break;
                }
                moveX += dirX;
                moveY += dirY;
            }
            return result;
        }

        public static List<PositionToMove> pownMove(String[,] chessBoard, int fromX, int fromY, int color, bool firstMove)
        {
            //String[,] chessBoardRotated = rotateBoard(chessBoard, chessBoard.GetLength(1));
            List<PositionToMove> result = new List<PositionToMove>();
            if (canMoveToPos(chessBoard, fromX - color, fromY))
            {
                result.Add(new PositionToMove(fromX - color, fromY));
            }
            if (canMoveToPos(chessBoard, fromX - (color * 2), fromY ) && firstMove && result.Count > 0)
            {
                result.Add(new PositionToMove(fromX - (color * 2), fromY));
            }

            if (canBeatFigure(chessBoard, fromX, fromY, fromX - color, fromY - 1))
            {
                result.Add(new PositionToMove(fromX - color, fromY - 1));
            }
            
            if (canBeatFigure(chessBoard, fromX, fromY, fromX - color, fromY + 1))
            {
                result.Add(new PositionToMove(fromX - color, fromY + 1));
            }
            return result;
        }
        private static bool canMoveToPos(String[,] chessBoard, int toX, int toY)
        {
            //Debug.Log("Can Move: x: " + toX + " y: " + toY + " In cell: " + chessBoard[toX, toY] + " / " + (chessBoard[toX, toY] == " ").ToString());
            if (chessBoard[toX, toY] == " ")
            {
                return true;
            }

            return false;
        }

        private static bool canBeatFigure(String[,] chessBoard, int fromX, int fromY, int toX, int toY)
        {
            //Debug.Log(fromX + " " + fromY + " " + toX + " " + toY);
            return chessBoard[fromX, fromY][0] != chessBoard[toX, toY][0] && chessBoard[toX, toY][0] != '#' && chessBoard[toX, toY][0] != ' ';
        }

        public static List<PositionToMove> getHorseMove(string[,] chessBoard,int fromX, int fromY)
        {
            List<PositionToMove> result = new List<PositionToMove>();
            if (fromX + 2 < 10)
            {
                if (canMoveToPos(chessBoard, fromX + 2, fromY + 1) || canBeatFigure(chessBoard,fromX, fromY, fromX + 2, fromY + 1)) 
                    result.Add(new PositionToMove(fromX + 2, fromY + 1));
                if (canMoveToPos(chessBoard, fromX + 2, fromY - 1) || canBeatFigure(chessBoard,fromX, fromY, fromX + 2, fromY - 1)) 
                    result.Add(new PositionToMove(fromX + 2, fromY - 1));
            }
            if (fromX - 2 > 0)
            {
                if (canMoveToPos(chessBoard, fromX - 2, fromY + 1) || canBeatFigure(chessBoard,fromX, fromY, fromX - 2, fromY + 1)) 
                    result.Add(new PositionToMove(fromX - 2, fromY + 1));
                if (canMoveToPos(chessBoard, fromX - 2, fromY - 1) || canBeatFigure(chessBoard,fromX, fromY, fromX - 2, fromY - 1)) 
                    result.Add(new PositionToMove(fromX - 2, fromY - 1));
            }
            if (fromY + 2 < 10)
            {
                if (canMoveToPos(chessBoard, fromX + 1, fromY + 2) || canBeatFigure(chessBoard,fromX, fromY, fromX + 1, fromY + 2)) 
                    result.Add(new PositionToMove(fromX + 1, fromY + 2));
                if (canMoveToPos(chessBoard, fromX - 1, fromY + 2) || canBeatFigure(chessBoard,fromX, fromY, fromX - 1, fromY + 2)) 
                    result.Add(new PositionToMove(fromX - 1, fromY + 2));
            }
            if (fromY - 2 > 0)
            {
                if (canMoveToPos(chessBoard, fromX + 1, fromY - 2) || canBeatFigure(chessBoard,fromX, fromY, fromX + 1, fromY - 2)) 
                    result.Add(new PositionToMove(fromX + 1, fromY - 2));
                if (canMoveToPos(chessBoard, fromX - 1, fromY - 2) || canBeatFigure(chessBoard,fromX, fromY, fromX - 1, fromY - 2)) 
                    result.Add(new PositionToMove(fromX - 1, fromY - 2));
            }
            return result;
        }

        public static List<PositionToMove> getKingMove(string[,] chessBoard, int fromX, int fromY)
        {
            List<PositionToMove> result = new List<PositionToMove>();
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (canMoveToPos(chessBoard, fromX + i, fromY + j) || canBeatFigure(chessBoard, fromX, fromY, fromX + i, fromY + j))
                    {
                        result.Add(new PositionToMove(fromX + i, fromY + j));
                    }
                }
            }
            return result;
        }
    }
}