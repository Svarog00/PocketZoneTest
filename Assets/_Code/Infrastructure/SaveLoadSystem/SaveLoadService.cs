﻿using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assets._Code.Infrastructure.SaveLoadSystem
{
    public class SaveLoadService : ISaveLoadService
    {
        private readonly string SaveDirectoryPath = Application.dataPath + "/Saves";
        private readonly string HandleSaveDirectoryPath = Application.dataPath + "/Saves/Handle_Save.sv";

        public SaveLoadService()
        {

        }

        public void SaveData(string name, WorldData worldData) //Параметр название сейва для разделения сохранений на чекпоинты и переходы между сценами
        {
            if (!Directory.Exists(SaveDirectoryPath)) //if directory doesn't exist 
            {
                Directory.CreateDirectory(SaveDirectoryPath); //then create directory
            }

            FileStream fs = new FileStream(Application.dataPath + "/Saves/" + name + ".sv", FileMode.Create); //open stream to create a save file
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, worldData); //serialize savedData in fs file
            fs.Close(); //close file stream

            Debug.Log("Saved: HP - " + worldData.Health + "; position - " + worldData.x + " " + worldData.y + "; scene - ");

        }

        public WorldData LoadData(string name) //LevelMove = player move berween scenes //Handle_Save = player died
        {
            if (File.Exists(Application.dataPath + "/Saves/" + name + ".sv"))
            {
                FileStream fs = new FileStream(Application.dataPath + "/Saves/" + name + ".sv", FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    WorldData tmp = (WorldData)formatter.Deserialize(fs);
                    return tmp;
                }
                catch (System.Exception Error)
                {
                    Debug.Log(Error.Message);
                    return null;
                }
                finally
                {
                    fs.Close();
                }
            }
            return null;
        }

        public void ClearSaves()
        {
            if (Directory.Exists(Application.dataPath + "/Saves"))
            {
                var dirInfo = new DirectoryInfo(Application.dataPath + "/Saves");
                foreach (var file in dirInfo.GetFiles())
                {
                    if (file.FullName == "Handle_Save")
                        continue;
                    file.Delete();
                }
            }
        }
    }
}