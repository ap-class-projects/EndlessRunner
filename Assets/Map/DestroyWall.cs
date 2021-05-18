using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    public GameObject[] bricks;
    List<Rigidbody> bricksRB = new List<Rigidbody>();
    Collider mCollider;
    List<Vector3> positions = new List<Vector3>();
    List<Quaternion> rotations = new List<Quaternion>();
    private void Awake()
    {
        mCollider = this.GetComponent<Collider>();
        foreach(GameObject item in bricks)
        {
            bricksRB.Add(item.GetComponent<Rigidbody>());
            positions.Add(item.transform.localPosition);
            rotations.Add(item.transform.localRotation);
        }
    }

    private void OnEnable()
    {
        mCollider.enabled = true;
        for(int i = 0; i < bricks.Length; i++)
        {
            bricks[i].transform.localPosition = positions[i];
            bricks[i].transform.localRotation = rotations[i];
            bricksRB[i].isKinematic = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Spell")
        {
            mCollider.enabled = false;
            foreach(Rigidbody item in bricksRB)
            {
                item.isKinematic = false;
            }
        }
    }
}
