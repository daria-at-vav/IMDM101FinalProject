using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UnityEditor.SearchService;
using UnityEngine.Tilemaps;
using System.Collections;

public class ExitScript : NonPlayerObject {

    // This NEEDS to be SERIALIZED
    [SerializeField] string nextSceneName;

    public override void Interact() {

        DontDestroyOnLoad(base.player);
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("MainCamera"));
        SceneManager.LoadScene(nextSceneName);
        SceneManager.sceneLoaded += moveHelper;

        if (nextSceneName == "Hallway") {
            base.player.transform.position = new Vector3(-6.5f, 2.0f, 0.0f);
        } else if (nextSceneName == "Neighborhood") {
            base.player.transform.position = new Vector3(-21.5f, 3.0f, 0.0f);
        } else {
            base.player.transform.position = new Vector3(-0.5f, -4.0f, 0.0f);
        }

        print("set SceneChanged");
    }

    // Auxiliary for moveToScene that contains methods that need to wait for load
    private void moveHelper(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode) {
        SceneManager.MoveGameObjectToScene(player, scene);

        print(nextSceneName);

        Tilemap solid = GameObject.Find(nextSceneName + " Solid").GetComponent<Tilemap>();
        player.GetComponent<PlayerController>().solidTilemap = solid;
        SceneManager.sceneLoaded -= moveHelper;
   }
}
