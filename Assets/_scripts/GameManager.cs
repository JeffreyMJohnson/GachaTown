using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class GameManager : MonoBehaviour
{
    public List<string> masterPathList = null;

    Transform playerTransform;

    void Start()
    {
        masterPathList = new List<string>();
        DirectoryInfo dir = new DirectoryInfo(Application.dataPath + "/Resources/" + Constants.GACHA_PATH);
        FileInfo[] info = dir.GetFiles("*.prefab");

        int count = 0;
        foreach (FileInfo f in info)
        {
            masterPathList.Add(f.Name);
            Debug.Log(f.Name);
            count++;
        }
        Debug.Log(string.Format("{0} prefab files in directory {1}", count, dir.Name));

        playerTransform = GetComponentInChildren<Player>().transform;
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public string GetRandomGacha()
    {
        int randomIndex = Random.Range(0, masterPathList.Count - 1);
        return masterPathList[randomIndex];
       
    }
}
