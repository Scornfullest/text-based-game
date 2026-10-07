    //the dictionary
    List<string> go = new List<string>
    {
        "go", "move", "head", "walk", "run",
    };
    
    List<string> left = new List<string>
    {
        "left", "l", "west", "w",
    };
    
    List<string> forward = new List<string>
    {
        "forward", "forwards", "f", "north", "n",
    };
    
    List<string> right = new List<string>
    {
        "right", "r", "east", "e",
    };
    
    List<string> backward = new List<string>
    {
        "backward", "backwards", "b", "south", "s",
    };

    var dictionary = new Dictionary<string, List<string>>() //don't forget to add the lists to this again
    {
        {"go", go},
        {"left", left},
        {"forwards", forward},
        {"right", right},
        {"backwards", backward},
    };

    var dictionaryVerb = new Dictionary<string, List<string>>()
    {
        {"go", go},
    };

    var dictionarySubject = new Dictionary<string, List<string>>()
    {
        {"left",  left},
        {"forward", forward},
        {"right", right},
        {"backwards", backward},
    };
    
    var removeList = new List<string>
    {
        "the", "a", "an", "to", "i", "also", "maybe", "now", "there", "i'll", "gladly", "most", "here", "of", "off", "on",
    };

    var wordList = new List<string>();
    foreach (List<string> list in dictionary.Values)
    {
        wordList.AddRange(list);
        
    }
    wordList.AddRange(removeList);
    
    if(wordList.Count != wordList.Distinct().Count())
    {
        foreach (string word in wordList)
        {
            Console.WriteLine(word);
        }        
        Console.WriteLine("There are duplicates in the lists!");
    }
    wordList = wordList.Except(removeList).ToList();

    //the game and required things(/one-time events) in order
    int area = 1;
    
    Console.WriteLine("Hello, World!");
    PlayerInput();
    Console.WriteLine("end");
    return; //*whats this here for?
    
    //the games responses to commands
    void PlayerInput()
    {
        string? toBeWritten;
        string? playerInput = Console.ReadLine();
        string firstWord = "empty";
        string secondWord = "empty";
        
        if (playerInput != null)
        {
            playerInput = playerInput.ToLower();
            foreach (var word in removeList)
            {
                playerInput = playerInput.Replace(word + ' ', "");
            }

            firstWord = playerInput.Split(" ")[0];
            if (playerInput.Contains(' '))
            {
                secondWord = playerInput.Split(" ")[1];
            }
            else
            {
                secondWord = "";
            }
        }

        if (wordList.Contains(firstWord))
        {
            
            foreach (List<string> list in dictionary.Values)
            {
                if (list.Contains(firstWord))
                {
                    firstWord = dictionary.FirstOrDefault(x => x.Value == list).Key; //the key of the dictionary of which the list is a value
                }
                break;
            }
            
            if (wordList.Contains(secondWord))
            {
                foreach (List<string> list in dictionary.Values)
                {
                    if (list.Contains(secondWord))
                    {
                        secondWord = dictionary.FirstOrDefault(x => x.Value == list).Key;
                        break;
                    }
                }
                
                Console.WriteLine(firstWord + secondWord);
                
                //swap them if necessary, or shit on grammar
                if (dictionaryVerb.ContainsKey(firstWord)) //keep in mind this is dictionaryVERB not dictionary
                {
                    if (!dictionarySubject.ContainsKey(secondWord)) //1=1 & 2=1, mind the !
                    {
                        Console.WriteLine("[What's with all the verbs?]");
                    }
                }
                else
                {
                    if (dictionarySubject.ContainsKey(secondWord)) //1=2 & 2=2
                    {
                        Console.WriteLine("[It's not a sentence without a verb.]");
                    }
                    else //1=2 & 2=1
                    {
                        (firstWord, secondWord) = (secondWord, firstWord); //get swapped loser
                    }
                }
            }
            else
            {
                Console.WriteLine("[" + Char.ToUpper(firstWord[0]) + firstWord.Remove(0, 1) + "? Elaborate.]"); //*this might not make sense given it's the dictionary version, not what they typed and ignoring the second word if it doesn't know it
                return;
            }
        }
        else
        {
            Console.WriteLine("[Try another verb.]");
            return;
        }
        
        //*the text below is an easier version of the whole if nest resulting in a possible swap BUT it did not keep in mind it being correct
        //if dictionary1.key contains secondWord && dictionary2.key contains firstWord then (a, b) = (b, a); = tuples
        //else(aka two firstWords or secondWords) "[learn how to construct sentences])
        
        //alright now we can finally assign toBeWritten depending on where you're at and what firstWord and secondWord are!!
        if (area == 1)
        {
            //uhh
        }

        Thread.Sleep(1000);
    }