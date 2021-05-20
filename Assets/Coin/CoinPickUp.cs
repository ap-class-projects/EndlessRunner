using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    MeshRenderer[] meshRenderers;

    private void Start()
    {
        meshRenderers = this.GetComponentsInChildren<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "AstroDude")
        {
            GameData.singleton.updateScore(10);
            foreach(MeshRenderer item in meshRenderers)
            {
                item.enabled = false;
            }
        }
    }

    private void OnEnable()
    {
        if(meshRenderers != null)
        {
            foreach (MeshRenderer item in meshRenderers)
            {
                item.enabled = true;
            }
        }
    }
}
