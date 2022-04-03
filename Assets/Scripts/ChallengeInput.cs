using UnityEngine;
using UnityEngine.UI;

public class ChallengeInput : MonoBehaviour
{
    [SerializeField]
    public string inputAction;

    [SerializeField]
    public Text _text;

    [SerializeField]
    public GameObject highlight;

    //create map 

    void Update()
    {
        _text.text = inputAction;
    }

    public void EnableHighlight()
    {
        highlight.SetActive(true);
    }

    public void DisableHighlight()
    {
        highlight.SetActive(false);
    }
}
