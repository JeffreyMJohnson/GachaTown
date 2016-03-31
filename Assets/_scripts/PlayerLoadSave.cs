using UnityEngine;
using System.IO;

/// <summary>
/// This script takes care of loading the game state from file on startup and saving on quit.
/// </summary>
class PlayerLoadSave : MonoBehaviour
{
    Player playerScript;

    void Start()
    {
        playerScript = GetComponent<Player>();
        Debug.Assert(playerScript != null, "Did not find Player script.");
        LoadState();
    }

    void OnDestroy()
    {
        SaveState();
    }

    public void SaveState()
    {
        if(playerScript == null)
        {
            playerScript = GetComponent<Player>();
        }
        //clear the gameobject collection to load from the data collection at player load.
        playerScript.gachaCollection.Clear();

        StreamWriter writer = new StreamWriter(Application.persistentDataPath + Constants.PLAYER_STATE_PATH);
        string s = JsonUtility.ToJson(playerScript);
        writer.Write(JsonUtility.ToJson(playerScript));
        writer.Close();
    }

    public void LoadState()
    {
        string filePath = Application.persistentDataPath + Constants.PLAYER_STATE_PATH;
        if (!File.Exists(filePath))
        {
            return;
        }

        StreamReader reader = new StreamReader(filePath);

        JsonUtility.FromJsonOverwrite(reader.ReadToEnd(), playerScript);
        reader.Close();

        //fix for bad state file... should not ship with this code!!
        if (playerScript.BadCollectionLoaded())
        {
            File.Delete(filePath);
        }
        playerScript.LoadCollection();
    }
}
