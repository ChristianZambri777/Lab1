using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class DataManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;


    private PlayerSaveData data;
    private List<IDataPersistence> dataPersistencesObjects;

    private FileDataHandler dataHandler;
        

    public static DataManager instance { get; private set; }

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than 1");
        }

        instance = this;
    }

    private void Start()
    {
        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName); 
        dataPersistencesObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        data = new PlayerSaveData();
    }

    public void LoadGame()
    {
        data = dataHandler.Load();
        if(data == null)
        {
            NewGame(); 
        }

        foreach (IDataPersistence dataPersistenceObjects in dataPersistencesObjects)
        {
            dataPersistenceObjects.LoadData(data);
        }
    }

    public void SaveGame()
    {
        foreach (IDataPersistence dataPersistenceObjects in dataPersistencesObjects)
        {
            dataPersistenceObjects.SaveData(ref data);
        }

        dataHandler.Save(data);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }


    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistencesObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistencesObjects);
    }
}
