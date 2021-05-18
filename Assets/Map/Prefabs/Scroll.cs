using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    private void FixedUpdate()
    {
        this.transform.position += AstroController.player.transform.forward * -0.16f;
        if(AstroController.currentPlatfrom == null)
        {
            return;
        }
        if(AstroController.currentPlatfrom.tag == "stairsUp")
        {
            this.transform.Translate(0, -0.06f, 0);
        }
        if (AstroController.currentPlatfrom.tag == "stairsUp")
        {
            this.transform.Translate(0, 0.06f, 0);
        }
    }
}
