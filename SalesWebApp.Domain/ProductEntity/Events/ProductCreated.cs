using MediatR;

namespace SalesWebApp.Domain.ProductEntity.Events;

public sealed record ProductCreated(int ProductId) : INotification;