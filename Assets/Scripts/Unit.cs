using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{

    public bool Selected = false;
    private Renderer _renderer;
	// Update is called once per frame
    void Awake()
    {
        _renderer = Camera.main.GetComponent<Renderer>();
    }
    void Update()
    {
        if (_renderer.isVisible && Input.GetMouseButtonUp(0))
        {
            Vector3 camPos = Camera.main.WorldToScreenPoint(transform.position);
            camPos.y = CameraOperator.InvertYCoordinate(camPos.y);
            Selected = CameraOperator.Selection.Contains(camPos);

        }

        _renderer.material.color = Selected ? Color.red : Color.white;
        //test
    }
}
