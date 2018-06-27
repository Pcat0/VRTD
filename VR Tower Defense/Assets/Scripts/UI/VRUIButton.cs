using UnityEngine;
using UnityEngine.UI;


public class VRUIButton : VRUI {
    [Header("colors")]
    [SerializeField]
    protected Color hoverColor;
    [SerializeField]
    protected Color clickColor;
    protected Color normalColor;
    [Header("setup")]
    [SerializeField]
    protected Image image;

    private void Awake() {
        normalColor = image.color;
    }
    public override void OnHoverEnter(Vector2 position, ControllerState controllerState) {
        image.color = hoverColor;
    }
    public override void OnHoverExit(Vector2 position, ControllerState controllerState) {
        image.color = normalColor;
    }
}
