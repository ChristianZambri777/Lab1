using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler : MonoBehaviour
{
    private string dataDirPath = "";
    private string dataFileName = "";

    private bool useEncyption = false;

    private readonly string encryptionCodeWord = "apple";

    public FileDataHandler(string dataDirPath, string dataFileName, bool useEncryption)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
        this.useEncyption = useEncryption;
    }

    public PlayerSaveData Load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        PlayerSaveData loadedData = null;
        if(File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                if (useEncyption)
                {
                    dataToLoad = EncryptDecrypt(dataToLoad);
                }


                loadedData = JsonUtility.FromJson<PlayerSaveData>(dataToLoad);
            }
            catch(Exception e)
            {
                Debug.LogError("Error occured");
            }
        }

        return loadedData;
    }

    public void Save (PlayerSaveData data)
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string dataToStore = JsonUtility.ToJson(data, true);

            if(useEncyption)
            {
                dataToStore = EncryptDecrypt(dataToStore);
            }

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }

        }
        catch(Exception e)
        {
            Debug.LogError("File issue");
        }
    }

    private string EncryptDecrypt (string data)
    {
        string modifiedData = "";
        for(int i = 0; i < data.Length; i++)
        {
            modifiedData += (char)(data[i] ^ encryptionCodeWord[i % encryptionCodeWord.Length]);
        }

        return modifiedData;
    }
}
