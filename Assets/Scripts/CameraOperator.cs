using UnityEngine;
using System.Collections;

public class CameraOperator : MonoBehaviour
{

    public Texture2D SelectionHighlight;
    public static Rect Selection = new Rect(0,0,0,0);
    private Vector3 _startClick = -Vector3.one;

    void checkCamera()
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
    }
    
    void Update ()
    {
        checkCamera();
    }
}
