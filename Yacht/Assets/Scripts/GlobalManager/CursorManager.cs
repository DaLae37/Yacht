using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager instance = null;

    public Texture2D cursorTexture;
    public Texture2D cursorClickedTexture;
    public bool hotSpotIsCenter = false;
    public Vector2 adjustHotSpot = Vector2.zero;
    private Vector2 hotSpot;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        StartCoroutine("SetCursor");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine("SetClickedCursor");
        }
        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine("SetCursor");
        }
    }

    private IEnumerator SetCursor()
    {
        yield return new WaitForEndOfFrame();

        if (hotSpotIsCenter)
        {
            hotSpot.x = cursorTexture.width / 2;
            hotSpot.y = cursorTexture.height / 2;
        }
        else
        {
            hotSpot = adjustHotSpot;
        }

        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
    }

    private IEnumerator SetClickedCursor()
    {
        yield return new WaitForEndOfFrame();

        if (hotSpotIsCenter)
        {
            hotSpot.x = cursorTexture.width / 2;
            hotSpot.y = cursorTexture.height / 2;
        }
        else
        {
            hotSpot = adjustHotSpot;
        }

        Cursor.SetCursor(cursorClickedTexture, hotSpot, CursorMode.Auto);
    }
}
