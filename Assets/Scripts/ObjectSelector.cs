using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    public List<Vector3> _moveList = new List<Vector3>();
    private bool _inMotion;

    private float _moveSpeed = 1.0f;

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
	void Update ()
	{
        if (_selectionRender.enabled)
	    {
	        _myTransformSelection.transform.Rotate(new Vector3(0,0,1),Time.deltaTime * 15);
	        if (_moveList.Count != 0)
	        {
	            if (transform.position == _moveList[0])
	            {
	                _moveList.RemoveAt(0);
	                return;
	            }
	            if (transform.position != _moveList[0])
	            {
	                float step = _moveSpeed*Time.deltaTime;
	                transform.position = Vector3.MoveTowards(transform.position, _moveList[0], step);
	            }
	        }
	    }

	    if (Input.GetMouseButtonDown(1))
	    {
	        if (_selectionRender.enabled){
                var dest = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                dest.z = 0;
                _moveList.Add(dest);   
	        }
	        
	    }
	    
	}

    private void OnMouseEnter()
    {
        _titleEnabledByMouse = true;
        CustomTitleEnable();
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
        if (Input.GetMouseButton(0))
            _selectionRender.enabled = true;
    }

}
