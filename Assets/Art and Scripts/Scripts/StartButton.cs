using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {

    public void OnButtonClick(){
        print("click");
        SceneManager.LoadScene("Bedroom");
    }
}
