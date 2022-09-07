using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

/*The second of two key classes that form the save and loading system in the project. FileDataManager
 * objects can be used to carry out the below methods in the context of the DataPersistanceManager script.*/
public class FileDataManager 
{
    private string dataPath;

    private string fileName;

    /*A constructor initialising dataPath and fileName variables. */
    public FileDataManager(string dataPath, string fileName) { 
    
    this.dataPath = dataPath;
        this.fileName = fileName;
    
    }

    /*The load method accesses a file path that has previously been created via the save method.
     The method first checks if the path exists, and if so uses a try catch block to access
    the data via a filestream and Unity's JsonUtility. */
    public GameData Load(string userId) {

        string fullPath = Path.Combine(dataPath, userId, fileName);
        GameData loadedData = null;
        if (File.Exists(fullPath)) {
            try
            {

                string loadingData = "";
                using (FileStream fileStream = new FileStream(fullPath, FileMode.Open))
                {


                    StreamReader reader = new StreamReader(fileStream);
                    loadingData = reader.ReadToEnd();
                }

                loadedData = JsonUtility.FromJson<GameData>(loadingData);
            }

            catch { }



        }

        return loadedData;

    }

    /*The save method creates a file path for the user's data to be saved, making of Unity's
     Json utility, with the FileMode set to create, and a streamwriter to write the data. */
    public void Save(GameData data, string userId) { 
    
        
        string fullPath = Path.Combine(dataPath, userId, fileName); 
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            string dataStore = JsonUtility.ToJson(data, true);

            using (FileStream fileStream = new FileStream(fullPath, FileMode.Create)) {


                using (StreamWriter writer = new StreamWriter(fileStream)) {

                    writer.Write(dataStore);
                }
            }

        }

        catch
        {

            Debug.LogError("Error Saving File");
        }
    }

    
    
   
}

/*<!--Number Planet - FileDataManager
@Author: Julian Laffin, see References -->*/
