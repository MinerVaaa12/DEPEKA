using UnityEngine;

public class HighlightController : MonoBehaviour
{
    [SerializeField] GameObject highLighter;
    GameObject currentTarget;

    public void Highlight(GameObject target)
    {
        if (currentTarget == target)
        {
            return;
        }
        currentTarget = target;
        Vector3 position = target.transform.position + Vector3.up * 0.7f;
        Highlight(position);
    }

    public void Highlight(Vector3 position)
    {
        highLighter.SetActive(true);
        highLighter.transform.position = position;
    }

    public void Hide()
    {
        currentTarget = null;
        highLighter.SetActive(false);
    }
}
