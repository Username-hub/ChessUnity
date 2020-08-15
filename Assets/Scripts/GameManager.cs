using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        //1 - white turn; -1 - black turn;
        public BoardScript boardScript;
        public bool figureSelected = false;
        public int nowTurn = 1;

        private List<FigureBase> figureOnBoard = new List<FigureBase>();
        
        public FigureBase cureentSelect;
        public List<PositionToMove> positionToMoves = new List<PositionToMove>();


        private void Start()
        {
            nowTurn = StaticBoard.nowTurn;
        }

        public void endOfTurn()
        {
            nowTurn *= -1;
        }

        public void addFigure(FigureBase figure)
        {
            figureOnBoard.Add(figure);
        }

        public void removeFigure(int x, int y)
        {
            int len = figureOnBoard.Count;
            for (int i = 0; i < len; i++)
            {
                if (figureOnBoard[i].posX == x && figureOnBoard[i].posY == y)
                {
                    Destroy(figureOnBoard[i].gameObject);
                    figureOnBoard.RemoveAt(i);
                    break;
                }
            }
        }

        public void moveFigure(int oldX, int oldY, int newX, int newY)
        {
            //Check if figure is beaten
            removeFigure(newX, newY);
            
            int len = figureOnBoard.Count;
            //Move figure
            for (int i = 0; i < len; i++)
            {
                if (figureOnBoard[i].posX == oldX && figureOnBoard[i].posY == oldY)
                {
                    figureOnBoard[i].chengeFigPosition(new Vector2(boardScript.transform.position.x + newX,
                        boardScript.transform.position.y + newY), newX, newY);
                    break;
                }
            }
        }

        public FigureBase getFigureOnPosition(int x, int y)
        {
            int len = figureOnBoard.Count;
            for (int i = 0; i < len; i++)
            {
                if (figureOnBoard[i].posX == x && figureOnBoard[i].posY == y)
                    return figureOnBoard[i];
            }
            return null;
        }

        public List<FigureBase> getFigureByColor(int color)
        {
            List<FigureBase> result = new List<FigureBase>();
            foreach (var x in figureOnBoard)
            {
                if(x.color == color)
                    result.Add(x);
            }
            return result;
        }

        public void UndoMove()
        {
            FigureMoveScript.UnselectFigure(this, boardScript);
            FigureMoveScript.undoMove(boardScript, this);
        }

        [NonSerialized]
        public bool onPause = false;
        
    }
}