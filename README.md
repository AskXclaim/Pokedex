# Pokedex
 
Pokedex is a fun `Web Api project` that allows `API consumers` to do `Access Pokemon details`.
 
A fun 'Pokedex' API that has two endpoints that:
 1. Return basic Pokemon information.
 2. Return basic Pokemon information but with a fun translation of the pokemon description.
 
## Prerequisites
 
Before you begin, ensure you have met the following requirements:
* You have a `Windows/Mac` machine, and you have Admin rights to install applications on it.<br/> 
NB: Windows machine should preferrable have windows 10<br/>
This was tested on a windows machine but should run on Mac machines that have visual studio installed.
 
 
## Setting Up Pokedex
 
To Setup Pokedex, follow these steps:
 
macOS:
1. Download and install visual studio with administrative rights.<br/>
You can get a free copy of Visual studio [here](https://visualstudio.microsoft.com/downloads/)
The link below provides a step by step guiding on installing Visual studio on a Mac<br/>
[Install Visual Studio for Mac](https://tutorials.visualstudio.com/vs4mac-install/install)<br/>
NB .NET Core + ASP.NET Core must be part of the items installed.
2. Clone the Pokedex repository. [link to repository location](https://github.com/AskXclaim/Pokedex)<br/>
3. Once cloning is complete browse to the location of the cloned repository and into the Pokedex folder <br/>
you should find the Pokedex.sln file, right-click it and open with Visual Studio .<br/>
4. When the project is completely opened in Visual Studio press F5. This would lunch the project and take you to a Swagger page<br/>
that allows the testing of the two available endpoints.
 
Windows:
1. Download and install visual studio 2019 with administrative rights and staying with the default recommendations.<br/>
You can get a free copy of Visual Studio 2019 Community [here](https://visualstudio.microsoft.com/downloads/)<br/>
[Install Visual Studio guide](https://docs.microsoft.com/en-us/visualstudio/install/install-visual-studio?view=vs-2019)<br/>
2. Clone the Pokedex repository. [link to repository location](https://github.com/AskXclaim/Pokedex)<br/>
3. Once cloning is complete browse to the location of the cloned repository and into the Pokedex folder <br/>
you should find the Pokedex.sln file, right-click it and open it with Visual Studio 2019.<br/>
4. When the project is completely opened in Visual Studio 2019 press F5. This would lunch the project and take you to a Swagger page<br/>
that allows the testing of the two mention endpoints.
 
 
## Additions to make before putting the project in a production environment 
* Add logging facilities.
* Include CancellationToken as part of request/calls and cater for cancel token calls<br/>
This should include a global cancellation handling fixture.
* Add integration tests.
 
## Contact
 
If you run into issues or would want to contact me you can reach me at Kola.abolarinwa@gmail.com.
 
## License
 
This project uses the following license.
