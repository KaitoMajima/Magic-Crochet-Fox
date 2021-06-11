using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KaitoMajima
{
    public class SceneLoader : MonoBehaviour
    {
        public void Load(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void Reload()
        {
            SceneManager.LoadScene(gameObject.scene.name);
        }
        public void Quit()
        {
            Application.Quit();
        }
    }
}
