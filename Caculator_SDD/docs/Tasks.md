# Tasks (開發任務清單)

> **執行原則**: 每次僅選擇一個任務進行。嚴格遵守 TDD 循環 (Red -> Green -> Refactor)。

## Phase 1: 基礎建設 (Infrastructure)

- [ ] **Task 1.1**: 安裝必要的 NuGet 套件。
    * 安裝 `CommunityToolkit.Mvvm` (最新版)。
    * 安裝 `Microsoft.Extensions.DependencyInjection` (最新版)。
    * *DoD*: 專案檔 (.csproj) 中包含上述參照，且編譯成功。

- [ ] **Task 1.2**: 建立基礎專案結構與 DI 容器。
    * 依照 `Plan.md` 建立 `Models`, `ViewModels` 資料夾。
    * 建立 `ServiceConfigurator` 類別，並在 `App.xaml.cs` 中初始化 DI 容器。
    * *DoD*: 應用程式能啟動，且 `App.Services` 不為 null。

## Phase 2: 核心邏輯 (Core Logic - TDD Cycle)

- [ ] **Task 2.1 (RED)**: 定義介面並撰寫失敗測試。
    * 建立 `ICalculatorEngine.cs` (複製 Plan.md 中的介面定義)。
    * 建立單元測試專案 `Calculator.Tests`。
    * 撰寫針對標準運算 (+, -, *, /) 的測試案例。
    * *DoD*: 執行 `dotnet test`，看到測試因未實作而失敗 (紅燈)。

- [ ] **Task 2.2 (GREEN)**: 實作標準運算邏輯。
    * 建立 `CalculatorEngine.cs` 並實作 `ICalculatorEngine`。
    * 實作加減乘除邏輯，並處理除以零例外。
    * *DoD*: 執行 `dotnet test`，所有標準運算測試通過 (綠燈)。

- [ ] **Task 2.3 (RED)**: 為科學運算撰寫失敗測試。
    * 新增針對 `Sin`, `Cos`, `Sqrt` 的測試案例。
    * *DoD*: 測試失敗 (紅燈)。

- [ ] **Task 2.4 (GREEN)**: 實作科學運算邏輯。
    * 在 `CalculatorEngine` 中實作 `CalculateScientific` 方法。
    * 使用 `Math.Sin`, `Math.Cos`, `Math.Sqrt` (注意角度轉弧度)。
    * *DoD*: 所有測試通過 (綠燈)。

## Phase 3: UI 與整合 (Integration)

- [ ] **Task 3.1**: 實作 `CalculatorViewModel`。
    * 繼承 `ObservableObject`。
    * 透過建構子注入 `ICalculatorEngine`。
    * 實作 `DisplayText` 屬性與 `NumberCommand`, `OperationCommand`。
    * *DoD*: 能夠透過單元測試驗證 ViewModel 的命令邏輯。

- [ ] **Task 3.2**: 建立 `MainWindow` UI。
    * 使用 Grid 佈局設計計算機介面。
    * 綁定 ViewModel 的屬性與命令。
    * *DoD*: 點擊按鈕能正確顯示數字並算出結果，符合 Spec 驗收標準。

---
*End of Tasks*