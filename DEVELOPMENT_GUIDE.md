# Guia de Desenvolvimento - Star Wars RPG Mobile

## 🎯 Visão Geral do Projeto

Este documento descreve a arquitetura e as diretrizes para contribuir ao projeto.

## 📐 Arquitetura

### Padrão MVC (Model-View-Controller)

- **Model**: Lógica de dados e regras do jogo
- **View**: UI e renderização
- **Controller**: Gerenciamento de eventos e comunicação

### Gerenciadores Principais

1. **GameManager**: Controla o estado geral do jogo
2. **PlayerManager**: Gerencia dados do jogador
3. **CombatManager**: Gerencia o sistema de combate
4. **QuestManager**: Gerencia missões e objetivos
5. **UIManager**: Gerencia a interface do usuário
6. **AudioManager**: Gerencia sons e música

## 🎮 Sistemas de Jogo

### 1. Sistema de Combate

```
Player vs Enemy
↓
Turno do Jogador
↓
Turno do Inimigo
↓
Vitória/Derrota
```

### 2. Sistema de Progressão

- Experiência → Nível → Pontos de Habilidade
- Árvore de Habilidades (Jedi/Sith)
- Equipamento e Itens

### 3. Sistema de Missões

- Missões Principais
- Missões Secundárias
- Missões Diárias

## 💻 Convenções de Código

### C# Style Guide

```csharp
// Classes PascalCase
public class PlayerCharacter
{
    // Membros privados camelCase com underscore
    private string _characterName;
    
    // Propriedades PascalCase
    public int Health { get; set; }
    
    // Métodos PascalCase
    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}
```

## 📚 Estrutura de Pastas

```
Assets/
├── Scripts/
│   ├── Player/
│   │   ├── PlayerCharacter.cs
│   │   ├── PlayerInventory.cs
│   │   └── PlayerStats.cs
│   ├── Enemy/
│   │   ├── EnemyCharacter.cs
│   │   └── EnemyAI.cs
│   ├── Combat/
│   │   ├── CombatManager.cs
│   │   ├── CombatAction.cs
│   │   └── DamageCalculator.cs
│   ├── Quest/
│   │   ├── QuestManager.cs
│   │   ├── Quest.cs
│   │   └── QuestTracker.cs
│   ├── UI/
│   │   ├── MainMenuUI.cs
│   │   ├── HUD.cs
│   │   ├── CombatUI.cs
│   │   └── CharacterCreationUI.cs
│   ├── Managers/
│   │   ├── GameManager.cs
│   │   ├── PlayerManager.cs
│   │   ├── AudioManager.cs
│   │   └── SaveManager.cs
│   └── Utils/
│       ├── Constants.cs
│       └── Extensions.cs
├── Scenes/
│   ├── MainMenu.unity
│   ├── CharacterCreation.unity
│   ├── GameWorld.unity
│   └── Combat.unity
├── Prefabs/
│   ├── Player/
│   ├── Enemies/
│   └── UI/
├── Materials/
├── Audio/
│   ├── Music/
│   └── SFX/
└── Resources/
    └── Data/
```

## 🔄 Workflow de Git

### Criando uma Feature

```bash
# 1. Atualizar development
git checkout development
git pull origin development

# 2. Criar feature branch
git checkout -b feature/nova-funcionalidade

# 3. Fazer commits
git commit -m "feat: descrição da funcionalidade"

# 4. Push
git push origin feature/nova-funcionalidade

# 5. Criar Pull Request
```

### Tipos de Commit

- `feat:` - Nova funcionalidade
- `fix:` - Correção de bug
- `docs:` - Documentação
- `style:` - Formatação
- `refactor:` - Refatoração
- `test:` - Testes

## 🧪 Testes

### Testes Unitários

```csharp
using UnityEngine.TestTools;
using NUnit.Framework;

public class CombatManagerTests
{
    [Test]
    public void CalculateDamage_ReturnsCorrectValue()
    {
        // Arrange
        var damageCalculator = new DamageCalculator();
        
        // Act
        var result = damageCalculator.Calculate(10, 5);
        
        // Assert
        Assert.AreEqual(15, result);
    }
}
```

## 📱 Otimização para Mobile

- Minimize drawcalls
- Use object pooling
- Otimize texturas e modelos
- Implemente LOD (Level of Detail)
- Profile regularmente

## 🎨 Design de UI

- Use Canvas com RectTransform
- Implemente responsividade
- Teste em diferentes resoluções
- Use prefabs para componentes reutilizáveis

## 🔒 Boas Práticas

1. **Encapsulamento**: Use propriedades privadas/públicas apropriadamente
2. **DRY**: Não Repita Código
3. **SOLID**: Siga princípios de design
4. **Comments**: Documente código complexo
5. **Performance**: Profile antes de otimizar

## 📞 Suporte

Para dúvidas, abra uma issue no repositório.