using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class LoadMenuScript : MonoBehaviour
    {
        private PauseMenuScript pauseMenuScript;

        private void Start()
        {
            pauseMenuScript = GetComponent<PauseMenuScript>();
        }

        public GameObject PauseMenu;
        public GameObject LoadMenu;

        public Image saveImg1;
        public void ToLoadMenu()
        {
            PauseMenu.SetActive(false);
            LoadMenu.SetActive(true);
        }

        public void ToPauseMenu()
        {
            LoadMenu.SetActive(false);
            PauseMenu.SetActive(true);
        }
        public void LoadGame(string fileName)
        {
            SaveDataClass saveDataClass = SaveSystemScript.LoadGame(fileName);
            StaticBoard.chessBoardString = saveDataClass.chessBoard.Clone() as string[,];
            StaticBoard.nowTurn = saveDataClass.nowMove;
            StaticBoard.MoveRecords.AddRange(saveDataClass.moveRecords);
            SceneManager.LoadScene("MainGameScene");
        }

        private void LoadImages()
        {
            Sprite image1 = LoadImageByName("save1.png");
            saveImg1.sprite = image1;
        }

        private Sprite LoadImageByName(string fileName)
        {
            string path = Application.persistentDataPath + fileName;

            if (File.Exists(path))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                Sprite image = binaryFormatter.Deserialize(stream) as Sprite;

                stream.Close();
                return image;
            }
            else
            {
                return null;
            }
        }
    }
}