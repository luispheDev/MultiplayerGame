# MultiplayerGame
Jogo Multiplayer desenvolvido para a disciplina de Redes Multiplayer da faculdade de Tecnologia em Jogos Digitais - IFBA
Componentes do Projeto: Bruno Tiago Santos de Carvalho, David Arraz Barreto e Luis Philipe Bandeira Costa.


Implementação da Biblioteca para Jogos Multiplayer Unity/Photon Network.




##PASSO 1 : INSTALAÇÃO


Os primeiros passos antes da utilização da biblioteca e do protótipo são necessários alguns recursos e softwares a serem instalados.


Instalar uma IDE a sua escolha e para a versão do seu sistema operacional. Para esse caso utilizaremos o Visual Studio Community 2022.


Disponível em: https://visualstudio.microsoft.com/pt-br/downloads/


Após isso será necessário instalar a extensão do unity dentro do Visual Studio Installer e o Unity Hub 


Disponível em: https://store.unity.com/pt#plans-individual


OBS: Apesar das várias versões pagas e gratuitas, o plano individual “Personal” é o suficiente para utilização da biblioteca e do protótipo.


Para evitar possíveis erros e bugs, recomendamos a utilização de uma versão do editor compatível ou superior da versão de 2020.3.32f1.
Por fim será necessário criar uma conta para Unity e Photon para acessar a asset store e instalar o pacote PUN 2 FREE(Versão Gratuito do Photon Unity Network 2) e criar um servidor padrão(de até 20 usuários) no site oficial do Photon Engine. 


Disponível aqui Site do Photon: 
https://www.photonengine.com/


Disponível aqui a página da Asset Store: https://assetstore.unity.com/packages/tools/network/pun-2-free-119922#description


Após todas as configurações iniciais, será necessário importar os componentes do PUN 2 através do "Pack Manager" do editor do Unity e copiar o ID de servidor da conta do Photon para  o componente PUN Wizard(Gerenciador do PUN). 



##PASSO 2 : IMPLEMENTAÇÃO DAS BIBLIOTECAS


Para utilizar as bibliotecas de recursos base para jogos multiplayer dentro da Unity utilizando o Photon Network é necessário ter ciência das regras de conexão que o Photon Network tem, e as suas limitações a fim de evitar complicações relacionadas a cliente/servidor.


Segue entendido o passo anterior, agora é preciso importar as bibliotecas para dentro do projeto Unity, tendo em vista que a importação do PUN2 foi devidamente aplicada dentro do projeto.


Config Phanton: Biblioteca com informações base de conexão de usuário ao servidor do photon e criação/entrada de salas.
Essa biblioteca poderá ser utilizada através de uma chamada:


ConfigPhanton config = new ConfigPhanton();
________________




Dados: Biblioteca com informações referentes ao seu jogador, como inputs, vida, projéteis.
Essa biblioteca é utilizada por meio de uma hierarquia:


public class Player : Dados 
{
//Seus métodos.
}
public class Life : Dados.LifePlayer
{
//Seus métodos.
}


public class Bullet : Dados.Projectile
{
//Seus métodos.
}
