using System;
using UnityEditor.Purchasing;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class SaveMenuScript : MonoBehaviour
    {
        private PauseMenuScript pauseMenuScript;

        private void Start()
        {
            pauseMenuScript = GetComponent<PauseMenuScript>();
        }

        public GameObject PauseMenu;
        public GameObject SaveMenu;

        public void ToSaveMenu()
        {
            PauseMenu.SetActive(false);
            SaveMenu.SetActive(true);
        }

        public void ToPauseMenu()
        {
            SaveMenu.SetActive(false);
            PauseMenu.SetActive(true);
        }
        public void SaveGame(string fileName)
        {
            //TODO: ChangeAfterDebug
            //SaveDataClass saveDataClass = new SaveDataClass(pauseMenuScript.BoardScript.chessBoardString, pauseMenuScript.gameManager.nowTurn,
            //    pauseMenuScript.BoardScript.moveRecorder.GetRecordList());
            SaveDataClass saveDataClass = new SaveDataClass(pauseMenuScript.BoardScript.chessBoardString, pauseMenuScript.gameManager.nowTurn, 
                pauseMenuScript.BoardScript.moveRecorder.GetRecordList());
            SaveSystemScript.SaveGame(saveDataClass, fileName);
        }

        private void loadImeges()
        {
            
        }
    }
}