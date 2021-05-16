using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolItem
{
    public GameObject prefab;
    public int amount;
    public bool expandable;
}


public class Pool : MonoBehaviour
{
    public static Pool singleton;

    //List of prefabs : 
    public List<PoolItem> items;

    //
    public List<GameObject> pooledItems;

    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
