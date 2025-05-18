using ProiectPractica.Entities;

namespace ProiectPractica.Interfaces
{
    public interface INotificationService
    {
        Task SendTaskNotificationAsync(TaskProiectEntity task, AppUserEntity recipient);
        Task ShowUINotificationAsync(string message, string userId);
    }
}
