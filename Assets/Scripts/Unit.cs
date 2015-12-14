using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{

    public bool Selected = false;
    private Renderer _renderer = Camera.main.GetComponent<Renderer>();
	// Update is called once per frame
    private void Update()
    {
        if (_renderer.isVisible && Input.GetMouseButtonUp(0))
        {
            Vector3 camPos = Camera.main.WorldToScreenPoint(transform.position);
            camPos.y = CameraOperator.InvertYCoordinate(camPos.y);
            Selected = CameraOperator.Selection.Contains(camPos);

        }

        if (Selected)
            _renderer.material.color = Color.red;
        else
            _renderer.material.color = Color.white;


}
}
