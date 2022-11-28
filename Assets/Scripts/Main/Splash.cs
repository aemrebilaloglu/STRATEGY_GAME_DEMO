using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Splash : MonoBehaviour
{
    public void Scene()
    {
        SceneManager.LoadScene("Case", LoadSceneMode.Single);
    }
}
