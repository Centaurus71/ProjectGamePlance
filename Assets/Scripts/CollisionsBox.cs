using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionsBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MarkerBomb")
        {
            Field.emptySpace.Add(transform.localPosition);
            Destroy(this.gameObject);
        }
    }
}
