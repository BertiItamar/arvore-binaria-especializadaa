# Construção de Árvore Binária

Este projeto implementa um algoritmo em C# para construir e visualizar uma árvore binária a partir de um array de números inteiros sem duplicidade.

## Regras de Construção da Árvore

- **Raiz**: O maior valor do array
- **Galhos da esquerda**: Números à esquerda do valor raiz, em ordem decrescente
- **Galhos da direita**: Números à direita do valor raiz, em ordem decrescente

## Cenários de Teste

### Cenário 1
**Array de entrada**: `[3, 2, 1, 6, 0, 5]`
- **Raiz**: 6
- **Galhos da esquerda**: 3, 2, 1
- **Galhos da direita**: 5, 0

```
         6
       /    \
     3       5
    /          \
  2             0
 /
1
```

### Cenário 2
**Array de entrada**: `[7, 5, 13, 9, 1, 6, 4]`
- **Raiz**: 13
- **Galhos da esquerda**: 7, 5
- **Galhos da direita**: 9, 6, 4, 1

```
       13
     /     \
   7        9
  /           \
5              6
                  \
                    4
                      \
                        1
```

## Como Executar

1. Certifique-se de ter o .NET 9.0 instalado
2. Clone o repositório
3. Execute o comando:
   ```bash
   dotnet run
   ```

## Tecnologias Utilizadas

- **C#** (.NET 9.0)
- **LINQ** para manipulação de arrays
- **Console Application** para visualização

## Estrutura do Projeto

- `Program.cs` - Implementação principal do algoritmo
- `TesteParadigma.csproj` - Arquivo de projeto .NET
- `.gitignore` - Configuração para ignorar arquivos de build
- `README.md` - Documentação do projeto

## Funcionalidades

- ✅ Construção automática da árvore baseada nas regras especificadas
- ✅ Visualização clara da estrutura da árvore no console
- ✅ Suporte a múltiplos cenários de teste
- ✅ Controle fino sobre o espaçamento e formatação visual
- ✅ Tratamento de casos especiais (arrays vazios, arrays com um elemento)

## Algoritmo

O algoritmo funciona da seguinte forma:

1. Encontra o maior valor do array (raiz)
2. Identifica a posição do maior valor
3. Separa os elementos à esquerda e à direita da raiz
4. Ordena ambos os lados em ordem decrescente
5. Constrói a visualização da árvore nível por nível

## Contribuição

Este projeto foi desenvolvido como solução para um teste técnico, demonstrando conhecimentos em:
- Algoritmos e estruturas de dados
- Programação em C#
- Manipulação de arrays e coleções
- Visualização de dados no console 