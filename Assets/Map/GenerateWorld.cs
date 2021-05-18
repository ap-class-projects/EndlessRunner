using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorld : MonoBehaviour
{
    public static GameObject dummyTraveller;
    public static GameObject lastPlatform;

    void Awake()
    {
        dummyTraveller = new GameObject("dummy");
        lastPlatform = null;
    }

    public static void runDummy()
    {
        GameObject platform = Pool.singleton.getRandom();
        if(platform == null)
        {
            return;
        }

        if(lastPlatform != null)
        {
            if(lastPlatform.tag == "platformTSection")
            {
                dummyTraveller.transform.position = lastPlatform.transform.position + AstroController.player.transform.forward * 20;
            }
            else
            {
                dummyTraveller.transform.position = lastPlatform.transform.position + AstroController.player.transform.forward * 10;
            }

            if (lastPlatform.tag == "stairsUp")
            {
                dummyTraveller.transform.Translate(0, 5, 0);
            }
        }

        lastPlatform = platform;
        platform.SetActive(true);
        platform.transform.position = dummyTraveller.transform.position;
        platform.transform.rotation = dummyTraveller.transform.rotation;

        if (platform.tag == "stairsDown")
        {
            dummyTraveller.transform.Translate(0, -5, 0);
            platform.transform.Rotate(0, 180, 0);
            platform.transform.position = dummyTraveller.transform.position;
        }
    }
    //for (int i = 0; i < 200; i++)
    //{
    //    GameObject p = Pool.singleton.getRandom();
    //    if(p == null)
    //    {
    //        return;
    //    }
    //    p.SetActive(true);
    //    p.transform.position = dummyTraveller.transform.position;
    //    p.transform.rotation = dummyTraveller.transform.rotation;

    //    if (p.tag == "stairsUp")
    //    {
    //        dummyTraveller.transform.Translate(0, 5, 0);
    //    }
    //    else if (p.tag == "stairsDown")
    //    {
    //        p.transform.Rotate(0, 180, 0);
    //        p.transform.Translate(0, -5, 0);
    //        dummyTraveller.transform.position = p.transform.position;
    //    }
    //    else if (p.tag == "platformTSection")
    //    {
    //        if (Random.Range(0, 2) == 0)
    //        {
    //            dummyTraveller.transform.Rotate(0, 90, 0);
    //        }
    //        else
    //        {
    //            dummyTraveller.transform.Rotate(0, -90, 0);
    //        }
    //        dummyTraveller.transform.Translate(Vector3.forward * -10);
    //    }
    //    dummyTraveller.transform.Translate(Vector3.forward * -10);
    //}
}
