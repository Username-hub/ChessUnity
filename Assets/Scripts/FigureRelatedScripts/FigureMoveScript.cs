using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public static class FigureMoveScript
    {
        private static void MoveFigure(int posXtoMove, int posYtoMove, BoardScript boardScript, GameManager gameManager)
        {
        
            boardScript.moveFigureOnBoard(gameManager.cureentSelect.posX,gameManager.cureentSelect.posY, posXtoMove, posYtoMove);
            gameManager.moveFigure(gameManager.cureentSelect.posX,gameManager.cureentSelect.posY, posXtoMove, posYtoMove);
            
        }
        
        public static void undoMove(BoardScript boardScript, GameManager gameManager)
        {
            MoveRecord moveRecord = boardScript.moveRecorder.getLastRecord();
        
            //moveFigueOnBoard
            gameManager.cureentSelect = gameManager.getFigureOnPosition(moveRecord.toX, moveRecord.toY);
            MoveFigure(moveRecord.fromX, moveRecord.fromY, boardScript, gameManager);
            gameManager.cureentSelect.firstMove = moveRecord.firstMove;
            //CreateFigureIfBeaten
            if (moveRecord.moveTo != " ")
            {
                boardScript.chessBoardString[moveRecord.toX, moveRecord.toY] = moveRecord.moveTo;
                boardScript.figurePlacer.figreSet(moveRecord.toX, moveRecord.toY, moveRecord.firstMove, boardScript.chessBoardString);
            }
            boardScript.moveRecorder.deleteLastRecord();
        }

        public static void makeMove(int posXtoMove, int posYtoMove, BoardScript boardScript, GameManager gameManager)
        {
            boardScript.moveRecorder.recordMove(posXtoMove, posYtoMove);
            MoveFigure(posXtoMove, posYtoMove, boardScript, gameManager);

            if (isCheck(gameManager, boardScript)) 
            {
                undoMove(boardScript, gameManager); 
            }
            else
            { 
                boardScript.UpdateMoveTracker();
                gameManager.endOfTurn();
            }

            if (isCheck(gameManager, boardScript))
            {
                if(checkIfCheckMate(boardScript, gameManager))
                    Debug.Log("Mate");
                else
                {
                    Debug.Log("Check");
                }
            }
        }

        public static void UnselectFigure(GameManager gameManager, BoardScript boardScript)
        {
            gameManager.figureSelected = false;
            boardScript.ToMoveVisualizer.destroyToMoveObjects();
            gameManager.positionToMoves.Clear();
        }

        private static void MakePseudoMove(int posXtoMove, int posYtoMove, BoardScript boardScript,
            GameManager gameManager)
        {
            boardScript.moveRecorder.recordMove(posXtoMove, posYtoMove);
            MoveFigure(posXtoMove, posYtoMove, boardScript, gameManager);
            gameManager.figureSelected = false;
            
        }
        private static bool checkIfCheckMate(BoardScript boardScript, GameManager gameManager)
        {
            bool result = true;
            foreach (var figureBase in gameManager.getFigureByColor(gameManager.nowTurn))
            {
                gameManager.cureentSelect = figureBase;
                List<PositionToMove> positionToMoves = figureBase.getPositionsToMove(boardScript.chessBoardString);
                foreach (var positionToMove in positionToMoves)
                {
                    MakePseudoMove(positionToMove.posX, positionToMove.posY, boardScript, gameManager);
                    if (!isCheck(gameManager, boardScript))
                    {
                        result = false;
                    }
                    undoMove(boardScript, gameManager);
                    if(!result) break;
                }
                
                if(!result) break;
                
            }

            gameManager.cureentSelect = null;
            return result;
        }
        
        public static bool isCheck(GameManager gameManager, BoardScript boardScript)
        {
            List<FigureBase> figure = gameManager.getFigureByColor(gameManager.nowTurn * -1);
            List<PositionToMove> positionToMoves = new List<PositionToMove>();
            foreach (var x in figure)
            {
                positionToMoves.AddRange(x.getPositionsToMove(boardScript.chessBoardString));
            }

            if (gameManager.nowTurn == 1)
            {
                foreach (var x in positionToMoves)
                {
                    if (x.posX == boardScript.whiteKing.posX && x.posY == boardScript.whiteKing.posY)
                    {
                        return true;
                    }
                }
            }
            else
            {
                foreach (var x in positionToMoves)
                {
                    if (x.posX == boardScript.blackKing.posX && x.posY == boardScript.blackKing.posY)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        
    }
}