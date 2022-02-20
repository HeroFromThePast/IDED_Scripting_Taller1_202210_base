using System.Collections.Generic;
using System.Linq;
using System;

namespace TestProject1
{
    internal class TestMethods
    {
        internal enum EValueType
        {
            Two,
            Three,
            Five,
            Seven,
            Prime
        }

        internal static Stack<int> GetNextGreaterValue(Stack<int> sourceStack) 
        {
            Stack<int> result;
            int stackCount = sourceStack.Count;

          
          
            int[] stackToArray = sourceStack.ToArray();
          
            Array.Reverse(stackToArray);

            result = new Stack<int>(stackCount);

            for (int i = 0; i < stackToArray.Length; i++) //numero comparando 
            {
                for (int j = i + 1  ; j < stackToArray.Length; j++)
                {
                    if (stackToArray[j] > stackToArray[i])
                    {
                        result.Push(stackToArray[j]);
                        break;
                    }
                   else if (j == stackToArray.Length - 1)
                    {
                        result.Push(-1);
                    }
                }
            }

            result.Push(-1);



            return result;
        }

        internal static Dictionary<int, EValueType> FillDictionaryFromSource(int[] sourceArr)
        {
            Dictionary<int, EValueType> result = new  Dictionary<int, EValueType>();

            for (int i = 0; i < sourceArr.Length; i++)
            {
                if (sourceArr[i] % 2 == 0)
                {

                    try
                    {
                        result.Add(sourceArr[i], EValueType.Two);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("An item with the same key has already been added.");
                    }
                                   
                }

                else if (sourceArr[i] % 3 == 0)
                {
                    try
                    {
                        result.Add(sourceArr[i], EValueType.Three);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("An item with the same key has already been added.");
                    }
                }

                else if (sourceArr[i] % 5 == 0)
                {
                    try
                    {
                        result.Add(sourceArr[i], EValueType.Five);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("An item with the same key has already been added.");
                    }
                }

                else if (sourceArr[i] % 7 == 0)
                {
                    try
                    {
                        result.Add(sourceArr[i], EValueType.Seven);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("An item with the same key has already been added.");
                    }
                }

                else
                {
                    try
                    {
                        result.Add(sourceArr[i], EValueType.Prime);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("An item with the same key has already been added.");
                    }
                }
            }

            return result;
        }

        internal static int CountDictionaryRegistriesWithValueType(Dictionary<int, EValueType> sourceDict, EValueType type)
        {
            int two = 0, three = 0, five = 0, seven = 0, prime = 0;
            
            foreach(KeyValuePair<int, EValueType> item in sourceDict)
            {
                if (item.Value == EValueType.Two) two++;
                else if (item.Value == EValueType.Three) three++;
                else if (item.Value == EValueType.Five) five++;
                else if (item.Value == EValueType.Seven) seven++;
                else if (item.Value == EValueType.Prime)prime++;
            }
              
            if(type == EValueType.Two) return two;
            else if (type == EValueType.Three) return three;
            else if (type == EValueType.Five) return five;
            else if (type == EValueType.Seven) return seven;
            else if (type == EValueType.Prime) return prime;

            return 0;
        }

        internal static Dictionary<int, EValueType> SortDictionaryRegistries(Dictionary<int, EValueType> sourceDict)
        {
            Dictionary<int, EValueType> result = new Dictionary<int, EValueType>();

            int[] keysArray = sourceDict.Keys.ToArray();

            for (int i = 0; i < keysArray.Length - 1; i++)
            {
                for (int j = 0; j < keysArray.Length - 1 - i; j++)
                {
                    if (keysArray[j] < keysArray[j + 1])
                    {
                        int temp = keysArray[j];
                        keysArray[j] = keysArray[j + 1];
                        keysArray[j + 1] = temp;
                    }
                }
            }

            for (int i = 0; i < keysArray.Length; i++)
            {
                if (keysArray[i] % 2 == 0)
                {

                    try
                    {
                        result.Add(keysArray[i], EValueType.Two);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("An item with the same key has already been added.");
                    }

                }

                else if (keysArray[i] % 3 == 0)
                {
                    try
                    {
                        result.Add(keysArray[i], EValueType.Three);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("An item with the same key has already been added.");
                    }
                }

                else if (keysArray[i] % 5 == 0)
                {
                    try
                    {
                        result.Add(keysArray[i], EValueType.Five);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("An item with the same key has already been added.");
                    }
                }

                else if (keysArray[i] % 7 == 0)
                {
                    try
                    {
                        result.Add(keysArray[i], EValueType.Seven);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("An item with the same key has already been added.");
                    }
                }

                else
                {
                    try
                    {
                        result.Add(keysArray[i], EValueType.Prime);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("An item with the same key has already been added.");
                    }
                }
            }



            return result;
        }

        internal static Queue<Ticket>[] ClassifyTickets(List<Ticket> sourceList)
        {
            Queue<Ticket>[] result = new Queue<Ticket>[3];
            Queue<Ticket> payments = new Queue<Ticket>();
            Queue<Ticket> subscriptions = new Queue<Ticket>();
            Queue<Ticket> cancellations = new Queue<Ticket>();



            for (int i = 0; i < sourceList.Count; i++)
            {
                for (int j = 0; j < sourceList.Count; j++)
                {
                    if (sourceList[i].Turn < sourceList[j].Turn)
                    {
                        Ticket temp = sourceList[i];
                        sourceList[i] = sourceList[j];
                        sourceList[j] = temp;
                    }
                }
            }

            foreach (Ticket ticket in sourceList)
            {
                if (ticket.RequestType == Ticket.ERequestType.Payment)
                {
                    payments.Enqueue(ticket);
                }
                else if (ticket.RequestType == Ticket.ERequestType.Subscription)
                {
                    subscriptions.Enqueue(ticket);
                }
                else if (ticket.RequestType == Ticket.ERequestType.Cancellation)
                {
                    cancellations.Enqueue(ticket);
                }
            }

            result[0] = payments;
            result[1] = subscriptions;
            result[2] = cancellations;

            return result;
        }

        internal static bool AddNewTicket(Queue<Ticket> targetQueue, Ticket ticket)
        {
            bool result;

            //no me dió :c

            if(ticket.RequestType != targetQueue.Peek().RequestType)
            {
                result = false;
            }
            else
            {
                result = true;
                targetQueue.Enqueue(ticket);
            }

            /*
            if (ticket.RequestType != Ticket.ERequestType.Payment || ticket.RequestType != Ticket.ERequestType.Subscription || ticket.RequestType != Ticket.ERequestType.Cancellation)
            {
                result = false;
            }
            else
            {
                targetQueue.Enqueue(ticket);
                result = true;
            }
            */ 




            return result;
        }        
    }
}