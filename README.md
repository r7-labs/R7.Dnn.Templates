# About

DNN Platform templates addin for MonoDevelop / Xamarin Studio contains project and file templates
which could be used to speedup extension development process for popular ASP.NET CMS/CMF DNN Plaform (formely DotNetNuke). 
In it's current state, there are templates for module and skinobject extensions, install and source packages - 
and will be more in the future releases.

# Install

1. Download [latest addin release](https://github.com/roman-yagodin/R7.DnnTemplates/releases).

2. Open MonoDevelop / Xamarin Studio and go to "Tools &gt; Add-in manager".

4. Press "Install from file..." button, select downloaded .mpack file and press "Open".

3. Now you shoud see "DNN Platfrom Templates" in "Web Development" section. 
Select it and press "Enable".

4. Go to "File &gt; New &gt; Solution", then "C# &gt; DNN Platform" 
and create new project using "C# compiled module with DAL 2".

5. Follow instructions in the "Readme.txt" to setup build environment.

## Note for Visual Studio users

Note that Xamarin Studio / MonoDevelop uses same solution and project format as MS Visual Studio or SharpDevelop. 
So you could easily create your project with Xamarin Studio and then continue to work on it with using VS or SD.

There are some native VS templates for DNN modules like [Christoc's DotNetNuke Module Development Template](http://christoctemplate.codeplex.com/),
[BiteTheBullet](http://www.bitethebullet.co.uk/VS2010DNNTemplate.aspx) (slightly outdated) and more. 
Try them all and [drop me a line](https://github.com/roman-yagodin/R7.DnnTemplates/issues) about which features you want to see in R7.DnnTemplates.

# TODO

- [ ] Add SchedulerJob project template
- [ ] Add ViewState / Session properties for View.ascx.cs
- [ ] Add file templates for View, Edit, Settings controls
- [ ] Use template file for PetaPOCO class in a project template
- [ ] Learn to use ${Namespace} and other template variables
- [ ] Add joined table and sample code to access it
- [ ] Add sensible settings for module
- [x] Use MSBuild to automate extension package creation
- [ ] Review use ${AuthorCompany} as namespace prefix
