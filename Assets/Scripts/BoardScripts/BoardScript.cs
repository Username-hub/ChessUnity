using System;
using System.Collections;
using System.Collections.Generic;
using BlackFigureScripts;
using DefaultNamespace;
using DefaultNamespace.BlackFigureScripts;
using TMPro;
using UnityEngine;

public class BoardScript : MonoBehaviour
{
    
    private int width = 8;
    private int heigth = 8;

    public GameManager gameManager;
    public FigureBox figureBox;
    public GameObject whiteTile;
    public GameObject blackTile;
    public GameObject toMoveSprite;

    public string[,] chessBoardString;/* = new string[,]
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
    };*/

    public MoveRecorder moveRecorder;
    public void moveFigureOnBoard(int fromX, int fromY, int toX, int toY)
    {
        chessBoardString[toX, toY] = chessBoardString[fromX, fromY];
        chessBoardString[fromX, fromY] = " ";
        //updateDebugText();
    }

    public ToMoveVisualizer ToMoveVisualizer;
    private MoveTracker moveTracker;
    private void Start()
    {
        chessBoardString = new string[width,heigth];
        chessBoardString = StaticBoard.chessBoardString.Clone() as string[,];
        
        createBoarad();
        
        placeFigures();
        
        //updateDebugText();
        
        moveRecorder = new MoveRecorder(gameManager, this);
        moveRecorder.addInRange(StaticBoard.MoveRecords);

        ToMoveVisualizer = this.gameObject.AddComponent<ToMoveVisualizer>();
        ToMoveVisualizer.toMoveSprite = toMoveSprite;

        moveTracker = GetComponent<MoveTracker>();
        moveTracker.InitializeToMoveTracker();
    }

    //public List<TextMeshPro> debugTextList = new List<TextMeshPro>();
    private void createBoarad()
    {
        GameObject boaradBilderGameObject = new GameObject("BoardBilder");
        Instantiate(boaradBilderGameObject, transform);
        BoaradBilder boaradBilder = boaradBilderGameObject.AddComponent<BoaradBilder>();
        boaradBilder.boardScript = this;
        boaradBilder.gameManager = gameManager;
        boaradBilder.createBoard(width, heigth, blackTile, whiteTile);
    }

    /*private void updateDebugText()
    {
        foreach (var x in debugTextList)
        {
            int posX = (int) x.gameObject.transform.position.x;
            int posY = (int) x.gameObject.transform.position.y;
            x.text = ( posX.ToString() + " , " + posY.ToString() + "\n" + chessBoardString[posX,posY]);
        }
    }*/
    
    public KingScript whiteKing;
    public KingScript blackKing;
    public FigurePlacer figurePlacer;
    private void placeFigures()
    {
        GameObject figurePlacerGameObject = new GameObject("FigurePlacer");
        Instantiate(figurePlacerGameObject, transform);
        FigurePlacer figurePlacerScript = figurePlacerGameObject.AddComponent<FigurePlacer>();
        figurePlacerScript.boardScript = this;
        figurePlacerScript.gameManager = gameManager;
        figurePlacerScript.figureBox = figureBox;
        figurePlacerScript.placeFigures(width, heigth, chessBoardString);
        figurePlacer = figurePlacerScript;
    }

    public void UpdateMoveTracker()
    {
        moveTracker.UpdateMoveTracker(moveRecorder.getLastRecord());
    }
}
