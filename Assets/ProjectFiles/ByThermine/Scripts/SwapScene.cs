using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScene : MonoBehaviour
{
    [SerializeField] private int sceneNumber;


    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneNumber, LoadSceneMode.Single);
    }
}
