using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CubeManager : MonoBehaviour
{

    public Transform[] cubes = new Transform[9];
    public float waittime = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // クリックされたときに呼び出されるメソッド
    public void OnClick()
    {
        print($"オブジェクト {name} がクリックされたよ！");
        StartCoroutine("TurnAllCubes");
    }

    IEnumerator TurnAllCubes()
    {
        for (int i = 0; i < 9; i++)
        {
            print(cubes[i].name + " fadeStart");
            if (cubes[i].GetComponent<CubeClick>().isTurned)
            {
                StartCoroutine(Fade(i));
                cubes[i].GetComponent<CubeClick>().isTurned = false;
                yield return new WaitForSeconds(waittime);
            }
        }
    }

    IEnumerator Fade(int n)
    {
        float i = 0;
        float angle = - 160;
        while (angle <= 0.0f)
        {
            i += Time.deltaTime;
            angle += Mathf.Sin(i) * 10;
            cubes[n].rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            yield return null;
        }
        cubes[n].rotation = Quaternion.AngleAxis(0, Vector3.forward);

    }
}
