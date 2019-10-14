using UnityEngine;
using UnityEngine.UI;
using Medieval.Core;

namespace Medieval.UI
{
    public class ItemSlot : MonoBehaviour
    {
        [SerializeField] Text itemAmount = null;
        [SerializeField] Image itemImage = null;

        public int index { get; set; } = 0;

        Events eventsManager;

        private void Awake()
        {
            eventsManager = FindObjectOfType<Events>();
        }

        public void SelectItem()
        {
            eventsManager.SelectItem(index);
        }

        public void ChangeItemAmount(int amount)
        {
            if (amount == 0)
            {
                itemAmount.text = "";
            }
            else
            {
                itemAmount.text = amount.ToString();
            }
        }

        public void ChangeSprite(Sprite sprite)
        {
            itemImage.sprite = sprite;
            if (sprite == null)
            {
                ToggleSelectable(false);
            }
            else
            {
                ToggleSelectable(true);
            }
        }

        public void ToggleSelectable(bool isSelectable)
        {
            if (isSelectable)
            {
                itemImage.color = Color.white;
            }
            else
            {
                itemImage.color = Color.black;
            }
        }
    }
}