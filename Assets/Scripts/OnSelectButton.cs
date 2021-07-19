using UnityEngine;
using TMPro;
public class OnSelectButton : MonoBehaviour
{
    public TextMeshProUGUI simpleUIText;

    public void OnButtonRestartClicked()
    {
        Application.LoadLevel(0);
    }

    public void OnButtonQuitClicked()
    {
        Application.Quit();
    }
}
