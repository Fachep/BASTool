<div align="center">

# BASTool
Biligame Account Switch Tool<br/>
Bilibili 游戏账号切换工具

</div>

通过 WebBrowser 控件读写 IE 浏览器的 localStorage 缓存实现对部分使用 Bilibili 账号登录

部分游戏支持调出SDK登录窗口[^opensdk]

（第一次摸C#和.NET，写出屎山见谅)

## 内置支持的游戏

- 原神 Genshin Impact (hk4e)
- 崩坏：星穹铁道 Honkai: Star Rail (hkrpg)
- 可自定义游戏 (SDK < 4.0)

## Todo

- [ ] 重构游戏列表相关
- [ ] （可行性未知）尝试支持 SDK 4.0+ [^versiongte4]
- [ ] （可能）WPF 重构

[^opensdk]: 需要可执行文件同名的.config中定义 appKey
[^versiongte4]: 目前没发现/接触不到使用此版本SDK的游戏。此外，4.0+使用自带的 cef 代替ie，暂不确定是否能读取缓存，如果您能提供帮助请提交 [issue](issues)
