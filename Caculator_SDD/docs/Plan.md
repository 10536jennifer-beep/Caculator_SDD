# Implementation Plan (技術實作計畫)

## 1. 架構設計 (Architecture Design)

本專案採用 **MVVM (Model-View-ViewModel)** 架構，並透過 **Microsoft.Extensions.DependencyInjection** 實作依賴注入。

### 1.1 核心模組職責
* **Model**: `CalculatorEngine` - 純粹的運算邏輯，不依賴任何 UI。
* **ViewModel**: `CalculatorViewModel` - 處理畫面狀態（如顯示文字 `DisplayText`）、按鈕命令（`NumberCommand`, `OperationCommand`），並呼叫 Model 進行計算。
* **View**: `MainWindow` - 僅包含 XAML 佈局與資料綁定 (Data Binding)。

## 2. 關鍵介面契約 (Interface Contracts)

這是開發的核心契約，AI 必須嚴格遵守此介面簽名。

### 2.1 計算引擎介面
```csharp
public interface ICalculatorEngine
{
    /// <summary>
    /// 執行二元運算 (如 +, -, *, /)
    /// </summary>
    /// <param name="num1">第一個數字</param>
    /// <param name="num2">第二個數字</param>
    /// <param name="operation">運算子 (+, -, *, /)</param>
    /// <returns>運算結果</returns>
    /// <exception cref="DivideByZeroException">當除數為 0 時拋出</exception>
    double Calculate(double num1, double num2, string operation);

    /// <summary>
    /// 執行一元科學運算 (如 sin, cos, sqrt)
    /// </summary>
    /// <param name="num">輸入數字</param>
    /// <param name="operation">運算功能名稱 (sin, cos, sqrt)</param>
    /// <returns>運算結果</returns>
    /// <exception cref="ArgumentOutOfRangeException">當輸入無效時 (如 sqrt(-1)) 拋出</exception>
    double CalculateScientific(double num, string operation);
}