using System.Threading.Tasks;

namespace africanrancher.Controllers
{
    public interface IBreedNameProvider
    {
        bool IsValid(int number);
    }
}
