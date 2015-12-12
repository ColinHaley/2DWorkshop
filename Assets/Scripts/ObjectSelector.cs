using System;
using UnityEngine;
using System.Collections;

public class ObjectSelector : MonoBehaviour
{

    public Material Highlight00;
 
    public string TitleName = "?";
    private Color _titleColorInitial = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    private Color _titleColorFaded = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    private bool _titleEnabledByMouse = false;
    private bool _titleEnabledByKey = false;
    private Renderer _titleRenderer;
    private Renderer _selectionRender;
    private Transform _myTransformMain;
    private Transform _myTransformTitle;
    private Transform _myTransformSelection;

    void Awake()
    {
        _myTransformMain = transform;
        _myTransformTitle = _myTransformMain.transform.Find("ObjectTitle");
        _myTransformSelection = _myTransformMain.transform.Find("ObjectSelection");

        _titleRenderer = _myTransformTitle.GetComponent<Renderer>();
        _selectionRender = _myTransformSelection.GetComponent<Renderer>();

        _titleRenderer.material.color = _titleColorFaded;
        _selectionRender.enabled = false;
        _selectionRender.material = Highlight00;

        
    }


    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButton(0))
	    {
	        _selectionRender.enabled = true;
	    }

	    if (_selectionRender.enabled)
	    {
	        _myTransformSelection.transform.Rotate(new Vector3(0,0,1),Time.deltaTime * 15);
	    }
	}

    void OnMouseEnter()
    {
        _titleEnabledByMouse = true;
        CustomTitleEnable();
        print("Mouse Entered");
    }

    void OnMouseExit()
    {
        _titleEnabledByMouse = false;
        if (_titleEnabledByKey)
        {
            return;
        }

        CustomTitleDisable();
    }

    void CustomTitleDisable()
    {
        for (float i = 0.0f; i < .5; i += Time.deltaTime)
        {
            
            _titleRenderer.material.color = Color.Lerp(_titleColorInitial, _titleColorFaded, i/0.5f);
            
        }
    }

    void CustomTitleEnable()
    {
        _titleRenderer.material.color = _titleColorInitial;
    }

    void OnMouseDown()
    {
        _selectionRender.enabled = true;
    }

}
