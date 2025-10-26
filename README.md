# IntegrationMod

面向 Duckov 的示例整合 Mod，仅上传主要文件。

## 目录结构
- `src/`：源代码与工程文件（使用 `DuckovPath` 引用本地游戏依赖）。
- `tests/`：可选的测试工程。
- `ReleaseExample/IntegrationMod/`：示例发布包，仅保留 `info.ini` 与 `preview.png`；二进制不提交。
- `.gitignore`：忽略构建产物、示例包二进制与 IDE 缓存。

## 构建前提
- 安装 .NET SDK（建议 6.x）。
- 在 `src/IntegrationMod.csproj` 中设置 `DuckovPath` 为你的游戏安装路径，例如：
  - `D:\steam\steamapps\common\Escape from Duckov`
- 项目在检测到 `$(DuckovPath)\Duckov.exe` 时，会引用以下依赖（均来自你的本地游戏安装目录）：
  - `TeamSoda.*`
  - `ItemStatsSystem.dll`
  - `Unity*`
- 若未检测到游戏目录，则使用 `src/Stubs` 中的最小接口进行编译（不具备运行时功能）。

## 构建步骤
1. 打开命令行，在仓库根目录执行：
   - `dotnet build .\IntegrationMod\src\IntegrationMod.csproj -c Release`
2. 生成的 DLL 位于：
   - `IntegrationMod\src\bin\Release\netstandard2.1\IntegrationMod.dll`

## 打包与发布（示例）
- 发布包目录建议如下（与参考项目一致）：
  - `IntegrationMod/ReleaseExample/IntegrationMod/`
    - `info.ini`（包含 `name` 指向 `YourModNamespace.ModBehaviour`）
    - `preview.png`（预览图）
    - 运行时打包时加入 `IntegrationMod.dll`，不要将 DLL 提交到仓库。
- 不要提交以下文件到仓库：
  - 来自游戏安装目录的任何 DLL（例如 `TeamSoda.*`、`Unity*`、`ItemStatsSystem.dll`）。
  - 你的本地构建输出（`src/bin`、`src/obj`、`tests/bin`、`tests/obj`）。
  - 任何示例包内的二进制（已通过 `.gitignore` 排除）。


## 入口约定
- Mod 入口类：`ModBehaviour`（继承 `Duckov.Modding.ModBehaviour`）。
- `info.ini` 的 `name` 字段示例：
  - `IntegrationMod.ModBehaviour`

## 常见问题
- 编译提示找不到 `Duckov.Modding`：检查 `DuckovPath` 是否指向正确的游戏目录，确保存在 `Duckov.exe` 与 `Duckov_Data/Managed`。
- 编译通过但运行加载失败：确认 `info.ini` 的 `name` 指向正确命名空间下的 `ModBehaviour` 类，并将 `IntegrationMod.dll` 放入你的 Mod 包目录。