using UnityEngine;
using UnityEngine.UI;
using Medieval.Core;

namespace Medieval.UI
{
    public class Informations : MonoBehaviour
    {
        [SerializeField] Text information;
        [SerializeField] GameObject confirmationButtons;
        [SerializeField] GameObject informationButtons;

        Events eventsManager;

        private void Awake()
        {
            eventsManager = FindObjectOfType<Events>();
        }

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

        public void Confirm()
        {
            eventsManager.Confirm();
        }
    }
}