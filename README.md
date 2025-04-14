# Clube da Leitura - Sistema de Gerenciamento

![](gif)

````
PROJETO FEITO DURANTE ACADEMIA DO PROGRAMADOR 2025
````
# Funcionalidades
## M�dulos do Sistema:

## Amigos

- Cadastro de novos amigos

- Edi��o e exclus�o

- Visualiza��o da lista de amigos

## Caixas

- Cadastro e visualiza��o de caixas

- Armazenamento de revistas

## Revistas

- Cadastro de revistas com informa��es como t�tulo, edi��o, ano e associa��o a uma caixa

- Controle de status (Dispon�vel, Emprestada, Reservada)

## Empr�stimos

- Registro de empr�stimos vinculando amigo e revista

- Controle de status (Aberto, Conclu�do, Atrasado)

- Devolu��o de revistas e verifica��o de multas por atraso

## Reservas

- Cria��o de reservas entre amigos e revistas

- Exclus�o e visualiza��o de reservas

- Validade da reserva limitada a 2 dias

## Regras de Neg�cio
- Um amigo s� pode ter um empr�stimo ativo por vez.

- A data de devolu��o � calculada automaticamente com base nas regras de empr�stimo.

- Uma reserva expira ap�s 2 dias.

- Revistas n�o podem ser reservadas ou emprestadas se j� estiverem com status correspondente.