using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class MobileJoyStick : MonoBehaviour, IPointerUpHandler, IDragHandler, IPointerDownHandler
{
    private RectTransform joyStickTransform;

    [SerializeField] private float dragThreshold = 0.6f;
    [SerializeField] private int dragMovementDistance = 30;
    [SerializeField] private int dragOffsetDistance = 100;
    [SerializeField] private GameObject player;
    public event Action<Vector2> OnMove;
    public Vector2 offsetActual;

    private void Update()
    {
        player.GetComponent<PlayerController>().moveChar2(offsetActual);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 offset;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(joyStickTransform, eventData.position, null, out offset);
        offset = Vector2.ClampMagnitude(offset, dragOffsetDistance)/dragOffsetDistance;
        joyStickTransform.anchoredPosition = offset * dragMovementDistance;

        Vector2 inputVector = CalculateMovementInput(offset);
        OnMove?.Invoke(inputVector);
        offsetActual = offset;
    }

    private Vector2 CalculateMovementInput(Vector2 offset)
    {
        float x = Mathf.Abs(offset.x)>dragThreshold?offset.x:0;
        float y = Mathf.Abs(offset.y) > dragThreshold ? offset.y : 0;
        offsetActual = new Vector2(x, y);
        return offsetActual;
    }

    public void OnPointerDown(PointerEventData eventData) { offsetActual = Vector2.zero; }

    public void OnPointerUp(PointerEventData eventData)
    {
        joyStickTransform.anchoredPosition = Vector2.zero;
        OnMove?.Invoke(Vector2.zero);
        offsetActual = Vector2.zero;
    }

    private void Awake()
    {
        joyStickTransform = (RectTransform)transform;

    }
    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }
}
