using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandle : MonoBehaviour
{
    [SerializeField] private GameObject canoPrefab;
    [SerializeField] private float tempoSpawn = 3f;
    
    [Header("Configuração da Posição")]
    [SerializeField] private float alturaMin = -2f; 
    [SerializeField] private float alturaMax = 2f; 

    [Header("Configuração da Dificuldade (Abertura)")]
    [SerializeField] private float aberturaInicial = 5f; 
    [SerializeField] private float aberturaMinima = 2.5f; 
    [SerializeField] private float tempoParaAberturaMinima = 60f; 

    private float tempoAtualSpawn = 0f;

    void Update()
    {
        TrySpawn();
    }

    private void TrySpawn()
    {
        tempoAtualSpawn -= Time.deltaTime;
        if (tempoAtualSpawn > 0) return;

        // CALCULA A ABERTURA 
        
        float tempoDecorrido = Time.timeSinceLevelLoad; 

        float tempoNormalizado = Mathf.Clamp01(tempoDecorrido / tempoParaAberturaMinima);

        float aberturaAtual = Mathf.Lerp(aberturaInicial, aberturaMinima, tempoNormalizado);

        float alturaAleatoria = Random.Range(alturaMin, alturaMax);
        Vector3 posicaoSpawn = new Vector3(8, alturaAleatoria, 0); // Posição X = 8 (fora da tela)

        GameObject novoCanoObj = Instantiate(canoPrefab, posicaoSpawn, Quaternion.identity);
        
        ConfiguracaoCano config = novoCanoObj.GetComponent<ConfiguracaoCano>();

        if (config != null)
        {
            config.DefinirAbertura(aberturaAtual);
        }
        
        tempoAtualSpawn = tempoSpawn;
    }
}