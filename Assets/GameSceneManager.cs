using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] CameraConfiner cameraConfiner;
    [SerializeField] TintScreen screenTint;
    string currentScene;
    AsyncOperation unload;
    AsyncOperation load;


    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

    public void InitSwitchScene(string to, Vector3 targetPosition)
    {
        StartCoroutine(Transition(to, targetPosition));
    }

    IEnumerator Transition(string to, Vector3 targetPosition)
    {
        screenTint.Tint();

        yield return new WaitForSeconds(1f / screenTint.speed + 0.1f);
        SwitchScene(to, targetPosition);

        while (load != null & unload != null)
        {
            if (load.isDone) { load = null; }
            if (unload.isDone) { load = null; }
            yield return new WaitForSeconds(0.1f);
        }
        
        cameraConfiner.UpdateBounds();
        screenTint.UnTint();
        
    }

    public void SwitchScene(string to, Vector3 targetPosition)
    {
        load = SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);
        unload = SceneManager.UnloadSceneAsync(currentScene);
        currentScene = to;
        Transform playerTransform = GameManager.instance.player.transform;


        playerTransform.position = new Vector3(targetPosition.x,
        targetPosition.y, targetPosition.z);
    }

    
}
