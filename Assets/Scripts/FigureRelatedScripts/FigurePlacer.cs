using DefaultNamespace;
using DefaultNamespace.BlackFigureScripts;
using UnityEngine;

namespace BlackFigureScripts
{
    public class FigurePlacer : MonoBehaviour
    {
        public BoardScript boardScript;
        public GameManager gameManager;
        public FigureBox figureBox;
        public void placeFigures(int width, int heigth, string[,] chessBoardString)
        {
            for (int i = width; i > 0; i--)
            {
                for (int j = 1; j <= heigth; j++)
                {
                    figreSet(i, j, true, chessBoardString);
                }
            }
        }

        public void figreSet(int i, int j, bool firstMove, string[,] chessBoardString)
        {
            switch (chessBoardString[i, j])
            {
                //white
                case "WP":
                    gameManager.addFigure(CreateFigure(figureBox.whitePown, j, i, 1, firstMove));
                    break;
                case "WR":
                    gameManager.addFigure(CreateFigure(figureBox.whiteRook, j, i, 1, firstMove));
                    break;
                case "WH":
                    gameManager.addFigure(CreateFigure(figureBox.whiteHorse, j, i, 1, firstMove));
                    break;
                case "WB":
                    gameManager.addFigure(CreateFigure(figureBox.whiteBishop, j, i, 1, firstMove));
                    break;
                case "WK":
                    FigureBase wk = CreateFigure(figureBox.whiteKing, j, i, 1, firstMove);
                    gameManager.addFigure(wk);
                    boardScript.whiteKing = (KingScript) wk;
                    break;
                case "WQ":
                    gameManager.addFigure(CreateFigure(figureBox.whiteQueen, j, i, 1, firstMove));
                    break;
                //black
                case "BP":
                    gameManager.addFigure(CreateFigure(figureBox.blackPown, j, i, -1, firstMove));
                    break;
                case "BR":
                    gameManager.addFigure(CreateFigure(figureBox.blackRook, j, i, -1, firstMove));
                    break;
                case "BH":
                    gameManager.addFigure(CreateFigure(figureBox.blackHorse, j, i, -1, firstMove));
                    break;
                case "BB":
                    gameManager.addFigure(CreateFigure(figureBox.blackBishop, j, i, -1, firstMove));
                    break;
                case "BK":
                    FigureBase bk = CreateFigure(figureBox.blackKing, j, i, -1, firstMove);
                    gameManager.addFigure(bk);
                    boardScript.blackKing = (KingScript) bk;
                    break;
                case "BQ":
                    gameManager.addFigure(CreateFigure(figureBox.blackQueen, j, i, -1, firstMove));
                    break;
            }
        }
        
        private FigureBase CreateFigure(GameObject figure, int y, int x, int color, bool firstMove)
        {
            GameObject created = Instantiate(figure, new Vector3(transform.position.x + x , transform.position.y + y , 0),
                Quaternion.identity);
            Transform transformObj = created.transform;
            transformObj.eulerAngles = new Vector3(0, 0, 180.0f);
            FigureBase figureBase = created.GetComponent<FigureBase>();
            figureBase.posX = x;
            figureBase.posY = y;
            figureBase.color = color;
            figureBase.firstMove = firstMove;
            return figureBase;
        }

    }
}