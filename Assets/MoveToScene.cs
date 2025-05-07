using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToScene : MonoBehaviour
{
    public void moveToScene(string sceneName)
    {
        GameObject obj = this.gameObject;
        Scene newScene = SceneManager.GetSceneByName(sceneName);
        SceneManager.LoadScene(sceneName);
        SceneManager.MoveGameObjectToScene(obj, newScene);
    }

}
