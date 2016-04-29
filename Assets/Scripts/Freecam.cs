using UnityEngine;
using System.Collections;

public class Freecam : MonoBehaviour
{
    #region Private Member Variables

    private Vector3 _lastMouse;

    #endregion

    #region Private Properties
    #endregion

    #region Private Methods

    private void Awake()
    {
        _lastMouse = new Vector3(0, 0, 0);
    }

    // Use this for initialization
    private void Start()
    {
        //
    }

    // Update is called once per frame
    private void Update()
    {
        //
        // Mouse
        //

        _lastMouse = Input.mousePosition - _lastMouse;
        _lastMouse = new Vector3(-_lastMouse.y * MouseSensitivity, _lastMouse.x * MouseSensitivity, 0);
        _lastMouse = new Vector3(transform.eulerAngles.x + _lastMouse.x, transform.eulerAngles.y + _lastMouse.y, 0);

        if (Input.GetMouseButton(1))
        {
            transform.eulerAngles = _lastMouse;
        }

        _lastMouse = Input.mousePosition;

        //
        // Keyboard
        //

        Vector3 position = GetBaseInput();

        position = position * Time.deltaTime * KeyboardSensitivity;

        transform.Translate(position);
    }

    private Vector3 GetBaseInput()
    {
        Vector3 position = new Vector3();

		if (Input.GetKey(KeyCode.E)) position += Vector3.up;
        if (Input.GetKey(KeyCode.Q)) position += Vector3.down;

        if (Input.GetKey(KeyCode.W)) position += Vector3.forward;
        if (Input.GetKey(KeyCode.A)) position += Vector3.left;
        if (Input.GetKey(KeyCode.S)) position += Vector3.back;
        if (Input.GetKey(KeyCode.D)) position += Vector3.right;

        return position;
    }

    #endregion

    #region Constructors
    #endregion

    #region Public Member Variables

    /// <summary>
    /// Mouse sensitivity
    /// Default 0.25
    /// </summary>
    public float MouseSensitivity = 0.25f;

    /// <summary>
    /// Keyboard sensitivity
    /// Default 10
    /// </summary>
    public float KeyboardSensitivity = 10.0f;

    #endregion

    #region Public Properties
    #endregion

    #region Public Methods
    #endregion
}