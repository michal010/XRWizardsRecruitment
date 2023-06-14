using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationDisplay : MonoBehaviour
{
    private void OnGUI()
    {
        // Ustawiamy styl tekstu dla informacji
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 12;
        style.alignment = TextAnchor.UpperLeft;
        style.normal.textColor = Color.black; // Ustawiamy kolor czcionki na czarny

        // Wy�wietlamy informacje o sterowaniu
        GUI.Label(new Rect(10, 10, 300, 30), "Sterowanie w�zkiem za pomoc� WSAD/Strza�ek", style);
        GUI.Label(new Rect(10, 40, 300, 30), "U�ywanie podno�nika: G�ra - LPM, D� - PPM", style);
        GUI.Label(new Rect(10, 70, 300, 30), "Obr�t kamery: Ruch myszk�", style);
        GUI.Label(new Rect(10, 100, 300, 30), "Restart sceny: R", style);
        GUI.Label(new Rect(10, 130, 300, 120), "System oparty jest w 100% na fizyce, odczucie w�zka sk�ada si� z wielu sk�adowych, takich jak jego masa, �rodek ci�ko�ci, ustawienia silnika (moc, maksymalna pr�dko��, wykres obrot�w), oraz rzeczy takich jak wysoko��/si�a/rezystancja zawieszenia, masa, wykres przyczepno�ci ka�dej z opon b�d� sam system nap�du - kt�re ko�a maj� by� skr�tne a kt�re nap�dzaj�ce. Zach�cam do poeksperymentowania z ustawieniami :)", style);
    }

}
