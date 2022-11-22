using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallLifeSpan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WallDestroy());
    }

    IEnumerator WallDestroy()
    {

        yield return new WaitForSeconds(7f);
        Destroy(this.gameObject);

    }
}
