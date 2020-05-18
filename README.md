# NumeroExtenso

1- Projeto desenvolvido em ASP.NET Core com Docker. Assim é só baixar o projeto e depurar em um docker nativamente.
2- Caso queira verificar a criação do docket, execute os passos:

* Utilizar o powershell
* docker tag ApiExtenso:latest <nome usuário>/APIExtenso
* Caso queria criar um repositório Docket e enviar o projeto execute: docker push <user>/APIExtenso
* Criar um servidor na Azure - WEB App On Linux e lincar o repositório Docker na configuração do conteiner.
