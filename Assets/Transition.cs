using UnityEngine;
using UnityEngine.SceneManagement;


public enum TransitionType
{
    Warp,
    Scene
}

public class Transition : MonoBehaviour
{
    [SerializeField] TransitionType transitionType;
    [SerializeField] string sceneNameToTransition;
    [SerializeField] Vector3 targetTransition;
    Transform destination;

    void Start()
    {
        destination = transform.GetChild(1);
    }

    internal void InitiateTransition(Transform toTransition)
    {
        
        
        switch (transitionType)
        {
            case TransitionType.Warp:
                toTransition.position = new Vector3(destination.position.x,
                    destination.position.y,
                    toTransition.position.z);
                break;
            case TransitionType.Scene:
                GameSceneManager.instance.InitSwitchScene(sceneNameToTransition, targetTransition);
                break;
        }
    }
}

