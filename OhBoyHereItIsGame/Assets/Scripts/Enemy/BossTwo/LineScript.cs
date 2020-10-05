using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{
    public GameObject Boss;
    
    public Vector3 startPos;
    public  Vector3 endPos;
   public LineRenderer lr;
    public lineDrop linedrop;
    public Transform tempLineDrop;
    Vector3 camOffset = new Vector3(0, 0, 10);

    [SerializeField] AnimationCurve ac;

    // Start is called before the first frame update
    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {
   
        
    }
    public void MakeLine()
    {
        linedrop = FindObjectOfType<lineDrop>();
        tempLineDrop = linedrop.transform;
        startPos = Boss.transform.position;
        endPos = tempLineDrop.transform.position;
     

        lr.enabled = true;
        lr.positionCount = 2;
        lr.SetPosition(0, startPos);
        lr.useWorldSpace = true;
        lr.widthCurve = ac;
        lr.numCapVertices = 10;

        endPos = linedrop.transform.position;
        lr.SetPosition(1, endPos);

    }
}