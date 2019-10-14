using UnityEngine;
using UnityEngine.SceneManagement;

namespace Medieval.Core
{
    public class Scenes : MonoBehaviour
    {
        public void ChangeScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public string GetCurrentScene()
        {
            return SceneManager.GetActiveScene().name;
        }
    }
}