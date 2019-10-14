using System;
using UnityEngine;

namespace Medieval.Core
{
    public class Events : MonoBehaviour
    {
        public delegate void IntInVoidOut(int value);

        public event IntInVoidOut onItemSelected;
        public event Action onConfirm;

        public void SelectItem(int index)
        {
            if (onItemSelected != null)
            {
                onItemSelected(index);
            }
        }

        public void Confirm()
        {
            if (onConfirm != null)
            {
                onConfirm();
            }
        }
    }
}