using UnityEngine;
using System.Collections;

public class CameraOperator : MonoBehaviour
{

    public Texture2D SelectionHighlight;
    public static Rect Selection = new Rect(0,0,0,0);
    private Vector3 _startClick = -Vector3.one;

    void CheckCamera()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startClick = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (Selection.width < 0)
            {
                Selection.x += Selection.width;
                Selection.width = -Selection.width;
            }
            if (Selection.height < 0)
            {
                Selection.y += Selection.height;
                Selection.height = -Selection.height;
            }

            _startClick = -Vector3.one;
        }
        if (Input.GetMouseButton(0))
        {
            Selection = new Rect(_startClick.x, InvertYCoordinate(_startClick.y), Input.mousePosition.x - _startClick.x, InvertYCoordinate(Input.mousePosition.y) - InvertYCoordinate(_startClick.y));
        }
    
    }

    public static float InvertYCoordinate(float y)
    {
        return Screen.height - y;
    }
    
    void Update ()
    {
        CheckCamera();
    }
}
