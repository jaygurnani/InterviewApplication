using System.Collections.Generic;

namespace MyContacts.Models
{
    //Interface for Engine Repository
    public interface IEngineRepository
    {
        void AddLetter(string item);

        void AddNumber(int item);
        
        string[]  GetAllLetters();

        int [] GetAllNumbers();

        List<int> GetNumbersObject();
       
    }
}