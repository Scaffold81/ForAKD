using UnityEngine;

namespace Core.Common
{
    public class CursorHandler : MonoBehaviour
    {
        private void OnEnable()
        {
            CursorHide();
        }

        private void CursorHide()
        {
            Cursor.lockState = CursorLockMode.Locked; // Скрыть курсор
            Cursor.visible = false; // Сделать курсор невидимым
        }

        private void CursorShow()
        {
            Cursor.lockState = CursorLockMode.Confined; // Скрыть курсор
            Cursor.visible = true; // Сделать курсор невидимым
        }

        private void OnDisable()
        {
            CursorShow();
        }
    }
}
