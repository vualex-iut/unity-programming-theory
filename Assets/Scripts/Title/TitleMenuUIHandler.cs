using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenuUIHandler : MonoBehaviour
{
    public void OnStart()
    {
        SceneManager.LoadScene(1);
    }
}
