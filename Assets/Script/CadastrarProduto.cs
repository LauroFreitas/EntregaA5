using UnityEngine;
using UnityEditor;
using Models;
using Proyecto26;
using System.Collections.Generic;
using UnityEngine.UI;


public class CadastrarProduto : MonoBehaviour
{
    public InputField nomeInput;
    public InputField precoInput;
    public Text precoText;
    public Text nomeText;

    User user = new User();
    
    public static int preco;
    public static string nome;
    public static int saldo;
    
    public void Start()
    {
        saldo = 5000;
        Debug.Log(saldo);
    }
    public void OnSubmit()
    {
        nome = nomeInput.text;
        preco = int.Parse(precoInput.text);
        PostToDatabase();
    }

    private void Update()
    {
        
    }

    private void PostToDatabase()
    {
        User user = new User();
        RestClient.Put("https://shop-5da20.firebaseio.com/" + nome + ".json", user);
    }

    

    private void RetrieveFromDatabase()
    {
        RestClient.Get<User>("https://shop-5da20.firebaseio.com/" + nomeInput.text + ".json").Then(response =>
        {
                user = response;
                UpdateScore();
        });
    }
    private void RetrieveFromDatabase1()
    {
        RestClient.Get<User>("https://shop-5da20.firebaseio.com/" + nomeInput.text + ".json").Then(response =>
        {
            user = response;
            Delete();
        });
    }
    private void RetrieveFromDatabase2()
    {
        RestClient.Get<User>("https://shop-5da20.firebaseio.com/" + nomeInput.text + ".json").Then(response =>
        {
            user = response;
            saldo -= user.preco;
            Comprar();
            Debug.Log(saldo);
        });
    }

    private void Delete()
    {
            RestClient.Delete("https://shop-5da20.firebaseio.com/" + nomeInput.text + ".json").Then(response => {
            EditorUtility.DisplayDialog("Status", response.StatusCode.ToString(), "Ok");
            });
        /*
        RestClient.Delete("https://shop-5da20.firebaseio.com/.json", (err, res) => {
            if (err != null)
            {
                EditorUtility.DisplayDialog("Error", err.Message, "Ok");

            }
            else
            {
                EditorUtility.DisplayDialog("Success", "Status: " + res.StatusCode.ToString(), "Ok");
            }
        });
        */
    }
    private void Comprar()
    {
        RestClient.Delete("https://shop-5da20.firebaseio.com/" + nomeInput.text + ".json").Then(response =>
        {
            EditorUtility.DisplayDialog("Status", response.StatusCode.ToString(), "Ok");
        });
    }

    public void OnGetScore()
    {
        RetrieveFromDatabase();
    }
    public void OnDelete()
    {
        RetrieveFromDatabase1();
    }
    public void OnComprar()
    {
        RetrieveFromDatabase2();
    }
    private void UpdateScore()
    {
        precoText.text = "Valor do item " + user.preco;
        nomeText.text = "Valor do item " + user.nome;
    }
}
