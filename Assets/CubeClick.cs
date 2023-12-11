using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CubeClick : MonoBehaviour, IPointerClickHandler
{

    public bool isTurned = false;

    IEnumerator Fade()
    {
        float i = 0;
        float angle = 0 ;
        while(angle > -160.0f)
        {
            i += Time.deltaTime;
            angle = Mathf.Sin(i) * -170;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            yield return null;
            //print("i = " + i);
        }

    }
    
    // クリックされたときに呼び出されるメソッド
    public void OnPointerClick(PointerEventData eventData)
    {
        //print($"オブジェクト {name} がクリックされたよ！");
        if (!isTurned)
        {
            StartCoroutine("Fade");
            isTurned = true;
        }
    }
}
