# Initial setup of deploy project

This template uses MSBuild to create install packages and deploy files locally,
but due to template engine limitations it will require some changes 
to be made manually in the project file.

1. Open `${ProjectName}.csproj` in text editor or open it from IDE (*Display Options > Show All Files*). 

Replace <Import Project="../packages/.../MSBuild.Community.Tasks.Targets" /> tag with the following code:

```
<!-- Begin snippet -->
<Import Project="__Settings.targets" />
<Import Project="__Defaults.targets" />
<Import Project="Tests.targets" />
<Import Project="LocalDeploy.targets" />
<Import Project="InstallPackage.targets" />
<Target Name="AfterBuild" DependsOnTargets="Tests;LocalDeploy;InstallPackage" Condition=" '$(EnableAfterBuild)' != 'false' " />
<!-- End snippet -->
```

To enable build commands from ${ProjectName} project context menu, insert following code inside the `<PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">` tag:

```
<!-- Begin snippet -->
<CustomCommands>
    <CustomCommands>
        <Command>
	        <type>Custom</type>
	        <name>Build Only</name>
	        <command>msbuild /t:Build /p:Configuration=${ProjectConfigName} /p:EnableAfterBuild=false ../${SolutionName}.sln</command>
        </Command>
        <Command>
			<type>Custom</type>
			<name>Do Local Deploy</name>
			<command>msbuild /t:Build /p:Configuration=${ProjectConfigName} /p:EnableTests=false /p:EnableInstallPackage=false /p:EnableLocalDeploy=true ../${SolutionName}.sln</command>
		</Command>
		<Command>
			<type>Custom</type>
			<name>Make Install Package</name>
			<command>msbuild /t:Build /p:Configuration=${ProjectConfigName} /p:EnableTests=true /p:EnableInstallPackage=true /p:EnableLocalDeploy=false ../${SolutionName}.sln</command>
		</Command>
		<Command>
			<type>Custom</type>
			<name>Run Tests</name>
			<command>msbuild /t:Build /p:Configuration=${ProjectConfigName} /p:EnableTests=true /p:EnableInstallPackage=false /p:EnableLocalDeploy=false ../${SolutionName}.sln</command>
		</Command>
		<Command>
			<type>Custom</type>
			<name>Re-deploy Assets</name>
			<command>msbuild /p:Configuration=${ProjectConfigName} /p:LocalDeployIncludeBinaries=false /p:EnableTests=false LocalDeploy.targets</command>
		</Command>
	</CustomCommands>
</CustomCommands>
<!-- End snippet -->

```
2. Make sure `DnnLocalDeployPath` property for your OS contains valid DNN install path
and `MainProjectName` property contains valid main project name.

3. Make sure that `MainProjectOutputPath` property targets valid `${SolutionName}` main project output path -
it could be `bin/$(Configuration)`, not just `bin`!

4. Add reference to the main project. This will ensure that deploy project won't start in case of build errors
in the main project and also that deploy project will build last.

# Testing deployment project setup

1. Switch to "Release" configuration and execute "Build All" command. 
After this in a `${ProjectName}/bin/Deploy` folder you should find a `.zip` archive with install package.

2. Switch to "Debug" configuration and execute "Build All" command. This will invoke local deploy script, 
which will copy new binaries and required resource files (such as `.ascx`, '.js', etc.) to DNN install location.

# Initial setup of DNN installation

1. Go to your website's *DNN > Host > Extensions* and install required *R7.Dnn.Extensions* library package 
from [here](https://github.com/roman-yagodin/R7.Dnn.Extensions/releases).

2. Then install your newly created extension from `${SolutionName}-00.01.00-Install.zip` package in the same way.

# Further development

* Use "Debug" configuration to do local deploy after making code changes, then update your site in a browser 
to trigger recompilation.

* Use "Release" configuration to build install package.

# Extending solution

Current scripts automatically able to add all DNN projects inside solution into a single install package 
and provide local deploy of required files. The general idea behind that is that all projects in the solution is very dependant.

If you add new DNN extension to your solution using *R7.DnnTemplates*, you probably only need to:

1. Name your project file with *${SolutionName}_* prefix like *${SolutionName}_MyNewExtension*. 

2. Set new project output path the same as `${SolutionName}` main project output path. 
Generally it will be `../${SolutionName}/bin/$(Configuration)` or `../${SolutionName}/bin`.

3. Merge new project's `.SqlDataProvider` files, `.dnn` manifest file (plus all files, referenced in the manifest -
generally, it's `license.htm` and `releaseNotes.htm`) into the similar files from `${SolutionName}` main extension project.

# General tips

* If `.targets` files changed manually, you probably need to unload/reload deployment project.
