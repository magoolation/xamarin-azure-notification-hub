# Azure Notification Hub Proof of Concept

Este repositório é uma POC (Prova de Conceito) da implementação do modelo do uso de Installation do [Azure Notification Hub] para envio de notificações push para Android e iOC.

Para o desenvolvimento da solução foi utilizada a documentação oficial encontrada em:  https://docs.microsoft.com/pt-br/azure/developer/mobile-apps/notification-hubs-backend-service-xamarin-forms

Foram utilizados:

- Xamarin.Forms
- Xamarin.CommunityToolkit
- ASP.NET Core
- Microsoft.Azure.NotificationHubs
- Firebase Cloud Messaging (Android)
- Apple Push Services (Apple)

## Requisitos)

- Conta Google Firebase
- Conta de Desenvolvimento Apple
- Conta no Azure

## Observações:

- Não é mais necessária á instalação e utilização do pacote Xamarin.GooglePlayServices.Base
- A classe GooglePlayServiceAvailability foi substituída   GooglePlayServiceAvailability Light
- Para demonstrar a recepção de mensagens foi adotada a abordagem com uso do SnackBar do Xamarin Community Toolkit