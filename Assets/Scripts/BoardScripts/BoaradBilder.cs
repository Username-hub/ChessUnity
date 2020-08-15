using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class BoaradBilder : MonoBehaviour
    {
        public BoardScript boardScript;
        public GameManager gameManager;
        public void createBoard(int width, int heigth, GameObject blackTile, GameObject whiteTile)
        {
            int counter = 1;
            for (int i = width; i > 0; i--)
            {
                for (int j = 1; j <= heigth; j++)
                {
                    if ((counter - i) % 2 == 0)
                    {
                        createTile(blackTile, i, j);
                    }
                    else
                    {
                        createTile(whiteTile, i, j);
                    }

                    counter++;
                }
            }
        }
        
        private void createTile(GameObject tile, int i, int j)
        {
            GameObject created = Instantiate(tile, new Vector3(transform.position.x + i, transform.position.y + j, 0),
                Quaternion.identity);
            tileScript tileScript = created.GetComponent<tileScript>();
            tileScript.boardScript = boardScript;
            tileScript.SetXY(i, j, gameManager);
            //TODO: remove after debuging
            //DebugText
            /*
            GameObject textDeb = new GameObject("TileAt:" + i + "/" + j);
            Instantiate(textDeb);
            textDeb.transform.parent = created.transform;
            textDeb.transform.position = created.transform.position;
            textDeb.transform.rotation = created.transform.rotation;
            TextMeshPro textMesh = textDeb.AddComponent<TextMeshPro>();
            textMesh.text = (i + "," + j).ToString();
            textMesh.color = Color.magenta;
            textMesh.fontSize = 4.0f;
            RectTransform rectTransform = textDeb.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(1, 1);
            rectTransform.eulerAngles = new Vector3(0, 0, 180);
            boardScript.debugTextList.Add(textMesh);*/
        }
    }
    
    
}