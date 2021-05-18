using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    bool deactivateScheduled = false;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "AstroDude" && !deactivateScheduled)
        {
            Invoke("SetInactive", 6.0f);
            deactivateScheduled = true;
        }
    }

    void SetInactive()
    {
        this.gameObject.SetActive(false);
        deactivateScheduled = false;
    }
}
