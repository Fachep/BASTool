<div align="center">

# BASTool
[![Latest Commit](../../actions/workflows/preview.yml/badge.svg)](../../actions/workflows/preview.yml)

Biligame Account Switch Tool<br/>
Bilibili 游戏账号切换工具

</div>

保存并切换使用 Biligame SDK (< 4.0) 登录的账号凭据

内置支持的游戏可调出SDK登录窗口[^opensdk]

（第一次摸C#和.NET，写出屎山见谅）

## 下载
发布版本：前往 [Release](../../releases/) 页面下载。

也可前往 [Actions](../../actions/workflows/preview.yml) 页面找到最后一次提交的自动构建版本。

系统要求：
- .NET 7 桌面运行时
- Windows 7 及以上系统
- **Internet Explorer** 9 及以上版本

## 内置支持的游戏

- 原神 Genshin Impact (hk4e)
- 崩坏：星穹铁道 Honkai: Star Rail (hkrpg)
- 可自定义游戏 (SDK < 4.0)

## 免责声明
项目以 MIT 许可证发布。
仅供技术交流与学习，请勿用于非法目的。
使用本项目造成的任何后果，项目作者不承担法律责任。

## Todo

- [ ] 重构游戏列表相关
- [ ] AccountService GetAccountFromIExplorer改为异步方法
- [ ] （可行性未知）尝试支持 SDK 4.0+ [^versiongte4]
- [ ] （可能）WPF 重构

[^opensdk]: 需要**可执行文件同名的 .config 文件**中定义 appKey，如不需要此项功能可删除该文件，后续可能会将此文件嵌入程序。
[^versiongte4]: 目前没发现/接触不到使用4.0+版本SDK的游戏，如果您能提供信息请提交 [issue](issues)。
