# Pokedex

Pokedex is a fun `Web Api project` that allows `API consumers` to be able to `Access [some] Pokemon details`.
 
A fun 'Pokedex' API that has two endpoints that:
 1. Return basic Pokemon information.
 2. Return basic Pokemon information but with a fun translation of the pokemon description.

Table of Contents
=================

  * [Prerequisites](#Prerequisites)
  * [Setting Up Pokedex](#Setting_Up_Pokedex)
     * [On Mac](#on_mac)
     * [On Windows](#on_windows)
  * [Things to consider in regards to production environment](#Things_to_consider_for_production)
  * [Contact](#Contact)
  * [License](#License)


## Prerequisites<a name="Prerequisites"/>
 
Before you begin, ensure you have met the following requirements:
* You have a `Windows/Mac` machine, and you have Admin rights to install applications on it.<br/> 
NB: Windows machine should preferrable have windows 10<br/>
This was tested on a windows machine but should be able to run on Mac machines that have visual studio installed.
 
 
## Setting Up Pokedex <a name="Setting_Up_Pokedex"/>
 
To Setup Pokedex, follow these steps:
 
### On macOS:<a name="on_mac"/>
1. Download and install visual studio with administrative rights.<br/>
You can get a free copy of Visual studio [here](https://visualstudio.microsoft.com/downloads/)
The link below provides a step by step guiding on installing Visual studio on a Mac<br/>
[Install Visual Studio for Mac](https://tutorials.visualstudio.com/vs4mac-install/install)<br/>
NB .NET Core + ASP.NET Core must be part of the items installed.<br/>
* If you would be using the docker file or intend to use it, you will need to install and have docker running on your Mac.<br/>
You can find instruction on how to do that at this [link](https://docs.docker.com/docker-for-mac/install/)<br/>
2. Clone the Pokedex repository. [link to repository location](https://github.com/AskXclaim/Pokedex)<br/>
3. Once cloning is complete browse to the location of the cloned repository and into the Pokedex folder <br/>
you should find the Pokedex.sln file, right-click it and open with Visual Studio .<br/>
4. When the project is completely opened in Visual Studio click Run.<br/>
This would lunch the project and take you to a Swagger page that allows the testing of the two available endpoints.<br/>
Please ensure you are running Visual Studio as an Admin.
 
### On Windows:<a name="on_windows"/>
1. Download and install visual studio 2019 with administrative rights and staying with the default recommendations.<br/>
You can get a free copy of Visual Studio 2019 Community [here](https://visualstudio.microsoft.com/downloads/)<br/>
[Install Visual Studio guide](https://docs.microsoft.com/en-us/visualstudio/install/install-visual-studio?view=vs-2019)<br/>
* If you would be using the docker file or intend to use it, you will need to install and keep docker running on your Windows machine.<br/>
you can find instruction on how to do that at this [link](https://docs.docker.com/docker-for-windows/install/)<br/>
2. Clone the Pokedex repository. [link to repository location](https://github.com/AskXclaim/Pokedex)<br/>
3. Once cloning is complete browse to the location of the cloned repository and into the Pokedex folder <br/>
you should find the Pokedex.sln file, right-click it and open it with Visual Studio 2019.<br/>
4. When the project is completely opened in Visual Studio 2019 press F5.<br/>
This would lunch the project and take you to a Swagger page that allows the testing of the two mention endpoints.<br/>
Please ensure you are running Visual Studio as an Admin<br/>
NB: In visual Studio 2019 you can choose the profile to use to run/debug the API project i.e.: IISExpress or Pokedex or Docker
 
 
## Things to consider in regards to production environment <a name="Things_to_consider_for_production"/> 
* Add logging facilities.
* Include CancellationToken as part of request/calls and cater for cancel token calls<br/>
This should include a global cancellation handling fixture.
* Authentication may become a requirement 
* Cover the all needed areas eith unit tests.
* Add integration tests.
 
## Contact <a name="Contact"/> 
 
If you run into issues or would want to contact me you can reach me at Kola.abolarinwa@gmail.com.
 
## License <a name="License"/> 
 
This project uses the following license.
