using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyContacts.Models;

namespace EngineApi.Controllers
{

    [Route("api/engine")]
    public class EngineController : Controller
    {
        //Used for depedency injection
        public EngineController(IEngineRepository engineItems)
        {
            EngineItems = engineItems;
        }
        public IEngineRepository EngineItems { get; set; }

        [HttpGet ("{id}", Name="GetAllNumbers")]
        [Route("GetAllNumbers")] 
        public int[] GetAllNumbers()
        {
            return EngineItems.GetAllNumbers();
        }

        [HttpGet ("{id}", Name="GetAllLetters")]
        [Route("GetAllLetters")] 
        public string[] GetAllLetters()
        {
            return EngineItems.GetAllLetters();
        }

        [HttpGet ("{id}", Name="GetFibonacci")]
        [Route("GetFibonacci")] 
        public int[] GetFibonacci()
        {
            List<int> result = EngineItems.GetNumbersObject();
            var max = result.Max();
            return Fibonacci(max).ToArray();
        }

        public static List<int> Fibonacci(int n) {
        int a = 0;
        int b = 1;
        List<int> result = new List<int>();
        
        for (int i = 0; i < int.MaxValue; i++){
            int temp = a;
            a = b;
            b = temp + b;
            if (a > n){
                break;
            }
            result.Add(a);
            }
            return result;
        }

        [HttpPost]
        public IActionResult Insert([FromBody] string item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            double num;
            string letter = "";

            if(double.TryParse(item, out num)){
                
                if (num < 0){
                    throw new Exception("Numbers be nonnegative");
                }

                if (num % 1 != 0){
                    throw new Exception("Numbers be whole");
                }

                if (num % 15 == 0){
                    letter = "Z";
                }
                
                if (num % 3 == 0) {
                    letter =  "C";
                }
                if (num % 5 == 0){
                    letter =  "E";
                }
            }
            if (letter != ""){
                EngineItems.AddLetter(letter);
            } else {
                EngineItems.AddNumber((int)num);
            }
            
            return Ok();
        }
    }
    
}