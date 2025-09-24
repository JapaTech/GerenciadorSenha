# Criando meu próprio Gerenciador de Senha
Recebi a notificação que teria que pagar para continuar usando os serviços. Resolvi que não vou passar por isso novamente, então resolvi criar meu prório gerenciador de senha.


## Linguagens, Ferramentas e Tecnologias
> C#,
> Visual Studio 2022,
> .Net 8

## Como funciona
Ao rodar o programa, o usuário tem 3 opções:

### 1. Criar novo arquivo de criptograifa
O aplicativo vai criar uma chave em hexadecimal que serão usadas para o usuário poder acessar seu arquivo com senhas no futuro. 
Depois irá pedir para o usuário inserir os dados do serviço do usuário para salvar: o nome do serviço, o nome do usuário, o e-mail associado e a senha. O usuário pode inserir vários serviços de uma vez.
Terminando essa parte de inserir, o programa irá salvar esses dados em um arquivo criptografado com formato personalizado 'opsafe'.

### 2. Ler um arquivo de criptografia existente
O app pede o caminho de um arquivo que o usuário deve digitar no console.
O programa verifica se o arquivo é 'opsafe', se for ele pede para a chave criptografada.
Apenas com a chave é possível ler o arquivo 'opsafe', garantido que as senhas estejam guardadas de forma segura.
Com a chave correta, o progama irá exibir todos os cadastros no console organizados.

### 3. Editar arquivo de criptografia
! Precisa implementar !

### Vídeo de demonstração
https://github.com/user-attachments/assets/b1d0d678-8d94-4102-8288-56835d45aeb5

## Coisas para solucionar
Não há verificação de inputs errados no menu, então se o usuário digitar uma opção inválida, o programa irá apresentar erro.
O programa fecha ao dar um erro, precisa ser implementado try catch para tratar erros
Não há aviso caso a chave inserida ser errada
A parte de corrigir a entrada de um serviço errado não funciona corretamente

## Funcionalidades para implementar no futuro
Edição de arquivo de senha
Pesquisar um serviço ou nome de usuário específico



