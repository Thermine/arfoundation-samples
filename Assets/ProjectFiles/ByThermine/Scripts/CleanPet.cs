using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanPet : MonoBehaviour
{
    [SerializeField] private ParticleSystem shower;

    public void CleanMyPet()
    {
        StartCoroutine(Cleaning());
    }

    IEnumerator Cleaning()
    {
        shower.Play();
        yield return new WaitForSeconds(3f);
    }
}
