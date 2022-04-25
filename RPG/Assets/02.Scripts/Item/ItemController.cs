using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Item item;
    public int num = 1;

    [Header("Floating Effect")]
    public bool doFloatingEffect;
    public float floatingSpeed;
    public float floatingHeinght;

    [Header("Dropping Effect")]
    public float popForce;
    public float rotateSpeed;
    public LayerMask groundLayer;

    [Header("Kinematics")]
    private Rigidbody rb;
    BoxCollider col;
    Transform rendernerTransform;
    private float elapsedFixedTime;
    Vector3 rendrerOffset;

    //====================================================================
    //**************************Public Method*****************************
    //====================================================================

    public void  PickUp()
    {
        //to do -> 인벤토리에 아이템 추가
        //to do -> 픽업 효과
    }

    //====================================================================
    //**************************Public Method*****************************
    //====================================================================

    private void Awake()
    {
        rb =GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();
        rendernerTransform = transform.Find("Renderer");
        rendrerOffset = rendernerTransform.localPosition;
    }
    private void OnEnable()
    {
        elapsedFixedTime = 0;
    }
    private void FixedUpdate()
    {
        if (doFloatingEffect)
            Floating();
    }

    private void Floating()
    {
        rendernerTransform.localPosition = rendrerOffset+ new Vector3(0f,
                                                       floatingHeinght * Mathf.Sin(floatingSpeed * elapsedFixedTime),
                                                       0f);
        elapsedFixedTime += Time.deltaTime;
    }
}
