using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;

public class Calculator : MonoBehaviour
{
   public TextMeshProUGUI displayText;
   private string _currentInput = "";
   private double _result = 0.0;

   public void OnButtonClick(string buttonValue)
   {
      switch (buttonValue)
      {
         case "=":
         {
            CalculateResult();
            break;
         }
         case "AC":
         {
            ClearInput();
            break;
         }
         case "C":
         {
            _currentInput = _currentInput.Substring(0, _currentInput.Length-1);
            break;
         }
         default:
         {
            _currentInput += buttonValue;
            _currentInput = (new Regex(@"[=\-\*\/\+%](?:[=\-\*\/\+%])")).Replace(_currentInput, buttonValue);
            break;
         }
      }
      UpdateDisplay();
   }

   private void CalculateResult()
   {
      _result = System.Convert.ToDouble(new System.Data.DataTable().Compute(_currentInput, ""));
      _currentInput = _result.ToString();
   }

   private void ClearInput()
   {
      _currentInput = "";
      _result = 0.0;
   }

   private void UpdateDisplay()
   {
      displayText.text = _currentInput;
   }
}
