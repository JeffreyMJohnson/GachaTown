using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shelf : MonoBehaviour
{
    public GachaManager.Set CurrentSet
    {
        get { return _currentSet; }
        set
        {
            _currentSet = value;
            Material[] temp = _meshRenderer.materials;
            temp[SHELF_SET_MATERIAL] = _materials[(int) _currentSet];
            _meshRenderer.materials = temp;
            LoadGachas();
        }
    }

    private const int SHELF_SET_MATERIAL = 1;
    private const int MAX_GACHA_PER_SHELF = 9;
    private Material[] _materials;
    private MeshRenderer _meshRenderer;
    private GachaManager.Set _currentSet;
    private Transform[] _shelfPositions;
    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        Debug.Assert(_meshRenderer != null, "Could not find mesh renderer.");

        _materials = LoadMaterials();

        _shelfPositions = LoadGachaPositions();
    }

    private void Start()
    {
        CurrentSet = GachaManager.Set.SWEETS;
    }

    //ensure the loading is the same order as the gachamanager enum order.
    private Material[] LoadMaterials()
    {
        List<Material> result = new List<Material>();
        result.Add(Resources.Load<Material>("shelf/materials/city"));
        result.Add(Resources.Load<Material>("shelf/materials/spooky"));
        result.Add(Resources.Load<Material>("shelf/materials/sweets"));
        result.Add(Resources.Load<Material>("shelf/materials/tropical"));
        Debug.Assert(!result.Contains(null), "One or more shelf materials did not load.");
        return result.ToArray();
    }

    private Transform[] LoadGachaPositions()
    {
        List<Transform> result = new List<Transform>();
        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            if (child != gameObject.transform)
            {
                result.Add(child);
            }
        }
        return result.ToArray();
    }

    private void LoadGachas()
    {
        GachaSet current = GachaManager.Instance.GetGachaSet(CurrentSet);
        int gachaCount = Mathf.Min(current.collection.Count, MAX_GACHA_PER_SHELF);
        for (int i = 0; i < gachaCount; i++)
        {
            GameObject go = Instantiate<GameObject>(current.collection[i]);
           
            go.transform.position = _shelfPositions[i].position;
        }

    }

}
