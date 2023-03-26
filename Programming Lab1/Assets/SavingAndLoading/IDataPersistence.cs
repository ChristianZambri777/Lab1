using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistence 
{
    void LoadData(PlayerSaveData data);

    void SaveData(ref PlayerSaveData data);
}
