using UnityEngine;
using UnityEngine.UI;

public class UIInformations : MonoBehaviour
{
    [SerializeField] Text information;
    [SerializeField] GameObject confirmationButtons;
    [SerializeField] GameObject informationButtons;

    public void ToggleActive(bool isActive)
    {
        transform.GetChild(0).gameObject.SetActive(isActive);
    }

    public void ChangeInformation(string newText)
    {
        information.text = newText;
    }

    public void SetButtons(bool needsConfiramtion)
    {
        informationButtons.SetActive(!needsConfiramtion);
        confirmationButtons.SetActive(needsConfiramtion);
    }
}
