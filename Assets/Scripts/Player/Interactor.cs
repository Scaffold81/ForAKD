using UnityEngine;

namespace Core.Player
{
    public class Interactor : MonoBehaviour
    {
        private string _pickedObjectTag = "Item";
        [SerializeField]
        private Transform _originalParent;

        private Rigidbody _pickedObject;

        private void Update()
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == UnityEngine.TouchPhase.Began)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null && hit.collider.tag == _pickedObjectTag)
                    {
                        if (_pickedObject != null)
                            ReleaseObject();
                        else
                            PickObject(hit.collider);
                    }
                }
            }
        }

        public void PickObject(Collider hit)
        {
            _pickedObject = hit.GetComponent<Rigidbody>();
            _pickedObject.transform.parent = _originalParent;
            _pickedObject.isKinematic = true;
            _pickedObject.velocity = Vector3.zero;
            _pickedObject.angularVelocity = Vector3.zero;

        }

        public void ReleaseObject()
        {
            _pickedObject.transform.parent = null;
            _pickedObject.isKinematic= false;
            _pickedObject = null;
        }
    }
}
