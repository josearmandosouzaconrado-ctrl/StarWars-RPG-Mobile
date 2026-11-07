# Protótipo Mobile: Apocalipse Zumbi em 3D

Este repositório foi adaptado para servir como base de um protótipo de jogo mobile em 3D de apocalipse zumbi em tempo real.

## O que já foi criado

- Sistema de controle do jogador para mobile
- Sistema de movimento em terceira pessoa / visão frontal
- Sistema de disparo por toque e teclado
- Inimigos zumbis com IA básica de perseguição e ataque corpo a corpo
- Sistema de ondas de inimigos
- Sistema de pontuação e vidas
- Base para expansão com menus, UI, save, upgrade e fases

## Scripts principais

- `Assets/Scripts/Managers/ZombieGameManager.cs`
- `Assets/Scripts/Managers/ZombieWaveSpawner.cs`
- `Assets/Scripts/Player/MobilePlayerController.cs`
- `Assets/Scripts/Enemy/ZombieEnemy.cs`
- `Assets/Scripts/Combat/Projectile.cs`

## Próximos passos sugeridos

1. Criar a cena Unity com um terreno e luz do ambiente
2. Adicionar um personagem 3D com capsule / avatar simples
3. Criar prefabs de zumbi e projéteis
4. Adicionar HUD com vida, score, onda e botões de ação
5. Implementar sistema de loot, munição, medpacks e upgrades
6. Preparar build para Android / iOS

## Ideia de gameplay

- O jogador entra em uma cidade em colapso
- Zumbis chegam em ondas cada vez maiores
- O jogador anda em 3D, mira e atira com toque
- Cada onda aumenta a dificuldade, velocidade e quantidade de inimigos
- O objetivo é sobreviver o máximo de tempo e acumular pontos

## Observação

Como o repositório atual é um projeto Unity em estrutura inicial, este protótipo foi montado em scripts reutilizáveis para facilitar a construção de uma versão funcional completa dentro do padrão do projeto.
