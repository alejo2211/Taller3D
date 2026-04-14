using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
    public enum PowerUpType
    {
        Heal,
        SpeedBoost,
        Shield,
        DamageBoost
    }
    private PowerUpType selectedPowerUp; // Esta variable guarda qué power-up está elegido actualmente.

    [SerializeField] private TMP_Text messageText;

    [SerializeField] private TMP_InputField inputField;

    [SerializeField]private PlayerStats playerStats;



    public void SeleccionVida()
    {
        SeleccionPowerUp(PowerUpType.Heal);
    }
    public void SeleccionVelocidad()
    {
        SeleccionPowerUp(PowerUpType.SpeedBoost);
    }
    public void SeleccionEscudo()
    {
        SeleccionPowerUp(PowerUpType.Shield);
    }
    public void SeleccionDaño()
    {
        SeleccionPowerUp(PowerUpType.DamageBoost);
    }
    private void SeleccionPowerUp(PowerUpType type) // Aqui solo guarda el enum, solo se actualiza texto
    {
        selectedPowerUp = type;
        messageText.text = "Seleccionado: " + type.ToString();
    }
    private bool ValidarReferencias()
    {
        if (playerStats == null)
        {
            messageText.text = "Error: PlayerStatsno asignado";
            return false;
        }
        if (inputField == null)
        {
            messageText.text = "Error: Input no asginado";
            return false;

        }
        if (messageText == null)
        {
            Debug.Log("Mensaje de texto no asignado en el inspector");
            return false;

        }
        return true;

    }
    public void AplicarPowerUpSeleccionado()
    {
        
        if (!ValidarReferencias()) return;
       
        if (!TryReadValue(out float value)) return;
       
        if (!ValidacionDeReglas(value)) return;
       
        AplicarPowerUp(value);
        
      

    }
    private bool TryReadValue(out float value) //  el out float, permite que el método devuelva el número leído 
    {
        value = 0f;

        if (string.IsNullOrWhiteSpace(inputField.text)) 
        {
            messageText.text = "Ingrese un valor.";
            return false;
        }

        if (!float.TryParse(inputField.text, out value))
        {
            messageText.text = "Ingrese un número válido.";
            return false;
        }

        return true;
    }

    private bool ValidacionDeReglas(float valor)
    {
        if (valor < 0f)
        {
            messageText.text = "El valor debe ser mayor que 0.";
            return false;
        }

        switch (selectedPowerUp)
        {
            case PowerUpType.Heal:
                if (playerStats.vidaActual >= playerStats.vidaMaxima)
                {
                    messageText.text = "La vida ya esta al maximo";
                    return false;
                }
                break;
            case PowerUpType.SpeedBoost:
                if (valor > 5f)
                {
                    messageText.text = "Multiplicador demasiado alto";
                    return false;
                }
                break;
            case PowerUpType.Shield:
                if (playerStats.chalecoActivo)
                {
                    messageText.text = "EL ESCUDO YA ESTA ACTIVO";
                    return false;
                }
                break;
            case PowerUpType.DamageBoost:
                playerStats.CausarDaño(valor);
                messageText.text = "Vida restante: " + playerStats.vidaActual;
                break;

        }
        return true;
    }
    private void AplicarPowerUp(float value)
    {
        switch (selectedPowerUp)
        {
            case PowerUpType.Heal:
                playerStats.Vida(value);
                messageText.text = "vida actual: " + playerStats.vidaActual;
                break;
            case PowerUpType.SpeedBoost:
                playerStats.MultiplicarVelocidad(value);
                messageText.text = "velocidad actual: " + playerStats.VelocidadActual;
                break;
            case PowerUpType.Shield:
                playerStats.ColocarEscudo(value);
                messageText.text = " ESCUDO ACTIVADO ";
                break;
            case PowerUpType.DamageBoost:
                messageText.text = "Daño causado : " + value;
                break;
        }
        





    }
}
