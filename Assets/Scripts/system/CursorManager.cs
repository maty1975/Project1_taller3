using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D defaultCursorTexture; // Textura del cursor por defecto
    private Texture2D cursorTexture; // Textura del cursor personalizado
    public Vector2 hotSpot = Vector2.zero; // Punto caliente del cursor personalizado

    void Start()
    {
        // Ocultar el cursor por defecto de Windows
        //Cursor.visible = false;

        // Establecer el cursor personalizado
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
    }
  

    void OnDestroy()
    {
        // Restaurar el cursor por defecto de Windows al salir del juego
        Cursor.visible = true;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void Change_Cursor(Texture2D texture_cursor)
    {
        // Establecer el cursor personalizado
        Cursor.SetCursor(texture_cursor, hotSpot, CursorMode.Auto);
    }
    
    public void Visible_Cursor()
    {
        Cursor.visible = true;
    }
    public void No_Visible_Cursor()
    {
        Cursor.visible = true;
    }
    public void SetDefaultCursor()
    {
        Cursor.SetCursor(defaultCursorTexture, hotSpot, CursorMode.Auto);
    }
    public void SetCursorTexture()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
    }
}
