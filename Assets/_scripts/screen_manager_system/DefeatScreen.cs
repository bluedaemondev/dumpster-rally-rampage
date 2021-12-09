using UnityEngine;
using UnityEngine.UI;


public class DefeatScreen : MonoBehaviour, IScreen
{
    [SerializeField]
    Button[] content;
    [SerializeField]
    Text _pointsView;
    [SerializeField]
    Text _timeView;

    public void Activate()
    {
        foreach (var item in content)
        {
            item.interactable = true;
        }
        _timeView.text = Time.timeSinceLevelLoad.ToString("#,#0");
        _pointsView.text = GameManager.Instance.TotalPoints.ToString("D10");

    }

    public void Deactivate()
    {
        foreach (var item in content)
        {
            item.interactable = false;
        }
    }

    public string Free()
    {
        this.gameObject.SetActive(false);
        return "Defeat Screen Disabled";
    }

}
