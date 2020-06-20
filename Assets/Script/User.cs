using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class User
{
    public string nome;
    public int preco;

    public User()
    {
        nome = CadastrarProduto.nome;
        preco = CadastrarProduto.preco;
    }
}
