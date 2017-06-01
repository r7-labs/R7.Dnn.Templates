# About R7.Dnn.Templates

DNN Platform templates addin for MonoDevelop / Xamarin Studio contains project templates
which could be used to speedup extension development process for popular ASP.NET CMS/CMF DNN Plaform (formely DotNetNuke). 
In it's current state, there are templates for module and skinobject extensions, deployment project with install packaging
and local deploy MSBuild scripts - and there will be more in the future releases!

Addin also enables syntax highlighting for SQL dataprovider scripts (`.sqldataprovider`, `.SqlDataProvider`),
and also DNN manifest files (`.dnn`, `.dnn5` and `.dnn6`), NuGet specifications (`.nuspec`), SCSS (`.scss`) and
React files (`.jsx`).

# License

[![GPLv3](http://www.gnu.org/graphics/gplv3-127x51.png)](http://www.gnu.org/licenses/gpl.txt)

The *R7.Dnn.Templates* is free software: you can redistribute it and/or modify it under the terms of 
the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, 
or (at your option) any later version.

*Important:* Since project's main purpose is to generate template code for other projects, 
all produced code goes under the terms of the license you choose for your projects.

# Install from MonoDevelop addin repository

1. Open MonoDevelop / Xamarin Studio and go to "Tools &gt; Add-ins".
2. Switch to "Gallery" tab, open "Web Development", select "DNN Platform Templates" (make sure that Beta channel is enabled).
3. Press "Install" button. If disabled, select addin and press "Enable".

![Install using addin manager](https://raw.githubusercontent.com/roman-yagodin/R7.Dnn.Templates/master/images/install-addin-manager.png)

# Install from file

1. Download latest addin release from [here](https://github.com/roman-yagodin/R7.Dnn.Templates/releases).
2. Open MonoDevelop / Xamarin Studio and go to "Tools &gt; Add-ins".
3. Press "Install from file..." button, select downloaded `.mpack` file and press "Open".
4. Now you shoud see "DNN Platfrom Templates" in "Web Development" section. If disabled, select it and press "Enable".

# Create new solution

1. Go to "File &gt; New &gt; Solution", then "Other &gt; DNN Platform" and create new project using "WebForms Module Project" template.
2. Follow instructions in the `SETUP.md` to setup development environment.

![New solution screen](https://raw.githubusercontent.com/roman-yagodin/R7.Dnn.Templates/master/images/new-solution.png)

# Note for Visual Studio users

Note that MonoDevelop / Xamarin Studio use same solution and project format as MS Visual Studio (and SharpDevelop). 
So you could create your project with MonoDevelop / Xamarin Studio and then continue to work on it with VS
(not without some minor quirks, but still).

Note that there are some good native VS templates for DNN modules:

* [Official Templates for DNN Platform 8](https://github.com/dnnsoftware/DNN.Templates)
* [Christoc's DotNetNuke Extension Development templates](https://github.com/ChrisHammond/DNNTemplates)
* [BiteTheBullet](http://www.bitethebullet.co.uk/VS2010DNNTemplate.aspx) (slightly outdated)

Try them and [drop me a line](https://github.com/roman-yagodin/R7.Dnn.Templates/issues) about which features you'd 
want to see in *R7.Dnn.Templates*!
