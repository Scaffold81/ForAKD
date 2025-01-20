using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Player
{
    public class Interactor : MonoBehaviour
    {
        private string pickedObjectTag="Item";
        [SerializeField]
        private Transform _originalParent;

        private GameObject _pickedObject;
        
        public void OnMouseClick(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                if (_pickedObject == null)
                    PickObject();
            }
            else if (context.canceled)
            {
                
                if (_pickedObject != null)
                    ReleaseObject();
            }
        }

        public void PickObject()
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward * 5f);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.tag == pickedObjectTag)
                {
                    _pickedObject = hit.collider.gameObject;
                    _originalParent = _pickedObject.transform.parent;
                    _pickedObject.transform.parent = Camera.main.transform;
                    var rb = _pickedObject.GetComponent<Rigidbody>();
                    rb.useGravity = false;
                    rb.velocity =  Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                }
            }
        }

        public void ReleaseObject()
        {
            if (_pickedObject != null)
            {
                _pickedObject.transform.parent = _originalParent;
                _pickedObject.GetComponent<Rigidbody>().useGravity = true;
                _pickedObject = null;
                _originalParent = null;
            }
        }
    }
}
