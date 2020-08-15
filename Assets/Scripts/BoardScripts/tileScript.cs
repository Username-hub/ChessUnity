using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class tileScript : MonoBehaviour
    {
        private int posX, posY;
        private GameManager gameManager;
        public BoardScript boardScript;

        public void SetXY(int x, int y, GameManager gameManager)
        {
            posX = x;
            posY = y;
            this.gameManager = gameManager;
        }
        private void OnMouseDown()
        {
            //Debug.Log("Klik position: " + posX + " , " + posY);
            if (!gameManager.onPause)
            {
                if (gameManager.figureSelected)
                {
                    figureIsSelected();
                }
                else
                {
                    figureNotSelected();
                }
            }
        }
        
        
        private void figureNotSelected()
        {
            //Get figure
            gameManager.cureentSelect = gameManager.getFigureOnPosition(posX, posY);
            //Debug.Log(cureentSelect);
            if (gameManager.cureentSelect != null)
            {
                //Check color
                if (gameManager.cureentSelect.color == gameManager.nowTurn)
                {
                    //check position to move
                    gameManager.positionToMoves = gameManager.cureentSelect.getPositionsToMove(boardScript.chessBoardString);
                    if (gameManager.positionToMoves.Count > 0)
                    {
                        gameManager.figureSelected = true;
                            boardScript.ToMoveVisualizer.toMoveSprites = boardScript.ToMoveVisualizer.createToMoveSprite(gameManager.positionToMoves);
                    }
                }
            }
        }
        
        private void figureIsSelected()
        {
            PositionToMove positionToMoveTile = getPressedPositionToMove(posX, posY);
            if (positionToMoveTile != null)
            {
                FigureMoveScript.makeMove(posX, posY, boardScript, gameManager);
            }
            FigureMoveScript.UnselectFigure(gameManager, boardScript);
            
        }
        
        private PositionToMove getPressedPositionToMove(int posX, int posY)
        {
            foreach (var x in gameManager.positionToMoves)
            {
                if (x.posX == posX && x.posY == posY)
                {
                    return x;
                }
            }
            return null;
        }
    }
}