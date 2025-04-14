# Clube da Leitura - Sistema de Gerenciamento

![](gif)

````
PROJETO FEITO DURANTE ACADEMIA DO PROGRAMADOR 2025
````
# Funcionalidades
## Módulos do Sistema:

## Amigos

- Cadastro de novos amigos

- Edição e exclusão

- Visualização da lista de amigos

## Caixas

- Cadastro e visualização de caixas

- Armazenamento de revistas

## Revistas

- Cadastro de revistas com informações como título, edição, ano e associação a uma caixa

- Controle de status (Disponível, Emprestada, Reservada)

## Empréstimos

- Registro de empréstimos vinculando amigo e revista

- Controle de status (Aberto, Concluído, Atrasado)

- Devolução de revistas e verificação de multas por atraso

## Reservas

- Criação de reservas entre amigos e revistas

- Exclusão e visualização de reservas

- Validade da reserva limitada a 2 dias

## Regras de Negócio
- Um amigo só pode ter um empréstimo ativo por vez.

- A data de devolução é calculada automaticamente com base nas regras de empréstimo.

- Uma reserva expira após 2 dias.

- Revistas não podem ser reservadas ou emprestadas se já estiverem com status correspondente.