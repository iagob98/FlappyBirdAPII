using UnityEngine;

public class ConfiguracaoCano : MonoBehaviour
{
    [SerializeField] private Transform canoCima;
    [SerializeField] private Transform canoBaixo;

    [SerializeField] private float alturaDoCollider = 10f;

    public void DefinirAbertura(float tamanhoAbertura)
    {
  
        float metadeAltura = alturaDoCollider / 2;
        
        float metadeAbertura = tamanhoAbertura / 2;

        Vector3 posCima = canoCima.localPosition;
        Vector3 posBaixo = canoBaixo.localPosition;

        canoCima.localPosition = new Vector3(posCima.x, metadeAbertura + metadeAltura, posCima.z);

        canoBaixo.localPosition = new Vector3(posBaixo.x, -metadeAbertura - metadeAltura, posBaixo.z);
    }
}