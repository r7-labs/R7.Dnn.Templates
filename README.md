# About R7.DnnTemplates

DNN Platform templates addin for MonoDevelop / Xamarin Studio contains project and file templates
which could be used to speedup extension development process for popular ASP.NET CMS/CMF DNN Plaform (formely DotNetNuke). 
In it's current state, there are templates for module and skinobject extensions, install packaging and local deploy 
MSBuild scripts - and there will be more in the future releases!

Addin also enables syntax highlighting for DNN manifest files (`.dnn`, `.dnn5` and `.dnn6`), NuGet specifications (`.nuspec`)
and SQL dataprovider scripts (`.sqldataprovider`, `.SqlDataProvider`).

# Install from MonoDevelop addin repository

1. Open MonoDevelop / Xamarin Studio and go to "Tools &gt; Add-in manager".
2. Switch to "Gallery" tab, open "Web Development", select "DNN Platform Templates" (make sure that beta channel is enabled).
3. Make sure that beta channel is enabled.
4. Press "Install" button. If disabled, select addin and press "Enable".

![Install using addin manager](https://raw.githubusercontent.com/roman-yagodin/R7.DnnTemplates/master/images/install-addin-manager.png)

# Install from file

1. Download latest addin release from [here](https://github.com/roman-yagodin/R7.DnnTemplates/releases).
2. Open MonoDevelop / Xamarin Studio and go to "Tools &gt; Add-in manager".
3. Press "Install from file..." button, select downloaded `.mpack` file and press "Open".
4. Now you shoud see "DNN Platfrom Templates" in "Web Development" section. If disabled, select it and press "Enable".

# Create new solution

1. Go to "File &gt; New &gt; Solution", then "C# &gt; DNN Platform" and create new project using "C# compiled module with DAL 2".
2. Follow instructions in the `SETUP.md` to setup development environment.

![New solution screen](https://raw.githubusercontent.com/roman-yagodin/R7.DnnTemplates/master/images/new-solution.png)

# Note for Visual Studio users

Note that MonoDevelop / Xamarin Studio use same solution and project format as MS Visual Studio (and SharpDevelop). 
So you could easily create your project with MonoDevelop / Xamarin Studio and then continue to work on it with using VS.

There are some native VS templates for DNN modules:

* [Official Templates for DNN Platform 8](https://github.com/dnnsoftware/DNN.Templates)
* [Christoc's DotNetNuke Extension Development templates](https://github.com/ChrisHammond/DNNTemplates)
* [BiteTheBullet](http://www.bitethebullet.co.uk/VS2010DNNTemplate.aspx) (slightly outdated)

Try them and [drop me a line](https://github.com/roman-yagodin/R7.DnnTemplates/issues) about which features you'd 
want to see in R7.DnnTemplates!

# TODO

- [ ] Add SchedulerJob project template
- [ ] Add ViewState / Session properties for View.ascx.cs
- [ ] Add file templates for View, Edit, Settings controls
- [ ] Learn to use ${Namespace} and other template variables
- [ ] Add joined table and sample code to access it
- [ ] Add sensible settings for module
- [ ] Review use ${AuthorCompany} as namespace prefix
- [x] Use template file for PetaPOCO class in a project template
- [x] Use MSBuild to automate extension package creation
