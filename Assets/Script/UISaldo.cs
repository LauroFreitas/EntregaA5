using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISaldo : MonoBehaviour
{
    public Text saldoText;
    private void Update()
    {
        saldoText.text = CadastrarProduto.saldo.ToString();
    }
}
