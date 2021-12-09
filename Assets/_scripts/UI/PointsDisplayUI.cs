using UnityEngine;
using Text = UnityEngine.UI.Text;
public class PointsDisplayUI : MonoBehaviour
{
    Text _container;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.SubscribeToEvent(Constants.ON_GET_POINTS, UpdateText);
    }

    void UpdateText(params object[] vs)
    {
        _container.text = ((int)vs[0]).ToString("D10");
    }
}
