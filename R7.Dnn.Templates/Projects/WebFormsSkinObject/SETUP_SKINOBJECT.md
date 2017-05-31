# SkinObject usage

Register skinobject control in a skin:

```
<%@ Register TagPrefix="myprefix" TagName="${ProjectName}" Src="~/DesktopModules/${ProjectName}/${ProjectName}/${ProjectName}.ascx" %>
```

Reference it within skin code:

```
<myprefix:${ProjectName} runat="server" CssClass="alert alert-info" />
```