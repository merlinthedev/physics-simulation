using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private GameObject capsulePrefab;

    [SerializeField] private int choice = 0;
    private GameObject physicsObject;
    [SerializeField] private Transform parent;
    private static GameManager instance;

    private int amountOfObjects;

    private string input;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            // clear current scene of all objects with tag "PhysicsObject"
            GameObject[] objects = GameObject.FindGameObjectsWithTag("PhysicsObjects");
            foreach (GameObject obj in objects)
            {
                Destroy(obj);
            }

            LoadSampleScene();
        }
    }
    

    // Q: Why does GetChoice() work but GetPhysicsObjectChoice() doesn't?
    // A: Because GetChoice() is called from a dropdown menu, but GetPhysicsObjectChoice() is called from a button.
    // Q: Are you sure about this?
    // A: Yes, I am sure about this.


    // Get selected choice from the dropdown menu
    public void GetChoice(int choice)
    {
        switch (choice)
        {
            case 0:
                this.choice = 0;
                Debug.Log("Choice 0");
                break;
            case 1:
                this.choice = 1;
                Debug.Log("Choice 1");
                break;
            case 2:
                this.choice = 2;
                Debug.Log("Choice 2");
                break;
            case 3:
                this.choice = 3;
                Debug.Log("Choice 3");
                break;
        }
    }

    // Get selected physics object choice from the dropdown menu
    public void GetPhysicsChoice(int x)
    {
        switch (x)
        {
            case 0:
                physicsObject = cubePrefab;
                Debug.Log("Physics object choice 0");
                break;
            case 1:
                physicsObject = capsulePrefab;
                Debug.Log("Physics object choice 1");
                break;
        }
    } 


    // Load samplescene
    public void LoadSampleScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");


        // instanciate the physics objects
        initializeDemoScene();
    }

    private void initializeDemoScene()
    {
        Debug.Log("Initializing demo scene");
        Debug.Log("amount of objects: " + amountOfObjects);
        // instanciate the physics objects
        for (int i = 0; i < amountOfObjects; i++)
        {
            Instantiate(physicsObject,
                // random position 
                new Vector3(Random.Range(-3, 3), Random.Range(1, 10), Random.Range(-3, 3))
            , Quaternion.identity);
        }

    }

    private void OnEnable()
    {
        DontDestroyOnLoad(this);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void setChoice(int a)
    {
        this.choice = a;
    }

    public void setAmountOfObjects(int a)
    {
        Debug.Log("Setting amount of objects to: " + a);
        amountOfObjects = a;
    }

    public int getChoice()
    {
        return choice;
    }

    public int getAmountOfObjects()
    {
        return amountOfObjects;
    }

    public CollisionDetectionMode getCollisionMethod()
    {
        switch (this.choice)
        {
            case 0:
                return CollisionDetectionMode.Discrete;
            case 1:
                return CollisionDetectionMode.Continuous;
            case 2:
                return CollisionDetectionMode.ContinuousDynamic;
            case 3:
                return CollisionDetectionMode.ContinuousSpeculative;
            default:
                return CollisionDetectionMode.Discrete;
        }
    }

    public static GameManager getInstance()
    {
        return instance;
    }

}
