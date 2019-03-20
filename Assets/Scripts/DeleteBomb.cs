using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBomb : MonoBehaviour
{

    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
        Bomb.listBomb.RemoveAt(0);
    }

    void Start()
    {
        StartCoroutine(enumerator());
    }
}
