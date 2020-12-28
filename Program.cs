using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

 

namespace _net_homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1: "+ isPalindrome("aabbaa"));
            
            Console.WriteLine("Task 2: "+ minSplit(202));

            int[] arr = {1,2,3,5,6,80};
            Console.WriteLine("Task 3: "+ notCointains(arr));


            Console.WriteLine("Task 4: "+ isProperly("(())()()()()"));

            Console.WriteLine("Task 5: "+ countVariants(6));

            Console.WriteLine("Task 6:");
            Stack s = new Stack();
            s.Push(5);
            s.Push(10);
            s.Push(15);
            s.Pop();
            s.Print();

            // Task 7 solution is in Task7.sql file


            Exchange e = new Exchange("http://www.nbg.ge/rss.php");
            e.GetData();
            e.MatchCurrencyName();
            e.MatchCurrencyValue();
            e.GetAmountOfEachCurrency();
            e.NormalizeValues();
            e.BuildExchangeMap();
            Console.WriteLine($"Task 8 : {e.exchangeRate("USD","EUR")}");
            
        }
        static bool isPalindrome(string text){
            for(int i=0, j = text.Length-1 ;i<j;i++,j--){
                if(text[i]!=text[j]){
                    return false;
                }
            }

            return true;
        }

        static int minSplit(int amount){
            int[] coins = {1,5,10,20,50};
            List<int> lst = new List<int>();

            for(int i=coins.Length-1;i>=0;i--){
                while(amount>=coins[i]){
                    amount-=coins[i];
                    lst.Add(coins[i]);
                }
  
            }

            return lst.Count;
        }
        static int notCointains(int[] arr){
            Array.Sort(arr);
  		    int start = 0;
		    int end = arr.Length - 1;
		    int answer = arr[0] + 1;

		    while (start <= end) {

			    int mid = (start + end) / 2;

			    if (arr[mid] <= answer) {
				if (arr[mid] == answer) {
					answer++;
					end = arr.Length - 1;
				}
				start = mid + 1;
			} else {
				end = mid - 1;
			}
		}

		return answer;
	}

    static bool isProperly(string sequence){
        Stack<char> chars=new Stack<char>();
        
        for (int i = 0; i < sequence.Length; i++) {
			if (sequence[i] == '(' ) {
				chars.Push(sequence[i]);
				continue;
			} 
			else {
				if (chars.Count!=0) {

						if (chars.Peek() == '(') {
							chars.Pop();
							continue;
						} 
                        else return false;

					}  
                    else return false;
				} 
              
			}		
        return chars.Count==0;
    }

    	static int countVariants(int stearsCount) {
		if (stearsCount <= 0)
			return 0;
		if (stearsCount <= 2)
			return stearsCount;

        else
            return countVariants(stearsCount-1) + countVariants(stearsCount-2);
        
		
	}


    }
}
