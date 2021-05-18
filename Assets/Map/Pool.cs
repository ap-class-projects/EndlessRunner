using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolItem
{
    //prefabs and more
    public GameObject prefab;
    public int amount;
    public bool expandable;
}


public class Pool : MonoBehaviour
{
    public static Pool singleton;

    //List of prefabs : 
    public List<PoolItem> items;
    
    public List<GameObject> pooledItems;

    private void Awake()
    {
        singleton = this;

        //before generate world
        pooledItems = new List<GameObject>();
        foreach (PoolItem item in items)
        {
            for (int i = 0; i < item.amount; i++)
            {
                GameObject gameObject = Instantiate(item.prefab);
                gameObject.SetActive(false);
                pooledItems.Add(gameObject);
            }
        }
    }

    public GameObject getRandom()
    {
        //shuffle for randomizing
        pooledItems.shuffle();
        

        for(int i = 0; i < pooledItems.Count; i++)
        { 
            if(!pooledItems[i].activeInHierarchy)
            {
                return pooledItems[i];
            }
        }
        
        foreach(PoolItem item in items)
        {
            if(item.expandable)
            {
                GameObject gameObject = Instantiate(item.prefab);
                gameObject.SetActive(false);
                pooledItems.Add(gameObject);
                return gameObject;
            }
        }

        return null;
    }
}

public static class Utils
{
    public static System.Random random = new System.Random();
    public static void shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while(n > 1)
        {
            n--;
            int k = random.Next(n+1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}