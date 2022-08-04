using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SymbolsMove : MonoBehaviour
{
    [SerializeField] private RectTransform[] Symbols;
    [SerializeField] Sprite[] Sprites;

    void Update()
    {
        for (int i = 0; i < Symbols.Length; i++)
        {
            if (Symbols[i].position.y <= -400)
            {
                ChangePosition(Symbols[i]);
                ChangeImage(Symbols[i]);
            }
        }
    }

    void ChangePosition(RectTransform Symbol)
    {
        var newPositionY = Symbol.localPosition.y + 800;
        Symbol.localPosition = new Vector3(Symbol.localPosition.x, newPositionY);
    }

    void ChangeImage(RectTransform Symbol)
    {
        var random = Random.Range(0,Sprites.Length);
        Symbol.GetComponent<Image>().sprite = Sprites[random];
    }

    public void ResetLocalPosition(float ChangePositionOn)
    {
        foreach (RectTransform Symbol in Symbols)
        {
            Symbol.localPosition = new Vector3(Symbol.localPosition.x, Symbol.localPosition.y + ChangePositionOn);
        }
    }

    
}
