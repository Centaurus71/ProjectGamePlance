using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainsSpeed : MonoBehaviour
{
    public GameObject Light;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Instantiate(Light, new Vector3(0, 11, 11), Quaternion.identity);
            Light.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
