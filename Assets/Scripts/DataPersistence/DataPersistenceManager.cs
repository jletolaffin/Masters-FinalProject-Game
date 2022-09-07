using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using TMPro;

/*The DataPersistenceManager Script is one of two main classes, not including an interface,
 that are responsible for the save and loading system available in the game. */
public class DataPersistenceManager : MonoBehaviour
{
    private GameData gameData;
    
    public static DataPersistenceManager instance { get; private set;  }

    private List<DPI> dpiObject;

    [SerializeField]private string fileName;
    private FileDataManager fileDataManager;
    [SerializeField] private TextMeshProUGUI levelTimesDisplay;

    private string selectedProfile = "playerData";
    private int currentScene; 
    
    /*There should only ever be on DataPersistanceManager present in the game, and so
     upon awaking, the object checks if another object of this type is present and if so,
    destroys itself. */
    private void Awake()
    {

        if (instance != null) {
            Debug.Log("More than one DPI found");

            Destroy(this.gameObject);
            return;
        }
        instance = this;
        this.fileDataManager = new FileDataManager(Application.persistentDataPath, fileName);
        DontDestroyOnLoad(this.gameObject);

        

        
        
        

    }
    /*Sets the game data up as a new object, which means the user may start a new game with no saved
     data.*/
    public void NewGame() { 
    
        this.gameData = new GameData();
        
    }

    /*The LoadGame method uses the fileDataManager load method to pull data from the user's computer.
     If the gamedata object is null, then the new game method is called. If not, all objects that
    implement the dpi interface are added to a list via the FindALlDPIObjects method, and for each
    one the LoadGameData method is called (see PlayerMovement for more on this method). */
    public void LoadGame()
    {
        this.gameData = fileDataManager.Load(selectedProfile);

        if (this.gameData == null) {

            Debug.Log("No Data found");
            NewGame();
        }
        foreach (DPI dpi in dpiObject) {

            dpi.LoadGameData(gameData);
        }

        Debug.Log("Current loading level: " + gameData.currentLevel);
        foreach (string s in gameData.timeOnLevel) {

            Debug.Log("Level times" + s);
            Debug.Log("List length" + gameData.timeOnLevel.Count);
            
        }

        Assessment.levelTimes = gameData.timeOnLevel;


        currentScene = gameData.currentLevel;
        

           
        

    }
    /*Method assigned to the Load Game button on the Load Game menu, allowing a user
     to see their game statistics before loading.*/
    public void LoadAndBegin() {


        SceneManager.LoadScene(currentScene);

    }

    /*OnEnable is called befor ethe start method. In this case, it uses a delegate
     to add OnSceneLoaded to SceneManager.sceneLoaded, which wakes them up and makes them listen for any scenes being loaded
    or unloaded and upon those events happening, carry out their functions. See the referenced documentation for more guidance on this.
        https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager-sceneLoaded.html*/
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    /*If the DataPersistanceManager object is disabled, this method is called which removes
     OnSceneLoaded and onSceneUnloaded from the list of delegates, which stops them working. */
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;

    }

    /*Collects all objects using the DPI interface, also printing 
     the persistent data path to indicate where an object has been loaded from on a user's machine,
    meaning that everytime a scene is loaded, the list is refreshed (due to the method being called in OnEnable). */

    /*Upon a scene being loaded, initialises a list of DPI (Data Persistance Interface) objects. */
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode) {

        this.dpiObject = FindAllDPIobjects();

        Debug.Log(Application.persistentDataPath);
        


    }

    /*When the scene is unloaded, SaveGame is automatically called to preserver user data.*/
    public void OnSceneUnloaded(Scene scene) { 
    
        SaveGame();
    
        
    }

    /*Goes through the list of DPI objects and calls the SaveGameData method on each one.
     In this case, this would be the SaveGameData method from the PlayerMovement Script.*/
    public void SaveGame() {


        foreach (DPI dpi in dpiObject)
        {

            dpi.SaveGameData(gameData);
        }

        fileDataManager.Save(gameData, selectedProfile);

    }

    /*If the user exits out of the application, SaveGame is called to preserve their data. */
    private void OnApplicationQuit()
    {
        SaveGame();
    }

    /*A method that finds all the DPIObjects in the project (objects that implement the DPI interface). */
    private List<DPI> FindAllDPIobjects() {
        
        IEnumerable<DPI> dpiObjects = FindObjectsOfType<MonoBehaviour>().OfType<DPI>();

        return new List<DPI>(dpiObjects);
    
    }

    

}

/*<!--Number Planet - DataPersistenceManager
@Author: Julian Laffin, see References -->*/
