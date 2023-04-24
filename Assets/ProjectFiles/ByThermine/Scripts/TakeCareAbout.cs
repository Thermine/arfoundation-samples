using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCareAbout : MonoBehaviour
{
    public ConditionsBar script;
    [SerializeField] private ParticleSystem particles;
    public void OnMouseDown()
    {
        StartCoroutine(PlayParticles());
        script.ChangeHappinessBar();
    }

    IEnumerator PlayParticles()
    {
        particles.Play();
        yield return new WaitForSeconds(3f);
        particles.Stop();
    }
}
