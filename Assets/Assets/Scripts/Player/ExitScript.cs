using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UnityEditor.SearchService;
using UnityEngine.Tilemaps;
using System.Collections;

public class ExitScript : MonoBehaviour
{
    private GameObject player;
    //could rewrite this to be a public variable but idkkkk it works
    private string sceneName;


    private void Start()
    //sets player object reference
    //should always work unless there's another object named player
    {
        player = this.gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    //this should only be doing stuff if player walks into a specific exit
    //prob wouldn't interfere with interact methods
    {
        if(collision.gameObject.name.Equals("BedroomExit")) {
            sceneName = "Hallway";
            moveToScene();
        }
        
       
    }
    private void moveToScene()
        //loads the needed scene and SHOULD wait until is it done loading to fire move method and unload old scene
    {
        UnityEngine.SceneManagement.Scene newScene = SceneManager.GetSceneByName(sceneName);
        DontDestroyOnLoad(player);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        SceneManager.sceneLoaded += moveHelper;
        
    }
    private void moveHelper(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode)
        //auxiliary for moveToScene that contains methods that need to wait for load
    {
        SceneManager.MoveGameObjectToScene(player, scene);
        reassignPlayerValues(scene);
    }
    private void reassignPlayerValues(UnityEngine.SceneManagement.Scene scene)
        //fixes player values for new scene --
        //i.e. position on screen, tilemap
    {
        //reassign tilemap
        Tilemap solid = GameObject.Find(sceneName + " Solid").GetComponent<Tilemap>();
        player.GetComponent<PlayerController>().solidTilemap = solid;

        //reassign transform
        player.GetComponent<PlayerController>().SceneChange(new Vector3((float)-6.5, 2, 0));
        print("set SceneChanged");
    }
}
