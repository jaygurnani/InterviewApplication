using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Collections;

namespace MyContacts.Models
{
    public class EngineRepository : IEngineRepository
    {
        
        private static List<int> _numbers = new List<int>();
        private static List<string> _letters = new List<string>();

        
        public EngineRepository()
        {
            //Unit Tests
            _letters.Add("A");
            _numbers.Add(1);
        }

        List<int> IEngineRepository.GetNumbersObject()
        {
            return _numbers;
        }

        void IEngineRepository.AddLetter(string item)
        {
            _letters.Add(item);
        }

        void IEngineRepository.AddNumber(int item)
        {
            _numbers.Add(item);
        }

        string[] IEngineRepository.GetAllLetters()
        {
            return _letters.ToArray();
        }

        int[] IEngineRepository.GetAllNumbers()
        {
            return _numbers.ToArray();
        }
    }
}