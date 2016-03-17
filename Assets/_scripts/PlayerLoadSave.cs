using UnityEngine;
using System.IO;


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

    void SaveState()
    {
        StreamWriter writer = new StreamWriter(Application.dataPath + Constants.PLAYER_STATE_PATH);
        writer.Write(JsonUtility.ToJson(playerScript));
        writer.Close();
    }

    void LoadState()
    {
        if (!File.Exists(Application.dataPath + Constants.PLAYER_STATE_PATH))
        {
            return;
        }
        StreamReader reader = new StreamReader(Application.dataPath + Constants.PLAYER_STATE_PATH);

        JsonUtility.FromJsonOverwrite(reader.ReadToEnd(), playerScript);
        reader.Close();
    }
}
