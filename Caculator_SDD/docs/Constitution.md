# Project Constitution (專案憲法)

> **本文件是專案的最高指導原則與長期記憶庫。所有開發活動（包括人類與 AI）都必須嚴格遵守此處定義的規範。**

## 1. 核心架構原則 (Architecture Principles)

### 1.1 架構模式：MVVM (Model-View-ViewModel)
* **View (UI)**: 僅負責視圖呈現與使用者互動定義（XAML）。**嚴禁**包含任何業務邏輯。
* **ViewModel**: 負責狀態管理、命令綁定（Commands）與 UI 邏輯。它不應直接引用任何 UI 控制項（如 `Button`, `TextBox`）。
* **Model**: 包含核心業務邏輯與運算（如 `CalculatorEngine`）。它是純粹的 C# 類別，不依賴任何 UI 框架。

### 1.2 依賴注入 (Dependency Injection, DI)
* **原則**: 所有服務與外部依賴（如計算引擎、日誌服務）必須透過介面（Interface）定義。
* **實作**: 必須透過建構子注入（Constructor Injection）來獲取依賴。
* **禁止**: 嚴禁在類別內部使用 `new` 關鍵字直接實例化服務類別（`new Service()`）。

## 2. 品質閘門 (Quality Gates)

AI 在生成程式碼時，必須自我審查是否符合以下量化指標。若不符合，視為無效產出。

* **循環複雜度 (Cyclomatic Complexity)**: 單一方法的複雜度不得超過 **10**。若邏輯過於複雜，必須拆解為私有輔助方法。
* **函式長度**: 單一函式長度不得超過 **50 行**。
* **測試覆蓋率**:
    * 所有 **ViewModel** 的公開方法（Public Methods）必須有單元測試。
    * 所有 **Model** 的核心演算法必須有 100% 的路徑覆蓋測試。
* **編譯警告**: 程式碼交付時不得包含任何編譯器警告（Warnings treated as Errors）。

## 3. 負面約束 (Negative Constraints) - 絕對禁止

這是防止技術債的防火牆，AI 必須嚴格遵守：

* **🚫 禁止 Code-Behind 邏輯**: `.xaml.cs` 檔案中，除了建構子中的 `InitializeComponent()` 之外，**不得包含任何業務邏輯或事件處理程式**（Event Handlers）。所有互動必須透過 `ICommand` 綁定至 ViewModel。
* **🚫 禁止魔術數字/字串 (No Magic Numbers/Strings)**: 程式碼中不得出現未經定義的常值。必須提取為 `const`、`static readonly` 或 `enum`。
* **🚫 禁止全域靜態狀態**: 嚴禁使用 `static` 變數來儲存應用程式狀態（Singleton 服務除外）。
* **🚫 禁止上帝類別 (God Classes)**: 單一類別不應承擔過多職責。

## 4. 技術棧 (Tech Stack)

* **語言**: C# 10.0+ / .NET 8
* **UI 框架**: WinUI 3 (Windows App SDK)
* **MVVM 框架**: Community Toolkit.Mvvm (使用 Source Generators 簡化 boilerplate)
* **測試框架**: MSTest
* **Mocking 框架**: Moq (若需要)

## 5. 程式碼風格與文件 (Style & Documentation)

* **命名慣例**:
    * 類別、方法、屬性使用 `PascalCase`。
    * 私有欄位使用 `_camelCase`。
    * 介面以 `I` 開頭（如 `ICalculatorEngine`）。
* **註解**: 所有 `public` 類別與方法必須包含 XML 文件註解 (`/// <summary>`)，說明其用途、參數意義與回傳值。

---
*End of Constitution*