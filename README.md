DNN Platform templates addin for MonoDevelop / Xamarin Studio
=============================================================

1) Copy 'R7.DnnTemplates' folder 
   from this package to 'Addins' folder in MonoDevelop install, 
   usually 'C:\Program Files (x86)\Xamarin Studio\AddIns' or
   'C:\Program Files (x86)\MonoDevelop\AddIns' on Windows.

2) Restart IDE. 

3) Create new project from DNN Platform templates.

# Changelog
    
## Version 0.1.3

- .designer files renamed to .controls as workaround of ASP.NET addin bug - 
  codebehind classes still updated, even if you choose to not update then 
  automatically in project settings.  
- View control uses simple control / table field binding instead of template.
- Module manifest format upgraded to 5.0 form.
- Edit control now supports popups by default.
- Project renamed to R7.DnnTemplates.
- "DotNetNuke" references in text replaced with "DNN Platform"
- Version number changed from 0.x to more uniform 0.1.x.

## Version 0.1.2

- Added references to DotNetNuke.Web.dll and Telerik.Web.UI.dll
- Controller-class refactorings: removed GetList<T> variations,
  added methods to execute custom SQL queries and SP's.
- View control now have explicitly declared labels.
- Added Utils static class with variety of useful methods.
- Forms now using DNN 6/7 styling.
- Support DNN 6/7 popups for Edit.ascx. 
- Edit link bindings moved to View.ascx.cs. 

## Version 0.1.1

- Fixed ASP.NET code editor error then completition list is about to show, 
  which was caused by target platform specification in a project template.
- Module now have correct project type: "AspNetApp".
- Added *.designer.cs" partial classes, and control definitions moved there. 
  Added "using" to common namespaces, like DotNetNuke.UI.UserControls, etc.
- Most CRUD methods in a controller class are promoted to generics, 
  so don't need to create them for each new POCO class.
- Fixed T-SQL type names in square brackets in SqlDataProvider script.
- Settings.ascx are now Settings${ProjectName}.ascx, which may be usefull
  in a case of two or more modules stored in a single folder.
- Added prototype code for cross-table references (joins), yet in comments.
	
## Version 0.1.0
 
- Initial release	
