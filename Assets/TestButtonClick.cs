using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestButtonClick : MonoBehaviour
{
    Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => OnButtonClick());
    }
    public void OnButtonClick()
    {
        print("click");
        SceneManager.UnloadSceneAsync("BattleScene");
        SceneManager.sceneUnloaded += onUnload;

    }

    private void onUnload(Scene s)
    {
        print("scene unloaded");
        GameObject.Find("EventSystem").GetComponent<EventSystem>().enabled = true;
        print("system reenabled");
        SceneManager.sceneUnloaded -= onUnload;
    }
}
