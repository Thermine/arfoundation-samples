using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogs : MonoBehaviour
{

    public void Start()
    {
        StartCoroutine(Destroying());
    }

    IEnumerator Destroying()
    {
        yield return new WaitForSeconds(4f);
        Destroy(this.gameObject);
    }
}
