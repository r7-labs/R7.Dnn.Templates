# Template usage

Due to template engine limitations we need to do some will require some changes to be made manually.
     
1. You may want to disable automatic updates of CodeBehind partial classes in project options
   under "ASP.NET" page. Automatic updates is not working correctly with third-party controls 
   in the MonoDevelop / Xamarin Studio anyway. This is true at least for version 4.2.3.

2. Add to your solution new project of type "DNN Platform / Deployment / Deployment Project"
   and follow instructions in it's `SETUP.md` to setup deployment.
