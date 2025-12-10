using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Caculator_SDD.Models;
using System;

namespace Caculator_SDD.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        private readonly ICaculatorEngine _engine;

        // 暫存運算狀態
        private double _firstNumber = 0;
        private string _currentOperation = "";
        private bool _isNewEntry = true;

        [ObservableProperty]
        private string _displayText = "0";

        // ==========================================
        // 👇 修改重點：我們手動定義 CalculateCommand
        // ==========================================
        public IRelayCommand CaculateCommand { get; }

        // 建構子
        public MainViewModel(ICaculatorEngine engine)
        {
            _engine = engine;

            // 👇 在這裡手動連結 Command 與方法
            CaculateCommand = new RelayCommand(Caculate);
        }

        // 處理數字鍵 (保留自動產生)
        [RelayCommand]
        private void InputNumber(string number)
        {
            if (_displayText == "Error") Clear();

            if (_isNewEntry)
            {
                DisplayText = number == "." ? "0." : number;
                _isNewEntry = false;
            }
            else
            {
                if (number == "." && DisplayText.Contains(".")) return;

                if (DisplayText == "0" && number != ".")
                    DisplayText = number;
                else
                    DisplayText += number;
            }
        }

        // 處理運算符號 (保留自動產生)
        [RelayCommand]
        private void InputOperator(string operation)
        {
            if (_displayText == "Error") return;

            if (!string.IsNullOrEmpty(_currentOperation) && !_isNewEntry)
            {
                Caculate();
            }

            if (double.TryParse(DisplayText, out double result))
            {
                _firstNumber = result;
            }

            _currentOperation = operation;
            _isNewEntry = true;
        }

        // 處理 AC 鍵 (保留自動產生)
        [RelayCommand]
        private void Clear()
        {
            DisplayText = "0";
            _firstNumber = 0;
            _currentOperation = "";
            _isNewEntry = true;
        }

        // 核心運算邏輯 (注意：這裡移除了 [RelayCommand] 標籤，因為我們上面手動定義了)
        private void Caculate()
        {
            if (string.IsNullOrEmpty(_currentOperation)) return;

            double secondNumber;
            double.TryParse(DisplayText, out secondNumber);

            try
            {
                double result = _engine.Caculate(_firstNumber, secondNumber, _currentOperation);

                DisplayText = result.ToString();
                _firstNumber = result;
                _currentOperation = "";
                _isNewEntry = true;
            }
            catch (Exception)
            {
                DisplayText = "Error";
                _isNewEntry = true;
            }
        }
    }
}