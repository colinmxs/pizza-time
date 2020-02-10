using System.Threading.Tasks;

namespace PizzaTime.Core
{
    interface IUpdate
    {
        Task Update(int interval);
    }
}
