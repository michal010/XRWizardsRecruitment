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

        // Wyœwietlamy informacje o sterowaniu
        GUI.Label(new Rect(10, 10, 300, 30), "Sterowanie wózkiem za pomoc¹ WSAD/Strza³ek", style);
        GUI.Label(new Rect(10, 40, 300, 30), "U¿ywanie podnoœnika: Góra - LPM, Dó³ - PPM", style);
        GUI.Label(new Rect(10, 70, 300, 30), "Obrót kamery: Ruch myszk¹", style);
        GUI.Label(new Rect(10, 100, 300, 30), "Restart sceny: R", style);
        GUI.Label(new Rect(10, 130, 300, 120), "System oparty jest w 100% na fizyce, odczucie wózka sk³ada siê z wielu sk³adowych, takich jak jego masa, œrodek ciê¿koœci, ustawienia silnika (moc, maksymalna prêdkoœæ, wykres obrotów), oraz rzeczy takich jak wysokoœæ/si³a/rezystancja zawieszenia, masa, wykres przyczepnoœci ka¿dej z opon b¹dŸ sam system napêdu - które ko³a maj¹ byæ skrêtne a które napêdzaj¹ce. Zachêcam do poeksperymentowania z ustawieniami :)", style);
    }

}
