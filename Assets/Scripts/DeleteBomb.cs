using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBomb : MonoBehaviour
{
    public static bool statusCollisions = false;
    Vector3 vectorZ = new Vector3(0, 0, 11);
    Vector3 vectorX = new Vector3(11, 0, 0);
    Vector3 vestorBomb;
    LoadObject loadObject = new LoadObject();

    IEnumerator enumerator()
    {
        vestorBomb = transform.localPosition;
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
        LoadMarker(vestorBomb, Operation.Add, vectorZ);
        LoadMarker(vestorBomb, Operation.Compute, vectorZ);
        LoadMarker(vestorBomb, Operation.Add, vectorX);
        LoadMarker(vestorBomb, Operation.Compute, vectorX);
        Bomb.listBomb.RemoveAt(0);
    }

    void Start()
    {
        StartCoroutine(enumerator());
    }
    void LoadMarker(Vector3 vestorBomb, Operation op, Vector3 vectorDirection)
    {
        GameObject marker = loadObject.LoadMarkerBomb();
        if (op == Operation.Add)
        {
            for (int i = 0; i < 2; i++)
            {
                if (statusCollisions == true) break;
                vestorBomb += vectorDirection;
                Instantiate(marker, vestorBomb, Quaternion.identity);
            }
            statusCollisions = false;
        }
        if (op == Operation.Compute)
        {
            for (int i = 0; i < 2; i++)
            {
                if (statusCollisions == true) break;
                vestorBomb -= vectorDirection;
                Instantiate(marker, vestorBomb, Quaternion.identity);
            }
            statusCollisions = false;
        }
    }
}
