using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public static HUDController instance;

    [SerializeField] private RectTransform crosshair;
    [SerializeField] private Vector2 defaultSize = new Vector2(32, 32);
    [SerializeField] private Vector2 enlargedSize = new Vector2(64, 64);

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCrosshairSize(bool enlarged)
    {
        if (crosshair != null)
        {
            crosshair.sizeDelta = enlarged ? enlargedSize : defaultSize;
        }
    }
}
