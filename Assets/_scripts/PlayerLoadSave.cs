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
        StreamWriter writer = new StreamWriter(Application.dataPath + Constants.PLAYER_STATE_PATH);
        string s = JsonUtility.ToJson(playerScript);
        writer.Write(JsonUtility.ToJson(playerScript));
        writer.Close();
    }

    public void LoadState()
    {
        if (!File.Exists(Application.dataPath + Constants.PLAYER_STATE_PATH))
        {
            return;
        }

        StreamReader reader = new StreamReader(Application.dataPath + Constants.PLAYER_STATE_PATH);

        JsonUtility.FromJsonOverwrite(reader.ReadToEnd(), playerScript);
        reader.Close();
        playerScript.LoadCollection();
    }
}
