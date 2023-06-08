Function event_DocumentComplete(s, e)
    Set win = objIE.Document.parentWindow
    MsgBox win.eval("a=[];for(key in localStorage){r=/([0-9]+)-uname/.exec(key);if(r)a.push(r[1])};a.join()"),vbOKOnly,"(按Ctrl+C复制)"
    objIE.Quit
End Function

Set objIE = Wscript.CreateObject("InternetExplorer.Application","event_")
objIE.Visible = True
objIE.navigate "https://sdk.biligame.com/"
Wscript.Sleep 5000