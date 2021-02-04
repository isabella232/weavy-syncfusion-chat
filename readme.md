# weavy-syncfusion-chat
This repository is a showcase demo what you can do with Xamarin.Forms, Syncfusion Xamarin components and Weavy. 
We have built a chat app with some of the functionality available in Weavy. 
The UI is power by some awesome [Syncfusion Xamarin.Forms](https://www.syncfusion.com/xamarin-ui-controls) components like sfChat, sfListView, sfAutoComplete and sfBadgeView.

# MVVM
We have used [MVVM Cross](https://www.mvvmcross.com/) framework for the MVVM pattern.

# Requirements to run the demo
[Visual Studio 2019](https://visualstudio.microsoft.com/downloads/) or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/).
Xamarin add-ons for Visual Studio (available via the Visual Studio installer).

# Tutorial
Learn how we created this showcase chat app in our turorial at [Weavy Docs](https://docs.weavy.com/tutorials/syncfusion-chat).

# Configure Syncfusion component licence
Sign in or create an account at Syncfusion. Go to your Dashboard and get the Trial or Paid license key for the Xamarin.Forms components. Open up this solution in Visual Studio and enter the license key in the `App.cs` file.

# Configure Weavy
The repo is pre-configured with an existing Weavy installation located at https://showcase.weavycloud.com. This is only for your convenience to get up and running quickly. We strongly recommend that you set up your own installation of Weavy. https://showcase.weavycloud.com is wiped clean every night so if you want to keep the conversations and users you test with, setup your own Weavy. Take a look at https://docs.weavy.com/server/get-started for more information how to setup Weavy locally.

Once you have your Weavy up and running you have to configure an authentication client. This is required for the JWT authentication to work. When signed in to Weavy, go to Manage -> Clients and create a new Client. Copy the Client ID and Client Secret. In the `Constants.cs` file in this chat demo repo, update the Client ID, Client Secret and the URL to your Weavy installation.


# License
Weavy has no liability for any damage or consequence that may arise by the use or viewing of this demo app. The app is for demonstrative purposes only and if you choose to use or modify the app you agree to not hold Weavy liable, in any form. By accessing, using, or modifying the app for your own usage you acknowledge and agree not to allow you to seek injunctive relief in any form for any claim related to the demo app.