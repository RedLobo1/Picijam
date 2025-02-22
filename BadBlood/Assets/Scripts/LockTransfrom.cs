using UnityEngine;

public class LockTransform : MonoBehaviour
{
    [SerializeField] private bool _UIelement;   // Whether the object is a UI element
    [SerializeField] private bool _lockTransform;  // Lock position
    [SerializeField] private bool _lockRotation;  // Lock rotation

    private Vector3 _initialPosition;
    private Quaternion _initialRotation;

    private RectTransform _rectTransform;

    void Start()
    {
        // Store initial position and rotation to reference later
        _initialPosition = transform.position;
        _initialRotation = transform.rotation;

        // If it's a UI element, get the RectTransform component
        if (_UIelement)
        {
            _rectTransform = GetComponent<RectTransform>();
        }
    }

    void Update()
    {
        if (_UIelement)
        {
            // If the object is a UI element (RectTransform)
            if (_lockTransform && _rectTransform != null)
            {
                // Lock the position of the RectTransform
                _rectTransform.anchoredPosition = _initialPosition;
            }

            if (_lockRotation && _rectTransform != null)
            {
                // Lock the rotation of the RectTransform
                _rectTransform.rotation = _initialRotation;
            }
        }
        else
        {
            // If it's a regular 3D object (Transform)
            if (_lockTransform)
            {
                // Lock the position of the object
                transform.position = _initialPosition;
            }

            if (_lockRotation)
            {
                // Lock the rotation of the object
                transform.rotation = _initialRotation;
            }
        }
    }
}

