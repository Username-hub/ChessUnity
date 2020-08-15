using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public static class SaveSystemScript
    {
        public static void SaveGame(SaveDataClass saveDataClass, string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + fileName + ".chess";
            FileStream stream = new FileStream(path, FileMode.Create);
            
            formatter.Serialize(stream, saveDataClass);
            stream.Close();
            
            string imagePath = Application.persistentDataPath + fileName + ".png";
            FileStream imgStream = new FileStream(imagePath, FileMode.Create);
            ScreenCapture.CaptureScreenshot(imagePath);
            imgStream.Close();
            

        }

        public static SaveDataClass LoadGame(string fileName)
        {
            string path = Application.persistentDataPath + fileName;

            if (File.Exists(path))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                SaveDataClass saveDataClass = binaryFormatter.Deserialize(stream) as SaveDataClass;

                stream.Close();
                return saveDataClass;
            }
            else
            {
                return null;
            }
        }
    }
}