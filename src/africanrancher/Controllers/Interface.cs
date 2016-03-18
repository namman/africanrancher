using System.Threading.Tasks;

namespace africanrancher.Controllers
{
    public interface IBreedNameProvider
    {
        string GetName(int number);
    }
}
