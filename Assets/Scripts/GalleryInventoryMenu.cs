using UnityEngine;

public class GalleryInventoryMenu : MonoBehaviour
{
    [SerializeField] GameObject allGalleryMenuButtonHighlight = null;
    [SerializeField] GameObject weaponGalleryMenuButtonHighlight = null;
    [SerializeField] GameObject armorGalleryMenuButtonHighlight = null;
    [SerializeField] GameObject accessoryGalleryMenuButtonHighlight = null;

    private Player player;

    private void SetAllGalleryMenuHighlightInactive()
    {
        allGalleryMenuButtonHighlight.SetActive(false);
        weaponGalleryMenuButtonHighlight.SetActive(false);
        armorGalleryMenuButtonHighlight.SetActive(false);
        accessoryGalleryMenuButtonHighlight.SetActive(false);
    }

    public void ShowAllGallery()
    {
        SetAllGalleryMenuHighlightInactive();
        allGalleryMenuButtonHighlight.SetActive(true);
    }

    public void ShowWeaponGallery()
    {
        SetAllGalleryMenuHighlightInactive();
        weaponGalleryMenuButtonHighlight.SetActive(true);
    }

    public void ShowArmorGallery()
    {
        SetAllGalleryMenuHighlightInactive();
        armorGalleryMenuButtonHighlight.SetActive(true);
    }

    public void ShowAccessoryGallery()
    {
        SetAllGalleryMenuHighlightInactive();
        accessoryGalleryMenuButtonHighlight.SetActive(true);
    }
}
