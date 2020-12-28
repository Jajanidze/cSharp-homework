using System;
using System.Collections.Generic;

namespace _net_homework{

    class Stack{
        int top;
        const int max=1000;

        int [] stack = new int[max];

        public Stack(){
            top=-1;
        }

        public bool IsEmpty(){
            return (top<0);
        }

        public bool Push(int value){
            if(top>= max){
                Console.WriteLine("Stack Overflow");
                return false;
            }
            else{
                top++;
                stack[top] = value;
                return true;
                
            }
        }

        public int Pop() 
        { 
            if (top < 0) 
            { 
                Console.WriteLine("Stack is already empty"); 
                return 0; 
            } 
            else
            { 
                int value = stack[top--]; 
                return value; 
            } 
        }
        public int Peek(){
            if(top<0){
                Console.WriteLine("Stack is empty");
                return int.MinValue;
            }
            else{
                return stack[top];
            }
        }

        public void Print(){
            if(top<0){
                Console.WriteLine("Stack is empty");
                return;
            }
            else{
                for(int i=top;i>=0;i--){
                    Console.WriteLine(stack[i]);
                }
            }
        }







    }


}
