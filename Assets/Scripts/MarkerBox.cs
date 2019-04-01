using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            DeleteBomb.statusCollisions = true;
            print("Есть контакт " + DeleteBomb.statusCollisions);
        }
    }
}
