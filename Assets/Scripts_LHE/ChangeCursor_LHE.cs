using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor_LHE : MonoBehaviour
{
    public Texture2D pinkCursor;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(pinkCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
